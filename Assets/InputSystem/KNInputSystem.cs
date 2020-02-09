// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/KNInputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @KNInputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @KNInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KNInputSystem"",
    ""maps"": [
        {
            ""name"": ""XRControllerRight"",
            ""id"": ""15f8a180-44f3-4692-9d00-41dd26e51e91"",
            ""actions"": [
                {
                    ""name"": ""MenuBtnPress"",
                    ""type"": ""Button"",
                    ""id"": ""7c906464-68fd-4ee4-81c6-a170e721d7ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MenuBtnRelease"",
                    ""type"": ""Button"",
                    ""id"": ""5b74160e-a1a5-4737-b385-143325cb87f9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""TouchpadTouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""b1e61ed0-f094-47e8-aee2-090a74a4da10"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchpadTouchRelease"",
                    ""type"": ""Button"",
                    ""id"": ""870d7b2f-efda-47cb-99ab-46e89de068bc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""TouchpadClickPress"",
                    ""type"": ""Button"",
                    ""id"": ""69498e68-9fc9-4e8e-aaba-879aca9cec25"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchpadClickRelease"",
                    ""type"": ""Button"",
                    ""id"": ""d2da457b-b0eb-4d56-93e5-1b7fdd493ece"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Connected"",
                    ""type"": ""Button"",
                    ""id"": ""44cebfdc-de11-4c15-b9c6-f96759de5d1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b795c623-b3f3-4b2d-9837-a654ad6f59d3"",
                    ""path"": ""<ViveWand>{RightHand}/primary"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuBtnPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""704c88bd-a878-425d-a21d-f238c02e8090"",
                    ""path"": ""<ViveWand>{RightHand}/primary"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuBtnRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e95428c-6db1-4ef2-9e3a-9d927bc90607"",
                    ""path"": ""<ViveWand>{RightHand}/trackpadTouched"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchpadTouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cea4f46-03a6-4454-8912-6034731f0e20"",
                    ""path"": ""<ViveWand>{RightHand}/trackpadTouched"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchpadTouchRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39d8c844-eb74-4d31-8f55-1b9749830ce8"",
                    ""path"": ""<ViveWand>{RightHand}/trackpadPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchpadClickPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00666a04-281f-4f14-a0d3-281bc8a7b412"",
                    ""path"": ""<ViveWand>{RightHand}/trackpadPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchpadClickRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cda4ef6-86c9-48bd-bca6-3829674baa78"",
                    ""path"": ""<ViveWand>{RightHand}/isTracked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Connected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""XRControllerLeft"",
            ""id"": ""52a0cfcf-faa4-413e-8c8c-b1a1792295a8"",
            ""actions"": [
                {
                    ""name"": ""MenuBtnPress"",
                    ""type"": ""Button"",
                    ""id"": ""53b12015-0ced-4af2-be6b-a10848159b60"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MenuBtnRelease"",
                    ""type"": ""Button"",
                    ""id"": ""d36fdfde-3e89-4a76-9bc7-1807cc80659b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""TouchpadTouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""6c10c15d-71b9-47ad-8d28-5eea38386f69"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchpadTouchRelease"",
                    ""type"": ""Button"",
                    ""id"": ""0f39f847-cf45-47e3-9459-c56fded3265e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""TouchpadClickPress"",
                    ""type"": ""Button"",
                    ""id"": ""ad296b67-51a6-4f52-95d8-895c66f085fc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchpadClickRelease"",
                    ""type"": ""Button"",
                    ""id"": ""ee70df42-b27b-4e10-b7e7-ac1f3a3a0a95"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Connected"",
                    ""type"": ""Button"",
                    ""id"": ""e663694a-0f6d-40e5-81b3-c733b81c8ebc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b3a30911-9e9c-42e6-af83-84221f1cc731"",
                    ""path"": ""<ViveWand>{LeftHand}/primary"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuBtnPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d082a388-efd1-435d-a2eb-aab9fa270249"",
                    ""path"": ""<ViveWand>{LeftHand}/primary"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuBtnRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09ce4db1-7680-4294-be32-38cdc1b5b4e7"",
                    ""path"": ""<ViveWand>{LeftHand}/trackpadTouched"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchpadTouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb711385-26c1-446b-b78a-d697e8f54763"",
                    ""path"": ""<ViveWand>{LeftHand}/trackpadTouched"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchpadTouchRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25bfada3-7da9-46af-8264-8bfc7ba41dac"",
                    ""path"": ""<ViveWand>{LeftHand}/trackpadPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchpadClickPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0fba913-ca71-4f8b-95aa-348fe2bc3a2e"",
                    ""path"": ""<ViveWand>{LeftHand}/trackpadPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchpadClickRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a506fee-a2f3-47d4-a4f0-e48207eb3c75"",
                    ""path"": ""<ViveWand>{LeftHand}/isTracked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Connected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""KMJControls"",
            ""id"": ""0c57a12b-855f-4aff-9da2-bcbc32c34eca"",
            ""actions"": [
                {
                    ""name"": ""LateralMovement"",
                    ""type"": ""Value"",
                    ""id"": ""5cb67ffb-12a0-4b3a-b653-420831feda1c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VerticalMovement"",
                    ""type"": ""Value"",
                    ""id"": ""51169537-fc58-41a7-bded-1309552fbd68"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationDelta"",
                    ""type"": ""Value"",
                    ""id"": ""c5e9e73d-5979-4e2a-8b11-f99f316efbf3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomDelta"",
                    ""type"": ""Value"",
                    ""id"": ""66b36f90-94a4-425a-924f-9fa423494b6a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UIClickBtnPress"",
                    ""type"": ""Value"",
                    ""id"": ""0a556ef7-7d80-42a9-9274-33ad1d396758"",
                    ""expectedControlType"": ""Digital"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""UIClickBtnRelease"",
                    ""type"": ""Value"",
                    ""id"": ""3a58ef10-a1c9-4b47-9f6b-d9dbd2c0f553"",
                    ""expectedControlType"": ""Digital"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""MenuTogglePress"",
                    ""type"": ""Button"",
                    ""id"": ""5fae2556-13fc-41a3-8b50-fe492c56a344"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MenuToggleRelease"",
                    ""type"": ""Button"",
                    ""id"": ""47a376d0-069a-40ac-9863-3ff945360672"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dadcb007-b6a7-4c3c-a15f-48dc9de48bf3"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector Keys"",
                    ""id"": ""a9e9fca9-bb81-47a2-8bd8-eaa2a8b1d98f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1b91f9ff-2eb6-4fe5-856b-89c084fbc4ed"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fada0f4c-cffe-4693-a408-5320ee700bcc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e178ebe6-60b7-4e4e-9adb-b4e048c49786"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""96e15e3d-4f43-4dfe-99f7-a12a81c2eb09"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keys"",
                    ""id"": ""21961ac0-95e9-48d2-ae50-2097935d841a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d8f62559-4749-474f-99c9-3ea1dcd47dcb"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9c6aba52-c01f-4c65-884e-9a175140a6cd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""0f963559-2294-45f7-9e54-8c77bb4d1c4c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1c047b90-09c6-4c4f-8b4d-b0cccf032fd8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8585d71a-d726-44b2-8624-3d5314ae6372"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""58635295-7b76-4d70-95a7-13167ba60fb4"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3219aa7a-1d27-4e97-926c-e59be7ed29aa"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9157a72a-4dc1-4147-a2de-1ca02e1ba953"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""6489211a-415a-4c71-9ba8-243e19db7df1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomDelta"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c40481d2-97a3-4300-857d-75163441cd3f"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9058ecb3-d025-411c-80f9-514795206e62"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f393f0bc-8925-4c84-9616-3309cd5d70c8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIClickBtnPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1608f50-df75-4959-948a-11563e67e932"",
                    ""path"": ""<XRController>{LeftHand}/touchpadClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIClickBtnPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2591d1c3-588c-4d1a-bc4f-d6dc28593047"",
                    ""path"": ""<XRController>{RightHand}/touchpadClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIClickBtnPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""557fb814-bb7b-4fab-9e2d-3780d7112b9b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIClickBtnRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb31be91-8388-49e6-a43f-dcaf68606e73"",
                    ""path"": ""<XRController>{LeftHand}/touchpadClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIClickBtnRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82d8440d-04ae-4ae6-b9ff-f939685b77ed"",
                    ""path"": ""<XRController>{RightHand}/touchpadClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIClickBtnRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d547c78-6805-4cf1-9e8e-dc8d6d132061"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuTogglePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf04dedd-17ee-47ec-b431-a050f9f58026"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuTogglePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd1c2ef1-3be7-494e-8e94-c13c8d31bec1"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuToggleRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e309c8cb-6447-4f0a-94c0-310502ffd34e"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuToggleRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // XRControllerRight
        m_XRControllerRight = asset.FindActionMap("XRControllerRight", throwIfNotFound: true);
        m_XRControllerRight_MenuBtnPress = m_XRControllerRight.FindAction("MenuBtnPress", throwIfNotFound: true);
        m_XRControllerRight_MenuBtnRelease = m_XRControllerRight.FindAction("MenuBtnRelease", throwIfNotFound: true);
        m_XRControllerRight_TouchpadTouchPress = m_XRControllerRight.FindAction("TouchpadTouchPress", throwIfNotFound: true);
        m_XRControllerRight_TouchpadTouchRelease = m_XRControllerRight.FindAction("TouchpadTouchRelease", throwIfNotFound: true);
        m_XRControllerRight_TouchpadClickPress = m_XRControllerRight.FindAction("TouchpadClickPress", throwIfNotFound: true);
        m_XRControllerRight_TouchpadClickRelease = m_XRControllerRight.FindAction("TouchpadClickRelease", throwIfNotFound: true);
        m_XRControllerRight_Connected = m_XRControllerRight.FindAction("Connected", throwIfNotFound: true);
        // XRControllerLeft
        m_XRControllerLeft = asset.FindActionMap("XRControllerLeft", throwIfNotFound: true);
        m_XRControllerLeft_MenuBtnPress = m_XRControllerLeft.FindAction("MenuBtnPress", throwIfNotFound: true);
        m_XRControllerLeft_MenuBtnRelease = m_XRControllerLeft.FindAction("MenuBtnRelease", throwIfNotFound: true);
        m_XRControllerLeft_TouchpadTouchPress = m_XRControllerLeft.FindAction("TouchpadTouchPress", throwIfNotFound: true);
        m_XRControllerLeft_TouchpadTouchRelease = m_XRControllerLeft.FindAction("TouchpadTouchRelease", throwIfNotFound: true);
        m_XRControllerLeft_TouchpadClickPress = m_XRControllerLeft.FindAction("TouchpadClickPress", throwIfNotFound: true);
        m_XRControllerLeft_TouchpadClickRelease = m_XRControllerLeft.FindAction("TouchpadClickRelease", throwIfNotFound: true);
        m_XRControllerLeft_Connected = m_XRControllerLeft.FindAction("Connected", throwIfNotFound: true);
        // KMJControls
        m_KMJControls = asset.FindActionMap("KMJControls", throwIfNotFound: true);
        m_KMJControls_LateralMovement = m_KMJControls.FindAction("LateralMovement", throwIfNotFound: true);
        m_KMJControls_VerticalMovement = m_KMJControls.FindAction("VerticalMovement", throwIfNotFound: true);
        m_KMJControls_RotationDelta = m_KMJControls.FindAction("RotationDelta", throwIfNotFound: true);
        m_KMJControls_ZoomDelta = m_KMJControls.FindAction("ZoomDelta", throwIfNotFound: true);
        m_KMJControls_UIClickBtnPress = m_KMJControls.FindAction("UIClickBtnPress", throwIfNotFound: true);
        m_KMJControls_UIClickBtnRelease = m_KMJControls.FindAction("UIClickBtnRelease", throwIfNotFound: true);
        m_KMJControls_MenuTogglePress = m_KMJControls.FindAction("MenuTogglePress", throwIfNotFound: true);
        m_KMJControls_MenuToggleRelease = m_KMJControls.FindAction("MenuToggleRelease", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // XRControllerRight
    private readonly InputActionMap m_XRControllerRight;
    private IXRControllerRightActions m_XRControllerRightActionsCallbackInterface;
    private readonly InputAction m_XRControllerRight_MenuBtnPress;
    private readonly InputAction m_XRControllerRight_MenuBtnRelease;
    private readonly InputAction m_XRControllerRight_TouchpadTouchPress;
    private readonly InputAction m_XRControllerRight_TouchpadTouchRelease;
    private readonly InputAction m_XRControllerRight_TouchpadClickPress;
    private readonly InputAction m_XRControllerRight_TouchpadClickRelease;
    private readonly InputAction m_XRControllerRight_Connected;
    public struct XRControllerRightActions
    {
        private @KNInputSystem m_Wrapper;
        public XRControllerRightActions(@KNInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @MenuBtnPress => m_Wrapper.m_XRControllerRight_MenuBtnPress;
        public InputAction @MenuBtnRelease => m_Wrapper.m_XRControllerRight_MenuBtnRelease;
        public InputAction @TouchpadTouchPress => m_Wrapper.m_XRControllerRight_TouchpadTouchPress;
        public InputAction @TouchpadTouchRelease => m_Wrapper.m_XRControllerRight_TouchpadTouchRelease;
        public InputAction @TouchpadClickPress => m_Wrapper.m_XRControllerRight_TouchpadClickPress;
        public InputAction @TouchpadClickRelease => m_Wrapper.m_XRControllerRight_TouchpadClickRelease;
        public InputAction @Connected => m_Wrapper.m_XRControllerRight_Connected;
        public InputActionMap Get() { return m_Wrapper.m_XRControllerRight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XRControllerRightActions set) { return set.Get(); }
        public void SetCallbacks(IXRControllerRightActions instance)
        {
            if (m_Wrapper.m_XRControllerRightActionsCallbackInterface != null)
            {
                @MenuBtnPress.started -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnMenuBtnPress;
                @MenuBtnPress.performed -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnMenuBtnPress;
                @MenuBtnPress.canceled -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnMenuBtnPress;
                @MenuBtnRelease.started -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnMenuBtnRelease;
                @MenuBtnRelease.performed -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnMenuBtnRelease;
                @MenuBtnRelease.canceled -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnMenuBtnRelease;
                @TouchpadTouchPress.started -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadTouchPress;
                @TouchpadTouchPress.performed -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadTouchPress;
                @TouchpadTouchPress.canceled -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadTouchPress;
                @TouchpadTouchRelease.started -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadTouchRelease;
                @TouchpadTouchRelease.performed -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadTouchRelease;
                @TouchpadTouchRelease.canceled -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadTouchRelease;
                @TouchpadClickPress.started -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadClickPress;
                @TouchpadClickPress.performed -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadClickPress;
                @TouchpadClickPress.canceled -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadClickPress;
                @TouchpadClickRelease.started -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadClickRelease;
                @TouchpadClickRelease.performed -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadClickRelease;
                @TouchpadClickRelease.canceled -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnTouchpadClickRelease;
                @Connected.started -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnConnected;
                @Connected.performed -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnConnected;
                @Connected.canceled -= m_Wrapper.m_XRControllerRightActionsCallbackInterface.OnConnected;
            }
            m_Wrapper.m_XRControllerRightActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MenuBtnPress.started += instance.OnMenuBtnPress;
                @MenuBtnPress.performed += instance.OnMenuBtnPress;
                @MenuBtnPress.canceled += instance.OnMenuBtnPress;
                @MenuBtnRelease.started += instance.OnMenuBtnRelease;
                @MenuBtnRelease.performed += instance.OnMenuBtnRelease;
                @MenuBtnRelease.canceled += instance.OnMenuBtnRelease;
                @TouchpadTouchPress.started += instance.OnTouchpadTouchPress;
                @TouchpadTouchPress.performed += instance.OnTouchpadTouchPress;
                @TouchpadTouchPress.canceled += instance.OnTouchpadTouchPress;
                @TouchpadTouchRelease.started += instance.OnTouchpadTouchRelease;
                @TouchpadTouchRelease.performed += instance.OnTouchpadTouchRelease;
                @TouchpadTouchRelease.canceled += instance.OnTouchpadTouchRelease;
                @TouchpadClickPress.started += instance.OnTouchpadClickPress;
                @TouchpadClickPress.performed += instance.OnTouchpadClickPress;
                @TouchpadClickPress.canceled += instance.OnTouchpadClickPress;
                @TouchpadClickRelease.started += instance.OnTouchpadClickRelease;
                @TouchpadClickRelease.performed += instance.OnTouchpadClickRelease;
                @TouchpadClickRelease.canceled += instance.OnTouchpadClickRelease;
                @Connected.started += instance.OnConnected;
                @Connected.performed += instance.OnConnected;
                @Connected.canceled += instance.OnConnected;
            }
        }
    }
    public XRControllerRightActions @XRControllerRight => new XRControllerRightActions(this);

    // XRControllerLeft
    private readonly InputActionMap m_XRControllerLeft;
    private IXRControllerLeftActions m_XRControllerLeftActionsCallbackInterface;
    private readonly InputAction m_XRControllerLeft_MenuBtnPress;
    private readonly InputAction m_XRControllerLeft_MenuBtnRelease;
    private readonly InputAction m_XRControllerLeft_TouchpadTouchPress;
    private readonly InputAction m_XRControllerLeft_TouchpadTouchRelease;
    private readonly InputAction m_XRControllerLeft_TouchpadClickPress;
    private readonly InputAction m_XRControllerLeft_TouchpadClickRelease;
    private readonly InputAction m_XRControllerLeft_Connected;
    public struct XRControllerLeftActions
    {
        private @KNInputSystem m_Wrapper;
        public XRControllerLeftActions(@KNInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @MenuBtnPress => m_Wrapper.m_XRControllerLeft_MenuBtnPress;
        public InputAction @MenuBtnRelease => m_Wrapper.m_XRControllerLeft_MenuBtnRelease;
        public InputAction @TouchpadTouchPress => m_Wrapper.m_XRControllerLeft_TouchpadTouchPress;
        public InputAction @TouchpadTouchRelease => m_Wrapper.m_XRControllerLeft_TouchpadTouchRelease;
        public InputAction @TouchpadClickPress => m_Wrapper.m_XRControllerLeft_TouchpadClickPress;
        public InputAction @TouchpadClickRelease => m_Wrapper.m_XRControllerLeft_TouchpadClickRelease;
        public InputAction @Connected => m_Wrapper.m_XRControllerLeft_Connected;
        public InputActionMap Get() { return m_Wrapper.m_XRControllerLeft; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XRControllerLeftActions set) { return set.Get(); }
        public void SetCallbacks(IXRControllerLeftActions instance)
        {
            if (m_Wrapper.m_XRControllerLeftActionsCallbackInterface != null)
            {
                @MenuBtnPress.started -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnMenuBtnPress;
                @MenuBtnPress.performed -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnMenuBtnPress;
                @MenuBtnPress.canceled -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnMenuBtnPress;
                @MenuBtnRelease.started -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnMenuBtnRelease;
                @MenuBtnRelease.performed -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnMenuBtnRelease;
                @MenuBtnRelease.canceled -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnMenuBtnRelease;
                @TouchpadTouchPress.started -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadTouchPress;
                @TouchpadTouchPress.performed -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadTouchPress;
                @TouchpadTouchPress.canceled -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadTouchPress;
                @TouchpadTouchRelease.started -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadTouchRelease;
                @TouchpadTouchRelease.performed -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadTouchRelease;
                @TouchpadTouchRelease.canceled -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadTouchRelease;
                @TouchpadClickPress.started -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadClickPress;
                @TouchpadClickPress.performed -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadClickPress;
                @TouchpadClickPress.canceled -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadClickPress;
                @TouchpadClickRelease.started -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadClickRelease;
                @TouchpadClickRelease.performed -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadClickRelease;
                @TouchpadClickRelease.canceled -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnTouchpadClickRelease;
                @Connected.started -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnConnected;
                @Connected.performed -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnConnected;
                @Connected.canceled -= m_Wrapper.m_XRControllerLeftActionsCallbackInterface.OnConnected;
            }
            m_Wrapper.m_XRControllerLeftActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MenuBtnPress.started += instance.OnMenuBtnPress;
                @MenuBtnPress.performed += instance.OnMenuBtnPress;
                @MenuBtnPress.canceled += instance.OnMenuBtnPress;
                @MenuBtnRelease.started += instance.OnMenuBtnRelease;
                @MenuBtnRelease.performed += instance.OnMenuBtnRelease;
                @MenuBtnRelease.canceled += instance.OnMenuBtnRelease;
                @TouchpadTouchPress.started += instance.OnTouchpadTouchPress;
                @TouchpadTouchPress.performed += instance.OnTouchpadTouchPress;
                @TouchpadTouchPress.canceled += instance.OnTouchpadTouchPress;
                @TouchpadTouchRelease.started += instance.OnTouchpadTouchRelease;
                @TouchpadTouchRelease.performed += instance.OnTouchpadTouchRelease;
                @TouchpadTouchRelease.canceled += instance.OnTouchpadTouchRelease;
                @TouchpadClickPress.started += instance.OnTouchpadClickPress;
                @TouchpadClickPress.performed += instance.OnTouchpadClickPress;
                @TouchpadClickPress.canceled += instance.OnTouchpadClickPress;
                @TouchpadClickRelease.started += instance.OnTouchpadClickRelease;
                @TouchpadClickRelease.performed += instance.OnTouchpadClickRelease;
                @TouchpadClickRelease.canceled += instance.OnTouchpadClickRelease;
                @Connected.started += instance.OnConnected;
                @Connected.performed += instance.OnConnected;
                @Connected.canceled += instance.OnConnected;
            }
        }
    }
    public XRControllerLeftActions @XRControllerLeft => new XRControllerLeftActions(this);

    // KMJControls
    private readonly InputActionMap m_KMJControls;
    private IKMJControlsActions m_KMJControlsActionsCallbackInterface;
    private readonly InputAction m_KMJControls_LateralMovement;
    private readonly InputAction m_KMJControls_VerticalMovement;
    private readonly InputAction m_KMJControls_RotationDelta;
    private readonly InputAction m_KMJControls_ZoomDelta;
    private readonly InputAction m_KMJControls_UIClickBtnPress;
    private readonly InputAction m_KMJControls_UIClickBtnRelease;
    private readonly InputAction m_KMJControls_MenuTogglePress;
    private readonly InputAction m_KMJControls_MenuToggleRelease;
    public struct KMJControlsActions
    {
        private @KNInputSystem m_Wrapper;
        public KMJControlsActions(@KNInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @LateralMovement => m_Wrapper.m_KMJControls_LateralMovement;
        public InputAction @VerticalMovement => m_Wrapper.m_KMJControls_VerticalMovement;
        public InputAction @RotationDelta => m_Wrapper.m_KMJControls_RotationDelta;
        public InputAction @ZoomDelta => m_Wrapper.m_KMJControls_ZoomDelta;
        public InputAction @UIClickBtnPress => m_Wrapper.m_KMJControls_UIClickBtnPress;
        public InputAction @UIClickBtnRelease => m_Wrapper.m_KMJControls_UIClickBtnRelease;
        public InputAction @MenuTogglePress => m_Wrapper.m_KMJControls_MenuTogglePress;
        public InputAction @MenuToggleRelease => m_Wrapper.m_KMJControls_MenuToggleRelease;
        public InputActionMap Get() { return m_Wrapper.m_KMJControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KMJControlsActions set) { return set.Get(); }
        public void SetCallbacks(IKMJControlsActions instance)
        {
            if (m_Wrapper.m_KMJControlsActionsCallbackInterface != null)
            {
                @LateralMovement.started -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnLateralMovement;
                @LateralMovement.performed -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnLateralMovement;
                @LateralMovement.canceled -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnLateralMovement;
                @VerticalMovement.started -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.performed -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.canceled -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnVerticalMovement;
                @RotationDelta.started -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnRotationDelta;
                @RotationDelta.performed -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnRotationDelta;
                @RotationDelta.canceled -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnRotationDelta;
                @ZoomDelta.started -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnZoomDelta;
                @ZoomDelta.performed -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnZoomDelta;
                @ZoomDelta.canceled -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnZoomDelta;
                @UIClickBtnPress.started -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnUIClickBtnPress;
                @UIClickBtnPress.performed -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnUIClickBtnPress;
                @UIClickBtnPress.canceled -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnUIClickBtnPress;
                @UIClickBtnRelease.started -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnUIClickBtnRelease;
                @UIClickBtnRelease.performed -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnUIClickBtnRelease;
                @UIClickBtnRelease.canceled -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnUIClickBtnRelease;
                @MenuTogglePress.started -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnMenuTogglePress;
                @MenuTogglePress.performed -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnMenuTogglePress;
                @MenuTogglePress.canceled -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnMenuTogglePress;
                @MenuToggleRelease.started -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnMenuToggleRelease;
                @MenuToggleRelease.performed -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnMenuToggleRelease;
                @MenuToggleRelease.canceled -= m_Wrapper.m_KMJControlsActionsCallbackInterface.OnMenuToggleRelease;
            }
            m_Wrapper.m_KMJControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LateralMovement.started += instance.OnLateralMovement;
                @LateralMovement.performed += instance.OnLateralMovement;
                @LateralMovement.canceled += instance.OnLateralMovement;
                @VerticalMovement.started += instance.OnVerticalMovement;
                @VerticalMovement.performed += instance.OnVerticalMovement;
                @VerticalMovement.canceled += instance.OnVerticalMovement;
                @RotationDelta.started += instance.OnRotationDelta;
                @RotationDelta.performed += instance.OnRotationDelta;
                @RotationDelta.canceled += instance.OnRotationDelta;
                @ZoomDelta.started += instance.OnZoomDelta;
                @ZoomDelta.performed += instance.OnZoomDelta;
                @ZoomDelta.canceled += instance.OnZoomDelta;
                @UIClickBtnPress.started += instance.OnUIClickBtnPress;
                @UIClickBtnPress.performed += instance.OnUIClickBtnPress;
                @UIClickBtnPress.canceled += instance.OnUIClickBtnPress;
                @UIClickBtnRelease.started += instance.OnUIClickBtnRelease;
                @UIClickBtnRelease.performed += instance.OnUIClickBtnRelease;
                @UIClickBtnRelease.canceled += instance.OnUIClickBtnRelease;
                @MenuTogglePress.started += instance.OnMenuTogglePress;
                @MenuTogglePress.performed += instance.OnMenuTogglePress;
                @MenuTogglePress.canceled += instance.OnMenuTogglePress;
                @MenuToggleRelease.started += instance.OnMenuToggleRelease;
                @MenuToggleRelease.performed += instance.OnMenuToggleRelease;
                @MenuToggleRelease.canceled += instance.OnMenuToggleRelease;
            }
        }
    }
    public KMJControlsActions @KMJControls => new KMJControlsActions(this);
    public interface IXRControllerRightActions
    {
        void OnMenuBtnPress(InputAction.CallbackContext context);
        void OnMenuBtnRelease(InputAction.CallbackContext context);
        void OnTouchpadTouchPress(InputAction.CallbackContext context);
        void OnTouchpadTouchRelease(InputAction.CallbackContext context);
        void OnTouchpadClickPress(InputAction.CallbackContext context);
        void OnTouchpadClickRelease(InputAction.CallbackContext context);
        void OnConnected(InputAction.CallbackContext context);
    }
    public interface IXRControllerLeftActions
    {
        void OnMenuBtnPress(InputAction.CallbackContext context);
        void OnMenuBtnRelease(InputAction.CallbackContext context);
        void OnTouchpadTouchPress(InputAction.CallbackContext context);
        void OnTouchpadTouchRelease(InputAction.CallbackContext context);
        void OnTouchpadClickPress(InputAction.CallbackContext context);
        void OnTouchpadClickRelease(InputAction.CallbackContext context);
        void OnConnected(InputAction.CallbackContext context);
    }
    public interface IKMJControlsActions
    {
        void OnLateralMovement(InputAction.CallbackContext context);
        void OnVerticalMovement(InputAction.CallbackContext context);
        void OnRotationDelta(InputAction.CallbackContext context);
        void OnZoomDelta(InputAction.CallbackContext context);
        void OnUIClickBtnPress(InputAction.CallbackContext context);
        void OnUIClickBtnRelease(InputAction.CallbackContext context);
        void OnMenuTogglePress(InputAction.CallbackContext context);
        void OnMenuToggleRelease(InputAction.CallbackContext context);
    }
}
