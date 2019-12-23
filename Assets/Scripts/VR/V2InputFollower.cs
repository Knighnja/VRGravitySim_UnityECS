using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2InputFollower : MonoBehaviour {
    public enum AxisControl { x, y, z, xflipped, yflipped, zflipped }
    public float movementRange = 0.1f;
	public AxisControl xControlsAxis = AxisControl.x;
    public AxisControl yControlsAxis = AxisControl.y;
    private Vector3 pos;
    private void Start() {
		pos = transform.localPosition;
	}
    public Vector2 trackpadInput {
        set {
			//trackpadInput_ = Vector3.zero;
			switch (xControlsAxis) {
            case AxisControl.x:
                pos.x = value.x;
                break;
            case AxisControl.y:
                pos.y = value.x;
                break;
            case AxisControl.z:
                pos.z = value.x;
                break;
            case AxisControl.xflipped:
                pos.x = -value.x;
                break;
            case AxisControl.yflipped:
                pos.y = -value.x;
                break;
            case AxisControl.zflipped:
                pos.z = -value.x;
                break;
            }
            switch (yControlsAxis) {
            case AxisControl.x:
                pos.x = value.y;
                break;
            case AxisControl.y:
                pos.y = value.y;
                break;
            case AxisControl.z:
                pos.z = value.y;
                break;
            case AxisControl.xflipped:
                pos.x = -value.y;
                break;
            case AxisControl.yflipped:
                pos.y = -value.y;
                break;
            case AxisControl.zflipped:
                pos.z = -value.y;
                break;
            }
            transform.localPosition = pos * movementRange;
        }
    }
}