using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;

public struct ECSCopyTransToGO : IComponentData { }

[UnityEngine.ExecuteAlways]
[UpdateInGroup(typeof(TransformSystemGroup))]
[UpdateAfter(typeof(EndFrameLocalToParentSystem))]
public class ECSCopyTransToGOSystem : JobComponentSystem {
    public struct PosRot {
		public float3 pos;
		public quaternion rot;
	}

	[BurstCompile]
	struct GatherData : IJobForEachWithEntity<Translation, Rotation> {
		[WriteOnly] public NativeArray<PosRot> posRots;
		public void Execute(Entity e, int i, [ReadOnly] ref Translation pos, [ReadOnly] ref Rotation rot) {
			posRots[i] = new PosRot { pos = pos.Value, rot = rot.Value };
		}
	}

	[BurstCompile]
    struct CopyTransformsJob : IJobParallelForTransform {
		[DeallocateOnJobCompletion]
		[ReadOnly] public NativeArray<PosRot> posRots;

		public void Execute(int i, TransformAccess transform) {
            //var value = RotList[index];
            transform.position = posRots[i].pos;
            transform.localRotation = posRots[i].rot;
        }
    }

    System.Collections.Generic.List<UnityEngine.Transform> _transformList;
    EntityQuery _query;
    TransformAccessArray _transformAa;

    protected override void OnCreate() {
        _query = GetEntityQuery(ComponentType.ReadOnly<ECSCopyTransToGO>(), ComponentType.ReadOnly<Translation>(), ComponentType.ReadOnly<Rotation>());
        _transformList = new System.Collections.Generic.List<UnityEngine.Transform>();
    }

    public void AddTransforms(UnityEngine.Transform[] transforms) {
        foreach (var tfm in transforms) {
            _transformList.Add(tfm);
        }
        _transformAa = new TransformAccessArray(_transformList.ToArray());
    }
    public void AddTransform(UnityEngine.Transform transform) {
        _transformList.Add(transform);
        _transformAa = new TransformAccessArray(_transformList.ToArray());
    }

    public void RemoveTransform(UnityEngine.Transform transform) {
        _transformList.Remove(transform);
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps) {
		NativeArray<PosRot> posRots = new NativeArray<PosRot>(_transformList.Count,Allocator.TempJob);
		new GatherData { posRots = posRots }.Schedule(_query, inputDeps).Complete();
		var copyTransformsJob = new CopyTransformsJob {
            posRots = posRots
        };
        return copyTransformsJob.Schedule(_transformAa, inputDeps);
    }
}