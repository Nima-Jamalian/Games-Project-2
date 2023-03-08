//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystem/InputControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""MovementActionInput"",
            ""id"": ""4272b381-0c3f-4db6-afea-65bb2e2131a9"",
            ""actions"": [
                {
                    ""name"": ""UpAction"",
                    ""type"": ""Button"",
                    ""id"": ""56a3f747-6460-49bc-8a21-60a8beb0a2b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DownAction"",
                    ""type"": ""Button"",
                    ""id"": ""69c6d371-6055-42d2-9cfe-e55cb62d0239"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftAction"",
                    ""type"": ""Button"",
                    ""id"": ""54462fee-8c6c-47b7-8669-169857d3400b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightAction"",
                    ""type"": ""Button"",
                    ""id"": ""e1dbf384-dfe9-41e8-95df-f3a2742fa367"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ba5de2ab-1253-4ab5-9eed-555eff093c54"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87b0c7bb-a003-4551-9c5b-c0637d548d34"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7c38dfa-8542-45a7-90fe-8d0eeac2cb7a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""151b9e9d-6cc0-4533-9f77-0db9a554fc89"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeaec7ef-bab7-4bd2-b1f7-4804ddc16fb1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a12bbf3c-431a-4997-8ec3-6724c88be10c"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b2ce2ff-02fc-4a3e-b71f-a3a8838df33f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""809b8c6c-fcfb-47cb-8c1a-556f16adeab1"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MovementActionInput
        m_MovementActionInput = asset.FindActionMap("MovementActionInput", throwIfNotFound: true);
        m_MovementActionInput_UpAction = m_MovementActionInput.FindAction("UpAction", throwIfNotFound: true);
        m_MovementActionInput_DownAction = m_MovementActionInput.FindAction("DownAction", throwIfNotFound: true);
        m_MovementActionInput_LeftAction = m_MovementActionInput.FindAction("LeftAction", throwIfNotFound: true);
        m_MovementActionInput_RightAction = m_MovementActionInput.FindAction("RightAction", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MovementActionInput
    private readonly InputActionMap m_MovementActionInput;
    private IMovementActionInputActions m_MovementActionInputActionsCallbackInterface;
    private readonly InputAction m_MovementActionInput_UpAction;
    private readonly InputAction m_MovementActionInput_DownAction;
    private readonly InputAction m_MovementActionInput_LeftAction;
    private readonly InputAction m_MovementActionInput_RightAction;
    public struct MovementActionInputActions
    {
        private @InputControls m_Wrapper;
        public MovementActionInputActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpAction => m_Wrapper.m_MovementActionInput_UpAction;
        public InputAction @DownAction => m_Wrapper.m_MovementActionInput_DownAction;
        public InputAction @LeftAction => m_Wrapper.m_MovementActionInput_LeftAction;
        public InputAction @RightAction => m_Wrapper.m_MovementActionInput_RightAction;
        public InputActionMap Get() { return m_Wrapper.m_MovementActionInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActionInputActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActionInputActions instance)
        {
            if (m_Wrapper.m_MovementActionInputActionsCallbackInterface != null)
            {
                @UpAction.started -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnUpAction;
                @UpAction.performed -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnUpAction;
                @UpAction.canceled -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnUpAction;
                @DownAction.started -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnDownAction;
                @DownAction.performed -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnDownAction;
                @DownAction.canceled -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnDownAction;
                @LeftAction.started -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnLeftAction;
                @LeftAction.performed -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnLeftAction;
                @LeftAction.canceled -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnLeftAction;
                @RightAction.started -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnRightAction;
                @RightAction.performed -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnRightAction;
                @RightAction.canceled -= m_Wrapper.m_MovementActionInputActionsCallbackInterface.OnRightAction;
            }
            m_Wrapper.m_MovementActionInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpAction.started += instance.OnUpAction;
                @UpAction.performed += instance.OnUpAction;
                @UpAction.canceled += instance.OnUpAction;
                @DownAction.started += instance.OnDownAction;
                @DownAction.performed += instance.OnDownAction;
                @DownAction.canceled += instance.OnDownAction;
                @LeftAction.started += instance.OnLeftAction;
                @LeftAction.performed += instance.OnLeftAction;
                @LeftAction.canceled += instance.OnLeftAction;
                @RightAction.started += instance.OnRightAction;
                @RightAction.performed += instance.OnRightAction;
                @RightAction.canceled += instance.OnRightAction;
            }
        }
    }
    public MovementActionInputActions @MovementActionInput => new MovementActionInputActions(this);
    public interface IMovementActionInputActions
    {
        void OnUpAction(InputAction.CallbackContext context);
        void OnDownAction(InputAction.CallbackContext context);
        void OnLeftAction(InputAction.CallbackContext context);
        void OnRightAction(InputAction.CallbackContext context);
    }
}
