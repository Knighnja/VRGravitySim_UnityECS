using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[Serializable]
public struct ExplosionComp : IComponentData {
	public float timeToLive;
	public float currentTime;
	public float endScale;
	public bool init;
}


[UpdateAfter(typeof(BoubleSystem))]
public class ExplosionSystem : JobComponentSystem {
	private EndSimulationEntityCommandBufferSystem _ecbs;

	protected override void OnCreate(){
		base.OnCreate();
		_ecbs = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
	}


	[BurstCompile]
	public struct ExplosionJob : IJobForEachWithEntity<ExplosionComp, Scale, MaterialEmitColor> {
		public EntityCommandBuffer.Concurrent ecb;
		public float t;
		public float4 emitColor;
		public void Execute(Entity e, int i, ref ExplosionComp expl, ref Scale s, ref MaterialEmitColor mec) {

			if (expl.init) {
				expl.init = false;
				expl.endScale = s.Value * expl.endScale;
				mec.Value = emitColor;
				expl.currentTime = t > 0 ? t : 0.00001f;
			}
			if (expl.currentTime >= expl.timeToLive) {
				ecb.DestroyEntity(i, e);
			} else {
				s.Value = expl.endScale * (expl.currentTime / expl.timeToLive);
				expl.currentTime += t;
			}
		}
	}

	protected override JobHandle OnUpdate(JobHandle handle) {
		var sm = GetSingleton<SpawnerRndAreaComp>();

		handle = new ExplosionJob {
			ecb = _ecbs.CreateCommandBuffer().ToConcurrent(),
			t = Time.DeltaTime,
			emitColor = sm.colorEmitSuperMassive
		}.Schedule(this, handle);

		_ecbs.AddJobHandleForProducer(handle);

		return handle;
	}
}

