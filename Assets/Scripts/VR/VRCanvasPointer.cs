using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRCanvasPointer : MonoBehaviour {
    public EventSystem eventSystem;
    //public StandaloneInputModule inputModule;
    private LineRenderer lineRenderer;
    public float defaultLength;

    Vector3 endPos;
    Vector3[] points = new Vector3[2];
    float dist;
    PointerEventData ped;
    List<RaycastResult> raycastResults = new List<RaycastResult>();
    RaycastResult closest = new RaycastResult();
    bool foundHit;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        ped = new PointerEventData(eventSystem);
		Camera cam = GetComponent<Camera>();
		ped.position = new Vector2(cam.pixelWidth * 0.5f, cam.pixelHeight * 0.5f);
	}

    void Update() {
        raycastResults.Clear();
        
        eventSystem.RaycastAll(ped, raycastResults);

        dist = defaultLength;

        foundHit = false;
        closest.gameObject = null;

        foreach (var item in raycastResults) {
            if (!item.gameObject) continue;

            closest = item;
            foundHit = true;
            break;
        }

        if (foundHit)
            dist = Mathf.Clamp(closest.distance, 0, defaultLength);

        endPos = (closest.gameObject != null) ? closest.worldPosition : transform.position + transform.forward * dist;

		// drag is happening
		if (eventSystem) {
			points[0] = transform.position;
			points[1] = endPos;
			lineRenderer.SetPositions(points);
		}
	}
}