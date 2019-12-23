using System;
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
public struct SpawnerRndAreaComp : IComponentData {
	public float4 colorBaseTiny;
	public float4 colorEmitTiny;
	public float4 colorBaseSmall;
	public float4 colorEmitSmall;
	public float4 colorBaseMedium;
	public float4 colorEmitMedium;
	public float4 colorBaseLarge;
	public float4 colorEmitLarge;
	public float4 colorBaseHuge;
	public float4 colorEmitHuge;
	public float4 colorBaseSuperMassive;
	public float4 colorEmitSuperMassive;
	public float tinyRange;
	public float smallRange;
	public float mediumRange;
	public float largeRange;
	public float hugeRange;
	public float superRange;
	public Entity entity;
}

public class SpawnerRndAreaManager : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs {
	private static SpawnerRndAreaManager instance;
	public static SpawnerRndAreaManager Instance { get { if (instance == null) instance = GameObject.FindObjectOfType<SpawnerRndAreaManager>(); return instance; } }
	public GameObject prefab;
	public EntityManager em;
	// public bool showBounds = true;
	// public float delayedUpdateTime = 1;
	// public float currentUpdateTime = 0;
	public Color colorBaseTiny;
	public Color colorEmitTiny;
	public Color colorBaseSmall;
	public Color colorEmitSmall;
	public Color colorBaseMedium;
	public Color colorEmitMedium;
	public Color colorBaseLarge;
	public Color colorEmitLarge;
	public Color colorBaseHuge;
	public Color colorEmitHuge;
	public Color colorBaseSuperMassive;
	public Color colorEmitSuperMassive;

	float3 rtf, rtb, ltf, ltb, rbf, rbb, lbf, lbb;

	SpawnerRndAreaSystem sys;

	private void Start() {
		sys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<SpawnerRndAreaSystem>();
	}

	/* private void Update() {
		if (currentUpdateTime <= 0) {
			currentUpdateTime += delayedUpdateTime;
		} else {
			currentUpdateTime -= Time.deltaTime;
		}
	} */

	public void Convert(Entity e, EntityManager em, GameObjectConversionSystem conversionSystem) {

		var sys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<SpawnerRndAreaSystem>();

		sys._prefabEntity = conversionSystem.GetPrimaryEntity(prefab);

		var comp = new SpawnerRndAreaComp {
			colorBaseTiny = colorBaseTiny.ToFloat4(),
			colorEmitTiny = colorEmitTiny.ToFloat4(),
			colorBaseSmall = colorBaseSmall.ToFloat4(),
			colorEmitSmall = colorEmitSmall.ToFloat4(),
			colorBaseMedium = colorBaseMedium.ToFloat4(),
			colorEmitMedium = colorEmitMedium.ToFloat4(),
			colorBaseLarge = colorBaseLarge.ToFloat4(),
			colorEmitLarge = colorEmitLarge.ToFloat4(),
			colorBaseHuge = colorBaseHuge.ToFloat4(),
			colorEmitHuge = colorEmitHuge.ToFloat4(),
			colorBaseSuperMassive = colorBaseSuperMassive.ToFloat4(),
			colorEmitSuperMassive = colorEmitSuperMassive.ToFloat4(),
			tinyRange = sys.sd.defaultGrav,
			smallRange = float.MaxValue,
			mediumRange = float.MaxValue,
			largeRange = float.MaxValue,
			hugeRange = float.MaxValue,
			superRange = float.MaxValue,
			entity = e
		};

		em.AddComponentData(e, comp);
		this.em = em;

	}

	public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs) {
		referencedPrefabs.Add(prefab);
	}

	/* public void RefreshBoubles() {
		sys.sd.init = true;
		em.DestroyEntity(em.CreateEntityQuery(typeof(BoubleComp)));
		
	} */
}

public class SpawnerRndAreaSystem : JobComponentSystem {
	public struct SpawnerData {
		public float startingMaxVel;

		public float cylinderRadius;
		public float cylinderHeight;

		public float defaultGrav;
		public float rangeMult;
		public int totalCount;
		public float gravUpdateDelay;
		public bool rangeMultChanged;
		public bool absorb;
		public bool bounce;
		public bool explode;
		public float explosionLifeTime;
		public float explosionEndScale;
	}

