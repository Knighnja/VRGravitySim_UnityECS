using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class ControllerBattery : MonoBehaviour
{
	public ETrackedControllerRole role;
	MaterialPropertyBlock materialPropertyBlock;
	ETrackedPropertyError err;
	uint deviceIndex;
	MeshRenderer meshRenderer;
	float batteryCharge;
	float f;

	void Start() {
		if (OpenVR.System == null) return;

		materialPropertyBlock = new MaterialPropertyBlock();
		err = new ETrackedPropertyError();

		meshRenderer = GetComponent<MeshRenderer>();
		deviceIndex = OpenVR.System.GetTrackedDeviceIndexForControllerRole(role);
		meshRenderer.GetPropertyBlock(materialPropertyBlock);

		StartCoroutine(UpdateBattery());
	}
    
    IEnumerator UpdateBattery(){
		while (Application.isPlaying) {

			f = OpenVR.System.GetFloatTrackedDeviceProperty(deviceIndex, ETrackedDeviceProperty.Prop_DeviceBatteryPercentage_Float, ref err);

			if (err == ETrackedPropertyError.TrackedProp_Success) {
				// Debug.Log("Battery level: " + f + " " + deviceIndex);
				materialPropertyBlock.SetFloat("Charge_", f);
				meshRenderer.SetPropertyBlock(materialPropertyBlock);
			}

			yield return new WaitForSeconds(5);
		}
	}
}
