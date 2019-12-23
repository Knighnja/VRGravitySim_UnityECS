using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;

public struct CamControllerComp : IComponentData {
    public float force;
    public float zoomSpeed;
    public float torque;
}

public struct CamControllerTag : IComponentData { }

public class CamControllerRefs : Component {
    public Camera overheadCam;
    public Camera firstPersonCam;
    public CamControllerAuth.CamType camType;
}

[RequiresEntityConversion]
public class CamControllerAuth : MonoBehaviour, IConvertGameObjectToEntity {

    public enum CamType {
        freeCam,
        overhead,
        overheadLocked
    }

    public float force = 100;
    public float zoomSpeed = 10;
    public float torque = 1000;

    public CamType camType;

    public Camera freecam;
    public Camera overheadcam;

	public Transform menuParent;

	private ECSCopyTransToGOSystem cpysys;

    public static Entity entity { get; set; }

    public void Convert(Entity e, EntityManager em, GameObjectConversionSystem conversionSystem) {

        em.AddComponentData(e, new CamControllerComp {
            force = force,
                zoomSpeed = zoomSpeed,
                torque = torque
        });
        em.AddComponentData(e, new ECSCopyTransToGO { });
        em.AddComponentData(e, new CamControllerTag { });
        em.AddComponentObject(e, new CamControllerRefs {
            overheadCam = overheadcam,
                firstPersonCam = freecam,
                camType = camType
        });
		em.AddComponentData(e, new RotationEulerXYZ { });

		cpysys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<ECSCopyTransToGOSystem>();

        entity = e;

        cpysys.AddTransform(transform);

		menuParent.SetParent(transform);
	}

    private void OnDestroy() {
        cpysys.RemoveTransform(transform);
    }
}

[UpdateAfter(typeof(KNInputManagerSystem))]
public class CamControllerSystem : ComponentSystem {

    private float3 lv; // linear velocity
    private float t, angleX, angleY, force;
    private bool camSwithed = false;
	GameManagerSystem gmsys;
	float maxYRads = 6.28319f; // 360 degrees
	float maxXRads = 1.39626f;
	InputManagerComp imc;


	protected override void OnCreate(){
		gmsys = World.GetOrCreateSystem<GameManagerSystem>();
	}
    

    protected override void OnUpdate() {
		imc = GetSingleton<InputManagerComp>();

		Entities.WithAll<CamControllerTag>().ForEach((CamControllerRefs refs, ref CamControllerComp ccc, ref LocalToWorld lw, ref PhysicsVelocity pv, ref RotationEulerXYZ rot) => {

            if(gmsys.showMenu) return;
            
			t = Time.DeltaTime;

            lv = float3.zero;
			// Debug.Log(imc.lateralMovement + "  " + imc.verticalMovement);

            /* if(Keyboard.current.rightBracketKey.wasPressedThisFrame){
                switch (refs.camType) {
                case CamControllerAuth.CamType.freeCam:
                    refs.camType = CamControllerAuth.CamType.overhead;
                    break;
                case CamControllerAuth.CamType.overhead:
                    refs.camType = CamControllerAuth.CamType.overheadLocked;
                    break;
                case CamControllerAuth.CamType.overheadLocked:
                    refs.camType = CamControllerAuth.CamType.freeCam;
                    break;
                }
                camSwithed = true;
            }

            if(Keyboard.current.leftBracketKey.wasPressedThisFrame){
                switch (refs.camType) {
                case CamControllerAuth.CamType.freeCam:
                    refs.camType = CamControllerAuth.CamType.overheadLocked;
                    break;
                case CamControllerAuth.CamType.overhead:
                    refs.camType = CamControllerAuth.CamType.freeCam;
                    break;
                case CamControllerAuth.CamType.overheadLocked:
                    refs.camType = CamControllerAuth.CamType.overhead;
                    break;
                }
                camSwithed = true;
            } */

            if (camSwithed) {
                if (refs.camType == CamControllerAuth.CamType.freeCam) {
                    refs.firstPersonCam.enabled = true;
                    refs.overheadCam.enabled = false;
                } else {
                    refs.overheadCam.enabled = true;
                    refs.firstPersonCam.enabled = false;
					rot.Value = float3.zero;
				}
                camSwithed = false;
            }

			lv = float3.zero;
			force = ccc.force * t;

			if(math.any( imc.lateralMovement != float2.zero)){
				lv += lw.Forward * imc.lateralMovement.y * force;
				lv += lw.Right * imc.lateralMovement.x * force;
			}

            if(imc.verticalMovement != 0){
				lv += lw.Up * imc.verticalMovement * force;
			}

            pv.Linear += lv;

            switch (refs.camType) {
				case CamControllerAuth.CamType.freeCam: {
						angleX += -imc.rotDelta.y * ccc.torque * t;
						angleY += imc.rotDelta.x * ccc.torque * t;

						if (angleX > maxXRads) { angleX = maxXRads; }
						if (angleX < -maxXRads) { angleX = -maxXRads; }
						if (angleY > maxYRads) { angleY -= maxYRads; }
						if (angleY < -maxYRads) { angleY += maxYRads; }

						if (math.any( imc.rotDelta != float2.zero)) {
							rot.Value = new float3(angleX, angleY, 0); 
						}
						imc.zoomDelta = 0; // no zoom in freecam.

						break;
					}
				case CamControllerAuth.CamType.overhead: {
						angleY += imc.rotDelta.x * ccc.torque * t;

						if (angleY > maxYRads) { angleY -= maxYRads; }
						if (angleY < -maxYRads) { angleY += maxYRads; }

						if (imc.rotDelta.x != 0) {
							rot.Value = new float3(0, angleY, 0);
						}

						break;
					}
				/* case CamControllerAuth.CamType.overheadLocked: {
						break;
					} */
			}

            if (imc.zoomDelta.y != 0) {

                float3 fcam = refs.firstPersonCam.transform.position;
                float3 ocam = refs.overheadCam.transform.position;

                if (math.distance(fcam, ocam) > ccc.zoomSpeed * imc.zoomDelta.y) {
                    refs.overheadCam.transform.position = ocam - math.normalize(ocam - fcam) * (ccc.zoomSpeed * imc.zoomDelta.y);
                }
            }

        });
    } // onupdate
}