using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/* public struct GameManagerComp : IComponentData {
	public bool showMenu;
} */

public enum CanvasCam { right, left, nonVr }

[RequiresEntityConversion]
public class GameManagerAuth : MonoBehaviour, IConvertGameObjectToEntity {
	private static GameManagerAuth _instance;
	public static GameManagerAuth Instance{ get { return _instance; } }
	public CanvasCam canvasCam;
	public Canvas menu;
	public Transform baseMenuParent;
	// public Transform nonVRMenuParent;
	public Transform rightMenuParent;
	public Transform leftMenuParent;
	public Camera nonVrCam;
	public GameObject rightPointer;
	public GameObject leftPointer;
	public Transform vrBaseTrans;
	// public Transform hmdTrans;
	public bool showMenu = false;

	
	/* public string leftMenuButton = "XRI_Left_PrimaryButton";
	public string rightMenuButton = "XRI_Right_PrimaryButton";
	public string leftTouchButton = "XRI_Left_Primary2DAxisTouch";
	public string rightTouchButton = "XRI_Right_Primary2DAxisTouch";
	public string leftVRClick = "XRI_Left_Primary2DAxisClick";
	public string rightVRClick = "XRI_Right_Primary2DAxisClick"; */
	//private GameManagerSystem gmsys;
	// EntityManager _em;
	// Entity _e;
	private void Awake() {
		_instance = this;
	}
	public void ExitGame() {
		World.DefaultGameObjectInjectionWorld.QuitUpdate = true;
		Application.Quit();
	}
	public void Convert(Entity e, EntityManager em, GameObjectConversionSystem conversionSystem) {
		// em.AddComponentData(e, new GameManagerComp { });
		// GameManagerSystem.gma = this;
		// gmsys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<GameManagerSystem>();
		// em.SetComponentData(e, new GameManagerComp { showMenu = showMenu });
		// gmsys.e = e;
		// _em = em;
		// _e = e;
		var s = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<GameManagerSystem>();
		s.canvasCam = canvasCam;
		s.menu = menu;
		s.baseMenuParent = baseMenuParent;
		// Transform nonVRMenuParent;
		s.rightMenuParent = rightMenuParent;
		s.leftMenuParent = leftMenuParent;
		s.nonVrCam = nonVrCam;
		s.rightPointer = rightPointer;
		s.leftPointer = leftPointer;
		s.showMenu = showMenu;
		/* s.leftMenuButton = leftMenuButton;
		s.rightMenuButton = rightMenuButton;
		s.leftTouchButton = leftTouchButton;
		s.rightTouchButton = rightTouchButton;
		s.leftVRClick = leftVRClick;
		s.rightVRClick = rightVRClick; */
		s.vrBaseTrans = vrBaseTrans;
		// s.hmdTrans = hmdTrans;
		s.Init();

		Cursor.visible = showMenu;
		Cursor.lockState = (showMenu) ? CursorLockMode.None : CursorLockMode.Locked;
		menu.enabled = showMenu;
	}

}


public class GameManagerSystem : ComponentSystem {
	public CanvasCam canvasCam;
	public Canvas menu;
	public Transform baseMenuParent;
	// public Transform nonVRMenuParent;
	public Transform rightMenuParent;
	public Transform leftMenuParent;
	public Camera nonVrCam;
	
	public GameObject rightPointer;
	public GameObject leftPointer;
	public Transform vrBaseTrans;
	// public Transform hmdTrans;
	public bool showMenu;
	/* public string leftMenuButton;
	public string rightMenuButton;
	public string leftTouchButton;
	public string rightTouchButton;
	public string leftVRClick;
	public string rightVRClick; */
	
	public Camera rightCam { get; set; }
	public Camera leftCam { get; set; }
	public Transform rcTrans { get; set; }
	public Transform lcTrans { get; set; }

	Vector3 startControllerPosL;
	Vector3 startControllerPosR;
	Vector3 startRootPos;
	bool posDragR = false;
	bool posDragL = false;
	bool scaleDrag = false;
	float startScaleDist;
	float scaleDist;
	Vector3 startScale;
	Transform tmpScaleParent;
	Transform oldScaleParent;

	InputManagerComp imc;
	//private GameManagerSystem gmsys;
	// EntityManager _em;
	// Entity _e;
	public void Init(){
		rightCam = rightPointer.GetComponent<Camera>();
		leftCam = leftPointer.GetComponent<Camera>();
		rcTrans = rightMenuParent.parent.parent;
		lcTrans = leftMenuParent.parent.parent;
		rightMenuParent.parent.Rotate(60, 0, 0, Space.Self);
		leftMenuParent.parent.Rotate(60, 0, 0, Space.Self);
	}

	public void ResetTrans(Transform trans) {
		trans.localPosition = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale = Vector3.one;
	}
	public void SwitchCam(CanvasCam cc) {
		// Debug.Log("Switching canvas cam to: " + cc);
		this.canvasCam = cc;
		switch (cc) {
			case CanvasCam.nonVr:
				menu.worldCamera = nonVrCam;
				break;
			case CanvasCam.left:
				menu.worldCamera = leftCam;
				break;
			case CanvasCam.right:
				menu.worldCamera = rightCam;
				break;
		}
	}

