using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;


public enum OpponentType {
    None,
    Bouble
}

public struct CollisionInfoSettingComp : IComponentData {
    public bool NeedPositionNormal;
    public OpponentType Type;
}

public struct CollisionInfoComp : IBufferElementData {
    // public int HitGeneration;
    public Entity Opponent;
    public OpponentType OpponentType;
    public float3 Position;
    public float3 Normal;
}

public class CollisionInfoAuth : MonoBehaviour, IConvertGameObjectToEntity {
    public OpponentType Type;
    public bool NeedPositionNormal;

    public unsafe void Convert(Entity entity, EntityManager em, GameObjectConversionSystem conversionSystem) {
        em.AddComponentData(entity, new CollisionInfoSettingComp {
            NeedPositionNormal = NeedPositionNormal,
                Type = Type,
        });
		em.AddBuffer<CollisionInfoComp>(entity);
		// dstManager.AddComponentData(entity, new CollisionInfoComp { HitGeneration = 0, });
	}
}

