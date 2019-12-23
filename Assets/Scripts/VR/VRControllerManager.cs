using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.Entities;

public class VRControllerManager : MonoBehaviour {
    // public string rightControllerName = "OpenVR Controller - Right";
    // public string leftControllerName = "OpenVR Controller - Left";

    public GameObject nonVR_BaseGO;
    public GameObject VR_BaseGO;

    public string[] controllerNames;
    public string vrDeviceName;
    /* public bool rightConnected { get; set; }
    public bool leftConnected { get; set; } */

    float currentWaitTime = 1;
    float waitTime = 3;
	GameManagerSystem gmsys;
	KNInputManagerSystem imsys;
	// InputManagerComp imc;

	void CheckControllers() {
		// imc = imsys.imcUpdated;
		// controllerNames = Input.GetJoystickNames();
		// rightConnected = leftConnected = false;

		/* foreach (var item in controllerNames) {
            if (item.Equals(rightControllerName)) rightConnected = true;
            if (item.Equals(leftControllerName)) leftConnected = true;
        } */
		// Debug.Log("connected: " + imsys.imc.rightXRController.connected);

		if (imsys.imcUpdated.rightXRController.connected == false && imsys.imcUpdated.leftXRController.connected == false && gmsys.canvasCam != CanvasCam.nonVr) {
			// Debug.Log("" + rightConnected + " " + leftConnected);
			gmsys.SwitchCam(CanvasCam.nonVr);
        }

        /* if (GameManagerAuth.Instance.canvasCam == GameManagerAuth.CanvasCam.nonVr) {
            if (XRDevice.isPresent) {
                if (VR_BaseGO.activeSelf == false) {
                    if (XRSettings.enabled == false) XRSettings.enabled = true;
                    nonVR_BaseGO.SetActive(false);
                    VR_BaseGO.SetActive(true);
                }
            } else {
                if (nonVR_BaseGO.activeSelf == false) {
                    nonVR_BaseGO.SetActive(true);
                    VR_BaseGO.SetActive(false);
                }
            }
        } */
        //vrDeviceName = XRSettings.loadedDeviceName; //vrDeviceName.Equals("") == false

    }

    private void Start() {
		gmsys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<GameManagerSystem>();
		imsys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<KNInputManagerSystem>();
		EnableVR(XRDevice.isPresent);

        XRDevice.deviceLoaded += (s) => {
            if (s.Equals("OpenVR")) EnableVR(true);
        };
    }

    void EnableVR(bool en) {
        VR_BaseGO.SetActive(en);
        nonVR_BaseGO.SetActive(!en);
    }

    private void Update() {
        if (currentWaitTime <= 0) {
            currentWaitTime += waitTime;
            CheckControllers();
        } else {
            currentWaitTime -= Time.deltaTime;
        }
    }
}