	public bool ToggleMenuEnabled {
		set {
			if (value) { // on button down

				showMenu = !showMenu;
				if (showMenu) {
					menu.enabled = true;

					switch (canvasCam) {
						case CanvasCam.nonVr:
							menu.transform.SetParent(baseMenuParent);
							break;
						case CanvasCam.left:
							menu.transform.SetParent(leftMenuParent);
							break;
						case CanvasCam.right:
							menu.transform.SetParent(rightMenuParent);
							break;
					}
					ResetTrans(menu.transform);
				}
				Cursor.visible = showMenu;
				Cursor.lockState = (showMenu) ? CursorLockMode.None : CursorLockMode.Locked;

				// _em.SetComponentData(_e, new GameManagerComp { showMenu = showMenu });

			} else { // on button up
				if (showMenu) {
					menu.transform.SetParent(baseMenuParent);
				} else {
					EventSystem.current.SetSelectedGameObject(null);
					menu.enabled = false;
					PresetsMenu.Instance.presetCanvas.enabled = false;
					rightPointer.SetActive(false);
					leftPointer.SetActive(false);
				}
			}
		}
	}

	
	protected override void OnUpdate() {
		imc = GetSingleton<InputManagerComp>();

		if(posDragR && posDragL){
			if(scaleDrag == false){
				scaleDrag = true;
				startScaleDist = math.distance(rcTrans.localPosition, lcTrans.localPosition);
				// initiate scale draging with both controllers.
				if(tmpScaleParent == null) tmpScaleParent = new GameObject("tmp").transform;
				// position the tmp parent half way between the starting position of the controllers.
				tmpScaleParent.position = rcTrans.position + Vector3.Normalize(lcTrans.position - rcTrans.position) * (math.distance(rcTrans.position,lcTrans.position) * 0.5f);
				tmpScaleParent.localScale = Vector3.one;
				// save old parent & assign temporary parent.
				oldScaleParent = vrBaseTrans.parent;
				vrBaseTrans.SetParent(tmpScaleParent, true);
				
				startScale = tmpScaleParent.localScale;
			} else {
				scaleDist = math.distance(rcTrans.localPosition, lcTrans.localPosition);
				var distPercent = (startScaleDist != 0 && scaleDist != 0) ? startScaleDist / scaleDist : 1;
				// Debug.Log("dist: " + distPercent);
				tmpScaleParent.localScale = startScale * distPercent;
				startScaleDist = scaleDist;
				startScale = tmpScaleParent.localScale;
			}
			// so movement drag is not used if one button is released first
			startRootPos = vrBaseTrans.position;
			startControllerPosL = leftPointer.transform.position;
			startControllerPosR = rightPointer.transform.position;
		} else {
			if (posDragL) {
				vrBaseTrans.position = startRootPos - (leftPointer.transform.position - startControllerPosL);
				startControllerPosL = leftPointer.transform.position;
				startRootPos = vrBaseTrans.position;
			}
			if (posDragR) {
				vrBaseTrans.position = startRootPos - (rightPointer.transform.position - startControllerPosR);
				startControllerPosR = rightPointer.transform.position;
				startRootPos = vrBaseTrans.position;
			}
			if (scaleDrag) {
				// scale drag has ended so reparent
				scaleDrag = false;
				vrBaseTrans.SetParent(oldScaleParent, true);
			}
		}
		if (imc.leftXRController.menuBtnPress) {
			SwitchCam(CanvasCam.left);
			ToggleMenuEnabled = true;
		}
		if (imc.rightXRController.menuBtnPress) {
			SwitchCam(CanvasCam.right);
			ToggleMenuEnabled = true;
		}
		if (imc.rightXRController.menuBtnRelease || imc.leftXRController.menuBtnRelease) {
			ToggleMenuEnabled = false;
		}

		if (menu.enabled) {
			// activate laser if menu is active
			if (imc.rightXRController.touchPadTouchPress) {
				SwitchCam(CanvasCam.right);
				rightPointer.SetActive(true);
				leftPointer.SetActive(false);
			}
			if (imc.leftXRController.touchPadTouchPress) {
				SwitchCam(CanvasCam.left);
				rightPointer.SetActive(false);
				leftPointer.SetActive(true);
			}
			// deactivate menu laser
			if (imc.rightXRController.touchPadTouchRelease) {
				EventSystem.current.SetSelectedGameObject(null);
				menu.worldCamera = null;
				rightPointer.SetActive(false);
			}
			if (imc.leftXRController.touchPadTouchRelease) {
				EventSystem.current.SetSelectedGameObject(null);
				menu.worldCamera = null;
				leftPointer.SetActive(false);
			}
		} else {
			// drag scene position
			if (imc.leftXRController.touchPadClickPress) {
				startControllerPosL = leftPointer.transform.position;
				startRootPos = vrBaseTrans.position;
				posDragL = true;
			}
			if (imc.leftXRController.touchPadClickRelease) {
				posDragL = false;
			}
			if (imc.rightXRController.touchPadClickPress) {
				startControllerPosR = rightPointer.transform.position;
				startRootPos = vrBaseTrans.position;
				posDragR = true;
			}
			if (imc.rightXRController.touchPadClickRelease) {
				posDragR = false;
			}
		}


		// toggle menu by keyboard
		if (imc.menuToggleDown) {
			SwitchCam(CanvasCam.nonVr);
			ToggleMenuEnabled = true;
		}
		if (imc.menuToggleUp) {
			ToggleMenuEnabled = false;
		}
	}
}