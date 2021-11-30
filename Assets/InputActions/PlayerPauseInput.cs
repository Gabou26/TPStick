// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerPauseInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerPauseInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""bcfbd212-5295-4507-9f48-b4d05b46c7a1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""aa3aeee5-624e-4fd8-ab94-4d419b896012"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveKey"",
                    ""type"": ""Value"",
                    ""id"": ""0dfc6118-e7ed-4104-ac81-5590ba4d1437"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpPress"",
                    ""type"": ""Button"",
                    ""id"": ""f84f58ca-80ba-437c-b08c-2563e2a56e75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""JumpRelease"",
                    ""type"": ""Button"",
                    ""id"": ""65cb0aa8-e8e6-431c-a812-ee9e9e62505a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""CameraV"",
                    ""type"": ""Value"",
                    ""id"": ""7463985f-a60a-4a42-8f95-34a25c93f102"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraCV"",
                    ""type"": ""Value"",
                    ""id"": ""7c3d4b6d-b91e-4c48-9bac-b9e5e0180cee"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraH"",
                    ""type"": ""Value"",
                    ""id"": ""d33e5a20-154d-45c6-a27b-0e9378d191aa"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraCH"",
                    ""type"": ""Value"",
                    ""id"": ""cb1a1589-5b55-41d9-b603-e3118b92325f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirePress"",
                    ""type"": ""Button"",
                    ""id"": ""bc537706-909a-49e8-8c26-08b5790ffb4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""FireRelease"",
                    ""type"": ""Button"",
                    ""id"": ""78406958-f2b3-4341-a265-7acd1dad95e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Ragdoll"",
                    ""type"": ""Button"",
                    ""id"": ""0e8e056b-6fb7-45e4-8b07-acdde1b65c3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""a98f7fd2-8fff-4693-90de-d75f93ba0f53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""GrapplePress"",
                    ""type"": ""Button"",
                    ""id"": ""d3300b98-5522-48a6-8a15-fbb2aff987ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""GrappleRelease"",
                    ""type"": ""Button"",
                    ""id"": ""8bf6640b-1398-4664-9172-45e272f2c872"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1f901801-5c05-42cb-a2e1-23acf4e969e6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67c6416e-92c9-490a-b906-01d43f1472f3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37dfd9af-a698-4b6f-ab38-5f59846258cc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""JumpPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""705dd889-fe12-43fc-a184-75a3218cd39b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10a140a0-23db-40aa-b90f-b7fd45431ab1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24514b9e-ab5a-4727-87c3-7ff4e6c614a4"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraV"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d07560ec-153d-4627-a44a-a93091e58526"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""03171c07-ed8f-4c27-bfcc-f24d1e030660"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKey"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""56b4ffb8-41e5-4c19-ac7a-6ff819774f48"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3cbac1d1-dd9c-4730-a27f-071d6da13fad"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3998f7c4-de3a-4c60-a71d-ebdb5f78d50a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""912dc9d9-6f2c-493b-8579-c6702597628e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""a029d3d6-0441-4d08-a798-b8ee15707d2e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKey"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8a55aac3-ef74-469f-b866-e58489812c06"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7b7df71b-04d7-4209-b90e-0493c2961150"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d407eb77-0a1e-4780-9ea6-5c2edf84c5aa"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eef9b62d-670b-4afe-9ccb-23b66f41e44a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7e8d70bd-0c86-44a1-a76d-2046dbeafdd8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""FirePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bd1b0e5-fd3a-4306-8bbf-1c0ef91da3de"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""FirePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef1e6718-bbb0-4362-a43b-4c49ff117ffb"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""FireRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9de3105-33dd-4f1c-bfcd-51c3a452255d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""FireRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e14dafee-4758-48cd-b14b-37a55be088ac"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Ragdoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""969b1827-4d39-46c5-8eec-55d399878a39"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ragdoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""010766a6-eb05-4d01-b3e9-6610d423d138"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42dde08b-a284-425c-bebd-cfa710ae0d36"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60b0c14d-15c3-470c-86f2-08dedc7251f5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""GrappleRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74b09026-76fe-4fc4-a3a7-f74bf7f781fd"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""GrappleRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9434639f-3144-49ff-94ee-98233d5136ca"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""GrapplePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a0517bd-9ede-4b26-b08b-8379f5b10d59"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""GrapplePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""414a3967-585c-46d7-928a-e80370addcdd"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CameraCH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0610b285-3668-4884-a814-694107b8c30a"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CameraCV"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_MoveKey = m_Player.FindAction("MoveKey", throwIfNotFound: true);
        m_Player_JumpPress = m_Player.FindAction("JumpPress", throwIfNotFound: true);
        m_Player_JumpRelease = m_Player.FindAction("JumpRelease", throwIfNotFound: true);
        m_Player_CameraV = m_Player.FindAction("CameraV", throwIfNotFound: true);
        m_Player_CameraCV = m_Player.FindAction("CameraCV", throwIfNotFound: true);
        m_Player_CameraH = m_Player.FindAction("CameraH", throwIfNotFound: true);
        m_Player_CameraCH = m_Player.FindAction("CameraCH", throwIfNotFound: true);
        m_Player_FirePress = m_Player.FindAction("FirePress", throwIfNotFound: true);
        m_Player_FireRelease = m_Player.FindAction("FireRelease", throwIfNotFound: true);
        m_Player_Ragdoll = m_Player.FindAction("Ragdoll", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_GrapplePress = m_Player.FindAction("GrapplePress", throwIfNotFound: true);
        m_Player_GrappleRelease = m_Player.FindAction("GrappleRelease", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_MoveKey;
    private readonly InputAction m_Player_JumpPress;
    private readonly InputAction m_Player_JumpRelease;
    private readonly InputAction m_Player_CameraV;
    private readonly InputAction m_Player_CameraCV;
    private readonly InputAction m_Player_CameraH;
    private readonly InputAction m_Player_CameraCH;
    private readonly InputAction m_Player_FirePress;
    private readonly InputAction m_Player_FireRelease;
    private readonly InputAction m_Player_Ragdoll;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_GrapplePress;
    private readonly InputAction m_Player_GrappleRelease;
    public struct PlayerActions
    {
        private @PlayerPauseInput m_Wrapper;
        public PlayerActions(@PlayerPauseInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @MoveKey => m_Wrapper.m_Player_MoveKey;
        public InputAction @JumpPress => m_Wrapper.m_Player_JumpPress;
        public InputAction @JumpRelease => m_Wrapper.m_Player_JumpRelease;
        public InputAction @CameraV => m_Wrapper.m_Player_CameraV;
        public InputAction @CameraCV => m_Wrapper.m_Player_CameraCV;
        public InputAction @CameraH => m_Wrapper.m_Player_CameraH;
        public InputAction @CameraCH => m_Wrapper.m_Player_CameraCH;
        public InputAction @FirePress => m_Wrapper.m_Player_FirePress;
        public InputAction @FireRelease => m_Wrapper.m_Player_FireRelease;
        public InputAction @Ragdoll => m_Wrapper.m_Player_Ragdoll;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @GrapplePress => m_Wrapper.m_Player_GrapplePress;
        public InputAction @GrappleRelease => m_Wrapper.m_Player_GrappleRelease;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @MoveKey.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveKey;
                @MoveKey.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveKey;
                @MoveKey.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveKey;
                @JumpPress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPress;
                @JumpPress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPress;
                @JumpPress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPress;
                @JumpRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpRelease;
                @CameraV.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraV;
                @CameraV.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraV;
                @CameraV.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraV;
                @CameraCV.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraCV;
                @CameraCV.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraCV;
                @CameraCV.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraCV;
                @CameraH.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraH;
                @CameraH.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraH;
                @CameraH.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraH;
                @CameraCH.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraCH;
                @CameraCH.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraCH;
                @CameraCH.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraCH;
                @FirePress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFirePress;
                @FirePress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFirePress;
                @FirePress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFirePress;
                @FireRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireRelease;
                @FireRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireRelease;
                @FireRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireRelease;
                @Ragdoll.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRagdoll;
                @Ragdoll.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRagdoll;
                @Ragdoll.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRagdoll;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @GrapplePress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrapplePress;
                @GrapplePress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrapplePress;
                @GrapplePress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrapplePress;
                @GrappleRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrappleRelease;
                @GrappleRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrappleRelease;
                @GrappleRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrappleRelease;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MoveKey.started += instance.OnMoveKey;
                @MoveKey.performed += instance.OnMoveKey;
                @MoveKey.canceled += instance.OnMoveKey;
                @JumpPress.started += instance.OnJumpPress;
                @JumpPress.performed += instance.OnJumpPress;
                @JumpPress.canceled += instance.OnJumpPress;
                @JumpRelease.started += instance.OnJumpRelease;
                @JumpRelease.performed += instance.OnJumpRelease;
                @JumpRelease.canceled += instance.OnJumpRelease;
                @CameraV.started += instance.OnCameraV;
                @CameraV.performed += instance.OnCameraV;
                @CameraV.canceled += instance.OnCameraV;
                @CameraCV.started += instance.OnCameraCV;
                @CameraCV.performed += instance.OnCameraCV;
                @CameraCV.canceled += instance.OnCameraCV;
                @CameraH.started += instance.OnCameraH;
                @CameraH.performed += instance.OnCameraH;
                @CameraH.canceled += instance.OnCameraH;
                @CameraCH.started += instance.OnCameraCH;
                @CameraCH.performed += instance.OnCameraCH;
                @CameraCH.canceled += instance.OnCameraCH;
                @FirePress.started += instance.OnFirePress;
                @FirePress.performed += instance.OnFirePress;
                @FirePress.canceled += instance.OnFirePress;
                @FireRelease.started += instance.OnFireRelease;
                @FireRelease.performed += instance.OnFireRelease;
                @FireRelease.canceled += instance.OnFireRelease;
                @Ragdoll.started += instance.OnRagdoll;
                @Ragdoll.performed += instance.OnRagdoll;
                @Ragdoll.canceled += instance.OnRagdoll;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @GrapplePress.started += instance.OnGrapplePress;
                @GrapplePress.performed += instance.OnGrapplePress;
                @GrapplePress.canceled += instance.OnGrapplePress;
                @GrappleRelease.started += instance.OnGrappleRelease;
                @GrappleRelease.performed += instance.OnGrappleRelease;
                @GrappleRelease.canceled += instance.OnGrappleRelease;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMoveKey(InputAction.CallbackContext context);
        void OnJumpPress(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnCameraV(InputAction.CallbackContext context);
        void OnCameraCV(InputAction.CallbackContext context);
        void OnCameraH(InputAction.CallbackContext context);
        void OnCameraCH(InputAction.CallbackContext context);
        void OnFirePress(InputAction.CallbackContext context);
        void OnFireRelease(InputAction.CallbackContext context);
        void OnRagdoll(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnGrapplePress(InputAction.CallbackContext context);
        void OnGrappleRelease(InputAction.CallbackContext context);
    }
}
