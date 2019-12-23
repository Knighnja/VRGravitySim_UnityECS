using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using PMat = Unity.Physics.Material;
using PSphereCollider = Unity.Physics.SphereCollider;
using Random = Unity.Mathematics.Random;

[System.Serializable]
public struct BoubleComp : IComponentData {
	public float gravRadius;
	public Entity entity;
	public float3 vel;
	public float3 pos;
	public double3 velc;
	public bool colorChanged;
}

[RequiresEntityConversion]
public class BoubleAuth : MonoBehaviour, IConvertGameObjectToEntity {
	public float GravRadius;
	public static float _grad = 0;
	static Random rnd;
	static bool doRndInit = true;

	public UnityEngine.Material mat;

	public void Convert(Entity e, EntityManager em, GameObjectConversionSystem conversionSystem) {
		if (doRndInit) {
			rnd = new Random(452834052);
			doRndInit = false;
		}
		if (_grad == 0)
			_grad = GravRadius;
		em.AddComponentData(e, new BoubleComp { gravRadius = GravRadius + rnd.NextFloat(0.001f), entity = e, colorChanged = true });
	}

}

[UpdateAfter(typeof(SpawnerRndAreaSystem))]
public class BoubleSystem : JobComponentSystem {
	public struct BoubleData {
		public int gravityMult;
		public float gravityDiv;

		public int boundryBuffer;
		public float maxScale;

		public float scaleInc;
		public bool bounce;
		public bool absorb;
	}

	public BoubleData bd = new BoubleData {
		gravityMult = 500,
		gravityDiv = 0.00001f,
		boundryBuffer = 0,
		maxScale = 20,
		scaleInc = 0.03f,
		bounce = true,
		absorb = true,
	};

	/* public int gravityMult = 500;
	public float gravityDiv = 0.00001f;

	public int boundryBuffer = 0;
	public float maxScale = 20;

	public float scaleInc = 0.03f;
	public bool bounce = true;
	public bool absorb = true; */

	EntityQuery boublesQuery;
	EndSimulationEntityCommandBufferSystem _ecbs;
	CollisionSystem collisionSystem;
	SpawnerRndAreaSystem spawnSystem;
	NativeHashMap<Entity, BoubleComp> bubMap;
	NativeArray<BoubleComp> bubList;
	NativeArray<BoubleComp> bubList2;
	EntityManager em;

	int bubCount;
	float sizeToGrav;

	protected override void OnCreate() {
		boublesQuery = World.EntityManager.CreateEntityQuery(typeof(BoubleComp));
		_ecbs = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
		collisionSystem = World.GetOrCreateSystem<CollisionSystem>();
		spawnSystem = World.GetOrCreateSystem<SpawnerRndAreaSystem>();

		bubMap = new NativeHashMap<Entity, BoubleComp>(50000, Allocator.Persistent);
		bubList = new NativeArray<BoubleComp>(50000, Allocator.Persistent);
		bubList2 = new NativeArray<BoubleComp>(50000, Allocator.Persistent);
		em = World.EntityManager;
	}

	protected override void OnDestroy() {
		bubMap.Dispose();
		bubList.Dispose();
		bubList2.Dispose();
	}

	[BurstCompile]
	public struct InitBubs : IJobForEachWithEntity<BoubleComp, Translation, PhysicsVelocity> {

		public NativeArray<BoubleComp> bubs;
		public void Execute(Entity e, int i, ref BoubleComp b, ref Translation trans, ref PhysicsVelocity vel) {
			b.vel = vel.Linear;
			b.pos = trans.Value;
			bubs[i] = b;
			b.colorChanged = false;
		}
	}

	[BurstCompile]
	public struct GravJob : IJobParallelFor {
		[ReadOnly] public NativeArray<BoubleComp> bubsIn;
		[WriteOnly] public NativeArray<BoubleComp> bubsOut;
		public int numOfBubs;
		public float t;
		public int gravMultiplier; // 500
		public float gravDivider; // 0.00001f

		float dist;
		double3 n;
		bool3 nanc;
		BoubleComp b, b2;

		public void Execute(int i) {
			b = bubsIn[i];
			b.velc = float3.zero;

			for (int g = 0; g < numOfBubs; g++) {
				b2 = bubsIn[g];

				dist = math.distance(b.pos, b2.pos);

				if (dist <= b2.gravRadius) {
					n = math.normalize((double3) b2.pos - (double3) b.pos) * (b2.gravRadius * gravMultiplier - dist * gravMultiplier) * t * gravDivider;
					// need to check if NaN since it's a common result.. just set to zero if it's NaN
					nanc = math.isnan(n);

					if (math.all(!nanc)) {
						b.velc += n;
					} else {
						n.x = nanc.x ? 0 : n.x;
						n.y = nanc.y ? 0 : n.y;
						n.z = nanc.z ? 0 : n.z;
						b.velc += n;
					}
				}
			}
			bubsOut[i] = b;
		}
	}

