using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.LowLevel;
using Unity.Physics.Systems;


[UpdateInGroup(typeof(LateSimulationSystemGroup))]
public class CollisionSystem : JobComponentSystem {
    BeginInitializationEntityCommandBufferSystem _ecbs;
    JobHandle _dependingHandle;

    public void AddDependingJobHandle(JobHandle handle) {
        _dependingHandle = JobHandle.CombineDependencies(_dependingHandle, handle);
    }

    protected override void OnCreate() {
        _ecbs = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnDestroy() { }

    [BurstCompile]
    struct TriggerJob : ITriggerEventsJob {
        [ReadOnly] public NativeSlice<RigidBody> Bodies;
        [ReadOnly] public ComponentDataFromEntity<CollisionInfoSettingComp> Settings;
        // public ComponentDataFromEntity<CollisionInfoComp> Infos;
		public BufferFromEntity<CollisionInfoComp> Infos;
		private CollisionInfoComp info;

		unsafe void hit(in CollisionInfoSettingComp setting,
            ref CollisionInfoComp info, in RigidBody body, in RigidBody opponent,
            Entity opponentEntity,
            OpponentType opponentType) {
                
            info.Opponent = opponentEntity;
            info.OpponentType = opponentType;

            if (setting.NeedPositionNormal) {
                if (opponent.Collider->Type == ColliderType.Terrain) {
                    info.Position = body.WorldFromBody.pos;
                    info.Normal = new float3(0, 1, 0);
                } else {
                    var input = new ColliderDistanceInput() {
                        Collider = opponent.Collider,
                        Transform = opponent.WorldFromBody,
                        MaxDistance = float.MaxValue,
                    };
                    body.CalculateDistance(input, out DistanceHit distanceHit);
                    info.Position = math.transform(body.WorldFromBody, distanceHit.Position);
                    info.Normal = -distanceHit.SurfaceNormal; // seems world coordinates.
                }
            }
        }

        public void Execute(TriggerEvent collisionEvent) {
            if (Settings.Exists(collisionEvent.Entities.EntityA)) {
                var setting = Settings[collisionEvent.Entities.EntityA];
                var opponentType = Settings.Exists(collisionEvent.Entities.EntityB) ? Settings[collisionEvent.Entities.EntityB].Type : OpponentType.None;
				// var info = new CollisionInfoComp { }; // Infos[collisionEvent.Entities.EntityA];
				var body = Bodies[collisionEvent.BodyIndices.BodyAIndex];
                var opponent = Bodies[collisionEvent.BodyIndices.BodyBIndex];
                hit(in setting, ref info, in body, in opponent,
                    collisionEvent.Entities.EntityB, opponentType);
                Infos[collisionEvent.Entities.EntityA].Add(info);
            }
            if (Settings.Exists(collisionEvent.Entities.EntityB)) {
                var setting = Settings[collisionEvent.Entities.EntityB];
                var opponentType = Settings.Exists(collisionEvent.Entities.EntityA) ? Settings[collisionEvent.Entities.EntityA].Type : OpponentType.None;
				// var info = new CollisionInfoComp { }; //Infos[collisionEvent.Entities.EntityB];
				var body = Bodies[collisionEvent.BodyIndices.BodyBIndex];
                var opponent = Bodies[collisionEvent.BodyIndices.BodyAIndex];
                hit(in setting, ref info, in body, in opponent,
                    collisionEvent.Entities.EntityA, opponentType);
                Infos[collisionEvent.Entities.EntityB].Add(info);
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle handle) {
        handle = JobHandle.CombineDependencies(_dependingHandle, handle);

        var stepPhysicsWorldSystem = World.GetOrCreateSystem<StepPhysicsWorld>();
        var buildPhysicsWorldSystem = World.GetOrCreateSystem<BuildPhysicsWorld>();
        var commandBuffer = _ecbs.CreateCommandBuffer().ToConcurrent();

        var job = new TriggerJob {
            Settings = GetComponentDataFromEntity<CollisionInfoSettingComp>(true /* readOnly */ ),
            Infos = GetBufferFromEntity<CollisionInfoComp>(false /* readOnly */ ),
            Bodies = buildPhysicsWorldSystem.PhysicsWorld.Bodies,
        };

        handle = job.Schedule(stepPhysicsWorldSystem.Simulation, ref buildPhysicsWorldSystem.PhysicsWorld, handle);

        _ecbs.AddJobHandleForProducer(handle);
        return handle;
    }
}