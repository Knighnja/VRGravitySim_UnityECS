using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Unity.Entities;
using Unity.Mathematics;

public class VRInputModuleBase : BaseInputModule {
    //[SerializeField] private Pointer pointer = null;

    public PointerEventData Data { get; private set; } = null;
    public Camera cam = null;

    // public string rightControllerButton = "XRI_Right_Primary2DAxisClick";
    // public string leftControllerButton = "XRI_Left_Primary2DAxisClick";
	Vector2 camPos;
	GameManagerSystem gmsys;
	KNInputManagerSystem imsys;
	// InputManagerComp imc;

	protected override void Start() {
        Data = new PointerEventData(eventSystem);
        Data.position = camPos = new Vector2(cam.pixelWidth * 0.5f, cam.pixelHeight * 0.5f);
		gmsys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<GameManagerSystem>();
		imsys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<KNInputManagerSystem>();
	}


    public override void Process() {
		// imc = imsys.imcUpdated;

		if(gmsys.canvasCam == CanvasCam.nonVr){
			Data.position = Mouse.current.position.ReadValue(); //Input.mousePosition;
		} else {
			Data.position = camPos;
		}

        eventSystem.RaycastAll(Data, m_RaycastResultCache);
        Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);

        HandlePointerExitAndEnter(Data, Data.pointerCurrentRaycast.gameObject);

        ExecuteEvents.Execute(Data.pointerDrag, Data, ExecuteEvents.dragHandler);

		

		if (imsys.imcUpdated.menuClickDown) Press();
		if (imsys.imcUpdated.menuClickUp) Release();

		if (eventSystem.currentSelectedGameObject != null) {
			var data = GetBaseEventData();
			ExecuteEvents.Execute(eventSystem.currentSelectedGameObject, data, ExecuteEvents.updateSelectedHandler);
		} else {
			eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
		}
	}

    public void Press() {
        Data.pointerPressRaycast = Data.pointerCurrentRaycast;

        Data.pointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(Data.pointerPressRaycast.gameObject);
        Data.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(Data.pointerPressRaycast.gameObject);

        ExecuteEvents.Execute(Data.pointerPress, Data, ExecuteEvents.pointerDownHandler);
        ExecuteEvents.Execute(Data.pointerDrag, Data, ExecuteEvents.beginDragHandler);
    }

    public void Release() {
        GameObject pointerRelease = ExecuteEvents.GetEventHandler<IPointerClickHandler>(Data.pointerCurrentRaycast.gameObject);

        if (Data.pointerPress == pointerRelease)
            ExecuteEvents.Execute(Data.pointerPress, Data, ExecuteEvents.pointerClickHandler);

        ExecuteEvents.Execute(Data.pointerPress, Data, ExecuteEvents.pointerUpHandler);
        ExecuteEvents.Execute(Data.pointerDrag, Data, ExecuteEvents.endDragHandler);

        Data.pointerPress = null;
        Data.pointerDrag = null;

        Data.pointerCurrentRaycast.Clear();
    }

}