	[BurstCompile]
	public struct CollisionJob : IJobForEachWithEntity_EBCC<CollisionInfoComp, BoubleComp, CollisionInfoSettingComp> {

		public EntityCommandBuffer.Concurrent ecb;
		[ReadOnly] public NativeHashMap<Entity, BoubleComp> bubs;
		public Entity prefabEntity;
		public float scaleInc;
		public float explosionLifeTime;
		public float explosionEndScale;
		public bool explode;
		float dist;
		BoubleComp op;
		CollisionInfoComp ci;
		ExplosionComp exp;

		public void Execute(Entity e, int index, DynamicBuffer<CollisionInfoComp> cb, ref BoubleComp b, ref CollisionInfoSettingComp setting) {
			// var b = bubs[e];
			if (cb.Length > 0) {
				for (int i = 0; i < cb.Length; i++) {
					ci = cb[i];
					if (bubs.ContainsKey(ci.Opponent) == false || ci.Opponent == prefabEntity) continue;

					if (ci.OpponentType == OpponentType.Bouble) {

						op = bubs[ci.Opponent];

						if (b.gravRadius == op.gravRadius) {
							// the tie breaker is Entity index
							b.gravRadius += (b.entity.Index > op.entity.Index) ? 0.0001f: -0.0001f;
						}

						if (b.gravRadius > op.gravRadius) {
							b.gravRadius += op.gravRadius * scaleInc;
							b.velc += (double3) op.vel * (op.gravRadius / b.gravRadius) * scaleInc;
						} else {
							if (explode) {
								exp = new ExplosionComp {
									timeToLive = explosionLifeTime,
									endScale = explosionEndScale,
									init = true,
								};
								ecb.AddComponent<ExplosionComp>(i, e, exp);
								ecb.RemoveComponent<CollisionInfoSettingComp>(i, e);
								ecb.RemoveComponent<CollisionInfoComp>(i, e);
								ecb.RemoveComponent<PhysicsVelocity>(i, e);
								ecb.RemoveComponent<PhysicsCollider>(i, e);
								ecb.RemoveComponent<PhysicsDamping>(i, e);
								ecb.RemoveComponent<PhysicsGravityFactor>(i, e);
								ecb.RemoveComponent<PhysicsMass>(i, e);
								ecb.RemoveComponent<BoubleComp>(i, e);
							} else {
								ecb.DestroyEntity(i, e);
							}
							break;
						}
					}
				}
				cb.Clear();
			}
		}

	}


	[BurstCompile]
	public struct ChangeColors : IJobForEach<BoubleComp, MaterialBaseColor, MaterialEmitColor> {
		public SpawnerRndAreaComp sm;

		public void Execute(ref BoubleComp b, ref MaterialBaseColor mbc, ref MaterialEmitColor mec) {
			if (b.colorChanged) {
				if (b.gravRadius <= sm.smallRange) {
					mbc.Value = math.lerp(sm.colorBaseTiny, sm.colorBaseSmall, b.gravRadius / sm.smallRange);
					mec.Value = math.lerp(sm.colorEmitTiny, sm.colorEmitSmall, b.gravRadius / sm.smallRange);
				} else if (b.gravRadius > sm.smallRange && b.gravRadius <= sm.mediumRange) {
					mbc.Value = math.lerp(sm.colorBaseSmall, sm.colorBaseMedium, b.gravRadius / sm.mediumRange);
					mec.Value = math.lerp(sm.colorEmitSmall, sm.colorEmitMedium, b.gravRadius / sm.mediumRange);
				} else if (b.gravRadius > sm.mediumRange && b.gravRadius <= sm.largeRange) {
					mbc.Value = math.lerp(sm.colorBaseMedium, sm.colorBaseLarge, b.gravRadius / sm.largeRange);
					mec.Value = math.lerp(sm.colorEmitMedium, sm.colorEmitLarge, b.gravRadius / sm.largeRange);
				} else if (b.gravRadius > sm.largeRange && b.gravRadius <= sm.hugeRange) {
					mbc.Value = math.lerp(sm.colorBaseLarge, sm.colorBaseHuge, b.gravRadius / sm.hugeRange);
					mec.Value = math.lerp(sm.colorEmitLarge, sm.colorEmitHuge, b.gravRadius / sm.hugeRange);
				} else if (b.gravRadius > sm.hugeRange && b.gravRadius <= sm.superRange) {
					mbc.Value = math.lerp(sm.colorBaseHuge, sm.colorBaseSuperMassive, b.gravRadius / sm.superRange);
					mec.Value = math.lerp(sm.colorEmitHuge, sm.colorEmitSuperMassive, b.gravRadius / sm.superRange);
				} else if (b.gravRadius > sm.superRange) {
					mbc.Value = sm.colorBaseSuperMassive;
					mec.Value = sm.colorEmitSuperMassive;
				}
			}
		}
	}

	[BurstCompile] 
	public struct UpdateBubsJob : IJobForEachWithEntity<BoubleComp, Scale, PhysicsVelocity, PhysicsCollider, Translation> {
		public float sizeToGrav;
		public float maxRad;
		public float maxHeight;
		public bool bounce;
		public bool absorb;
		public float maxScale;
		[ReadOnly] public NativeHashMap<Entity, BoubleComp> bubMap;
		float3 t;
		float3 tzero;
		float dist;