	public SpawnerData sd = new SpawnerData {
		startingMaxVel = 1f,
		cylinderRadius = 100f,
		cylinderHeight = 50f,
		defaultGrav = 50,
		rangeMult = 3,
		gravUpdateDelay = 0,
		totalCount = 1000,
		explosionLifeTime = 0.25f,
		explosionEndScale = 5f,
		rangeMultChanged = true,
		explode = true,
		bounce = true,
		absorb = true,
	};
	public Entity _prefabEntity;
	public UnityEngine.Material disolveMat;
	public bool init = true;
	public EntityQuery boubleQuery;
	// public int count;

	BeginSimulationEntityCommandBufferSystem _ecbs;
	NativeArray<float3> posList;
	// public static int totalCount;
	Random _random;
	EntityManager em;
	int count;
	
	BoubleSystem bubSys;
	float2 rndDir;
	float3 rndPos;
	int createCount;

	protected override void OnCreate() {
		base.OnCreate();
		posList = new NativeArray<float3>(10000, Allocator.Persistent);
		_ecbs = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
		em = World.EntityManager;
		_random = new Random(85243052);
		bubSys = World.GetOrCreateSystem<BoubleSystem>();
		boubleQuery = em.CreateEntityQuery(typeof(BoubleComp));
	}

	protected override void OnDestroy(){
		base.OnDestroy();
		posList.Dispose();
	}

	[BurstCompile]
	public struct Joby : IJobParallelFor {
		public EntityCommandBuffer.Concurrent ecb;
		public SpawnerRndAreaComp f;
		public SpawnerData sd;
		// int count;
		public Entity prefabEntity;
		public bool absorb;
		public bool bounce;
		public float bubFrac;
		public NativeArray<float3> posList;
		

		public void Execute(int i) {
			var e = ecb.Instantiate(i, prefabEntity);
			ecb.SetComponent(i, e, new Translation { Value = posList[i] });
			// ecb.SetComponent(i, e, new Rotation { Value = quaternion.identity }); //LookRotation(_random.NextFloat3Direction(), math.up()) });
			ecb.AddComponent(i, e, new Scale { Value = 1 });
			ecb.AddComponent(i, e, new MaterialBaseColor { });
			ecb.AddComponent(i, e, new MaterialEmitColor { });
		}
	}

	protected override JobHandle OnUpdate(JobHandle handle) {

		if (init && count > 0) {
			em.DestroyEntity(boubleQuery);
			count = 0;
			return handle;
		}

		count = boubleQuery.CalculateEntityCount();
		var f = GetSingleton<SpawnerRndAreaComp>();

		if (sd.rangeMultChanged) {
			List<float> ranges = new List<float>();
			ranges.Add(sd.defaultGrav);
			for (int i = 1; i < 6; i++) {
				ranges.Add(ranges[i - 1] * sd.rangeMult);
			}
			f.smallRange = ranges[1];
			f.mediumRange = ranges[2];
			f.largeRange = ranges[3];
			f.hugeRange = ranges[4];
			f.superRange = ranges[5];
			ranges.Clear();
			sd.rangeMultChanged = false;
			SetSingleton<SpawnerRndAreaComp>(f);
		}

		createCount = sd.totalCount - count;

		for (int i = 0; i < createCount; i++) {
			rndDir = _random.NextFloat2Direction();
			rndPos.x = rndDir.x;
			rndPos.y = 0;
			rndPos.z = rndDir.y;
			rndPos *= init ? _random.NextFloat(0, sd.cylinderRadius) : sd.cylinderRadius;
			rndPos.y = _random.NextFloat(-sd.cylinderHeight, sd.cylinderHeight);
			posList[i] = rndPos;
		}

		handle = new Joby {
			ecb = _ecbs.CreateCommandBuffer().ToConcurrent(),
			f = f, sd = sd,
			prefabEntity = _prefabEntity,
			absorb = sd.absorb,
			bounce = sd.bounce, 
			posList = posList,
			bubFrac = .5f / BoubleAuth._grad
		}.Schedule(createCount, 10, handle);

		_ecbs.AddJobHandleForProducer(handle);

		init = false;

		return handle;
	}

}