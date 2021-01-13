// GENERATED AUTOMATICALLY FROM 'Assets/GenericPadInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GenericPadInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GenericPadInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GenericPadInput"",
    ""maps"": [
        {
            ""name"": ""default"",
            ""id"": ""b6ecdf4c-4f7c-42aa-ab29-e8b47d0b9644"",
            ""actions"": [
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""32d17852-f87b-4271-b662-24543b1a6c31"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Value"",
                    ""id"": ""0e609f63-5590-4e65-a8fe-88f4d445998e"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""6b223b2b-9657-486e-b5c6-90d4b50a177f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""3aa084b3-45c1-4c47-ad40-5df94eecc530"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5c71f440-0741-475f-b5f5-07cad375dfdf"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""060a69b0-8522-4a31-90f6-a02834d4d6ea"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4b07cc0-7e9d-4a7c-a036-8098b967e851"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Analog"",
                    ""id"": ""73fd45a1-e58e-4e6c-b1d6-e672116a0f84"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ab26d01b-3441-401c-8410-eb839fc5f351"",
                    ""path"": ""<Joystick>/rz"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ec1ede93-eefa-4551-8468-88358edbffce"",
                    ""path"": ""<Joystick>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""74e39e81-ed1a-41eb-bc76-b3c9c9c1c882"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35d515e2-bf61-4f3b-83a4-4c147a9e8478"",
                    ""path"": ""<Joystick>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cdb92a0-a602-4377-8881-4728a0eb4895"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1fd4779-7962-4e39-84ed-8e3a779d041c"",
                    ""path"": ""<Joystick>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // default
        m_default = asset.FindActionMap("default", throwIfNotFound: true);
        m_default_LeftStick = m_default.FindAction("LeftStick", throwIfNotFound: true);
        m_default_RightStick = m_default.FindAction("RightStick", throwIfNotFound: true);
        m_default_Submit = m_default.FindAction("Submit", throwIfNotFound: true);
        m_default_Cancel = m_default.FindAction("Cancel", throwIfNotFound: true);
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

    // default
    private readonly InputActionMap m_default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_default_LeftStick;
    private readonly InputAction m_default_RightStick;
    private readonly InputAction m_default_Submit;
    private readonly InputAction m_default_Cancel;
    public struct DefaultActions
    {
        private @GenericPadInput m_Wrapper;
        public DefaultActions(@GenericPadInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_default_LeftStick;
        public InputAction @RightStick => m_Wrapper.m_default_RightStick;
        public InputAction @Submit => m_Wrapper.m_default_Submit;
        public InputAction @Cancel => m_Wrapper.m_default_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @LeftStick.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftStick;
                @RightStick.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightStick;
                @Submit.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public DefaultActions @default => new DefaultActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IDefaultActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}