		public void Execute(Entity e, int index, ref BoubleComp b, ref Scale scale, ref PhysicsVelocity vel, ref PhysicsCollider pc, ref Translation trans) {
			b = bubMap[e];

			var s = b.gravRadius * sizeToGrav * 2;
			if (s != scale.Value && s <= maxScale) {
				scale.Value = s;
				var mat = PMat.Default;
				mat.Flags = absorb ? PMat.MaterialFlags.IsTrigger : 0;
				pc.Value = PSphereCollider.Create(
					new SphereGeometry { Radius = b.gravRadius * sizeToGrav },
					CollisionFilter.Default,
					mat
				);
				b.colorChanged = true;
			}

			t = vel.Linear + (float3) b.velc;

			tzero = float3.zero;
			tzero.y = b.pos.y;

			dist = math.distance(b.pos, tzero);

			if (bounce) { // simply filp the velocity of axis when it has surpassed the max

				if (b.pos.y > maxHeight && t.y > 0) {
					t.y = -t.y;
				}
				if (b.pos.y < -maxHeight && t.y < 0) {
					t.y = -t.y;
				}

				if (dist > maxRad) {
					if (math.abs(b.pos.x + t.x) > math.abs(b.pos.x - t.x)) t.x = -t.x;
					if (math.abs(b.pos.z + t.z) > math.abs(b.pos.z - t.z)) t.z = -t.z;
				}
			} else { // teleport to the other axis max and keep velocity
				if (dist > maxRad) {
					tzero = b.pos;
					tzero.y = 0;
					tzero = math.normalize(-tzero) * maxRad;
					tzero.y = b.pos.y;
					trans.Value = tzero;
				}
				if (math.abs(b.pos.y) > maxHeight) {
					if(b.pos.y > maxHeight) b.pos.y = -maxHeight;
					if(b.pos.y < -maxHeight) b.pos.y = maxHeight;
					trans.Value = b.pos;
				}
			}

			vel.Linear = t;
		}
	}

	float gravWaitTime = 0, dt;
	int framesSinceLastGrav = 0;
	protected override JobHandle OnUpdate(JobHandle handle) {
		bubCount = boublesQuery.CalculateEntityCount();
		var sm = GetSingleton<SpawnerRndAreaComp>();
		if (BoubleAuth._grad == 0 || bubCount == 0 || spawnSystem._prefabEntity == Entity.Null) return handle;
		if (sizeToGrav == 0) sizeToGrav = .5f / BoubleAuth._grad;

		bubMap.Clear();
		dt = Time.DeltaTime;

		new InitBubs { bubs = bubList }.Schedule(this, handle).Complete();

		int workers = 14;
		int countPerJob = bubCount / workers;

		if (gravWaitTime >= spawnSystem.sd.gravUpdateDelay) {
			new GravJob {
				t = framesSinceLastGrav > 0 ? dt * framesSinceLastGrav : dt,
				bubsIn = bubList,
				bubsOut = bubList2,
				numOfBubs = bubCount,
				gravMultiplier = bd.gravityMult,
				gravDivider = bd.gravityDiv
			}.Schedule(bubCount, countPerJob, handle).Complete();
			gravWaitTime = 0;
			for (int i = 0; i < bubCount; i++) {
				var item = bubList2[i];
				bubMap.TryAdd(item.entity, item);
			}
			framesSinceLastGrav = 0;
		} else {
			gravWaitTime += Time.DeltaTime;
			framesSinceLastGrav++;
			for (int i = 0; i < bubCount; i++) {
				var item = bubList[i];
				bubMap.TryAdd(item.entity, item);
			}
		}

		new UpdateBubsJob {
			maxRad = spawnSystem.sd.cylinderRadius + bd.boundryBuffer, 
			maxHeight = spawnSystem.sd.cylinderHeight + bd.boundryBuffer,
			sizeToGrav = sizeToGrav,
			bubMap = bubMap,
			bounce = bd.bounce,
			absorb = bd.absorb,
			maxScale = bd.maxScale
		}.Schedule(this, handle).Complete();

		new ChangeColors { sm = sm }.Schedule(this, handle).Complete();

		if (bd.absorb) {
			
			var cj = new CollisionJob {
				ecb = _ecbs.CreateCommandBuffer().ToConcurrent(),
				bubs = bubMap,
				prefabEntity = spawnSystem._prefabEntity,
				scaleInc = bd.scaleInc,
				explosionLifeTime = spawnSystem.sd.explosionLifeTime,
				explosionEndScale = spawnSystem.sd.explosionEndScale,
				explode = spawnSystem.sd.explode
			};
			
			handle = cj.Schedule(this, handle);

			collisionSystem.AddDependingJobHandle(handle);

			_ecbs.AddJobHandleForProducer(handle);
		}

		return handle;
	}
}