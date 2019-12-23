using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using Unity.Entities;
using Unity.Mathematics;
using Valve.VR;



public struct ControllerVals {
	public bool touchPadTouchPress;
	public bool touchPadTouchRelease;
	public bool touchPadClickPress;
	public bool touchPadClickRelease;
	public bool menuBtnPress;
	public bool menuBtnRelease;
	public bool connected;
}
public struct InputManagerComp : IComponentData{

	
	public ControllerVals rightXRController;
	public ControllerVals leftXRController;
	public float2 rotDelta; // newpos - oldpos
	public float2 lateralMovement;
	public float verticalMovement;
	public float2 zoomDelta;
	public bool menuClickDown;
	public bool menuClickUp;
	public bool menuToggleDown;
	public bool menuToggleUp;
}


public class KNInputManagerSystem : ComponentSystem
{
	public PlayerInput playerInputRight;
	public PlayerInput playerInputLeft;
	public KNInputSystem knInput;
	InputManagerComp imc;
	public InputManagerComp imcFalse = new InputManagerComp();
	public InputManagerComp imcUpdated;

	int devceCount;

	protected override void OnCreate(){
		knInput = new KNInputSystem();
		knInput.Enable();
		// devceCount = knInput.devices.Value.Count;
		World.EntityManager.CreateEntity(typeof(InputManagerComp));


		knInput.XRControllerRight.MenuBtnPress.performed += ctx => imc.rightXRController.menuBtnPress = true; //ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerRight.MenuBtnRelease.performed += ctx => imc.rightXRController.menuBtnRelease = true; //ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerRight.TouchpadTouchPress.performed += ctx => imc.rightXRController.touchPadTouchPress = true;//ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerRight.TouchpadTouchRelease.performed += ctx => imc.rightXRController.touchPadTouchPress = true; //ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerRight.TouchpadClickPress.performed += ctx => imc.rightXRController.touchPadClickPress = imc.menuClickDown = true;//ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerRight.TouchpadClickRelease.performed += ctx => imc.rightXRController.touchPadClickRelease = imc.menuClickUp = true;//ctx.ReadValue<float>() < 0.5f;

		knInput.XRControllerLeft.MenuBtnPress.performed += ctx => imc.leftXRController.menuBtnPress = true;//ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerLeft.MenuBtnRelease.performed += ctx => imc.leftXRController.menuBtnRelease = true;//ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerLeft.TouchpadTouchPress.performed += ctx => imc.leftXRController.touchPadTouchPress = true;//ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerLeft.TouchpadTouchRelease.performed += ctx => imc.leftXRController.touchPadTouchPress = true;//ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerLeft.TouchpadClickPress.performed += ctx => imc.leftXRController.touchPadClickPress = imc.menuClickDown = true;//ctx.ReadValue<float>() > 0.5f;
		knInput.XRControllerLeft.TouchpadClickRelease.performed += ctx => imc.leftXRController.touchPadClickRelease = imc.menuClickUp = true;//ctx.ReadValue<float>() <0.5f;

		//Keyboard, Mouse & Gamepad buttons
		knInput.KMJControls.UIClickBtnPress.performed += ctx => imc.menuClickDown = true;
		knInput.KMJControls.UIClickBtnRelease.performed += ctx => imc.menuClickUp = true;
		knInput.KMJControls.MenuTogglePress.performed += ctx => imc.menuToggleDown = true;
		knInput.KMJControls.MenuToggleRelease.performed += ctx => imc.menuToggleUp = true;

	}
    protected override void OnDestroy(){
		knInput.Disable();
	}

	protected override void OnUpdate() {

		imc.rotDelta = knInput.KMJControls.RotationDelta.ReadValue<Vector2>();
		imc.zoomDelta = knInput.KMJControls.ZoomDelta.ReadValue<Vector2>();
		imc.lateralMovement = knInput.KMJControls.LateralMovement.ReadValue<Vector2>();
		imc.verticalMovement = knInput.KMJControls.VerticalMovement.ReadValue<float>();
		// imc.menuClickDown = knInput.KMJControls.UIClickBtnPress.triggered || imc.menuClickDown;
		// imc.menuClickUp = knInput.KMJControls.UIClickBtnRelease.triggered || imc.menuClickUp;
		// imc.menuToggleDown = knInput.KMJControls.MenuTogglePress.triggered;
		// imc.menuToggleUp = knInput.KMJControls.MenuToggleRelease.triggered;

		imc.rightXRController.connected = knInput.XRControllerRight.Connected.ReadValue<float>() > 0.5f;

		imc.leftXRController.connected = knInput.XRControllerLeft.Connected.ReadValue<float>() > 0.5f;

		SetSingleton<InputManagerComp>(imc);
		imcUpdated = imc;
		imc = imcFalse;
	}
}
