// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""a204f2dc-45c2-4121-a078-3e93b08e34e5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""869e6c8e-f0b5-4aff-8468-64156206be27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""662188a9-37bd-4369-bd03-265c5129d002"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""2a3e3e46-9906-4533-b370-65fa3ef2d1fe"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c7c63f34-b29a-419b-8efc-d6f092c379a9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""570a0cf7-5513-4485-b46c-368921554f79"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2225c8ce-6d6e-4af6-9af4-3ad82fa25ab6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d70075fd-a48a-4902-b2d7-37043271b1a6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""70e5a0d4-6637-4cd4-a375-660fad1b3089"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3cf18de0-c835-4a41-963d-f3e64ca9cb12"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a56f52d2-c2e0-4633-8a57-6a1dac80d847"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ee8395c3-9e31-410d-a1cb-8b2f85f0e020"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0556a1b6-2877-41c1-a320-45bf61d8f751"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d2bd09ac-7a96-4352-bda3-e924e66aae69"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""6af00990-2913-45a0-b714-ce90481d5218"",
            ""actions"": [
                {
                    ""name"": ""HealthDecrease"",
                    ""type"": ""Button"",
                    ""id"": ""3f885115-8b92-44e6-924e-ad9bb1ea9382"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HealthIncrease"",
                    ""type"": ""Button"",
                    ""id"": ""cb1d150e-2b1a-4390-832c-c6fb71f7cee4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchTimerOn"",
                    ""type"": ""Button"",
                    ""id"": ""e2c1b8d8-4a32-48bb-84bf-400196e58dff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchTimerOff"",
                    ""type"": ""Button"",
                    ""id"": ""5da93cfc-2b1d-4926-9c61-57823e8fb491"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SummonHandGun"",
                    ""type"": ""Button"",
                    ""id"": ""1a4a5dc2-d872-4ac6-9ba6-01abaa31b3d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SummonLaserGun"",
                    ""type"": ""Button"",
                    ""id"": ""9db4eda4-0f01-414e-bc34-8ace7dee6ede"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SummonSword"",
                    ""type"": ""Button"",
                    ""id"": ""a7b77210-52a5-4df0-b9a7-31c89a0ab967"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SummonShield"",
                    ""type"": ""Button"",
                    ""id"": ""5c3ef148-7692-422b-ab6a-1820353c924f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SummonBanana"",
                    ""type"": ""Button"",
                    ""id"": ""c7ee3e60-427e-4e10-83e9-2ead7c734ef7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SummonBoomerang"",
                    ""type"": ""Button"",
                    ""id"": ""b105f24a-5827-44f8-9d42-2e40562edb8a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""11552ab6-58fc-4698-aa97-d5f3899d4278"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HealthDecrease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9295f21-72cf-425f-a754-82a49d0271fe"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HealthIncrease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2640bfb2-4915-45e3-a5e5-6ad988e694c9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SummonHandGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ca8a546-bab1-489f-978a-fd8ac72077f1"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SummonLaserGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fbabf30-03f7-43bd-ba60-8410ef9ac043"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SummonSword"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d75600a9-4453-4ead-8614-5899ab405cc8"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SummonShield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50f7917a-6c5e-4935-913c-d70f465022a0"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SummonBanana"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3edca27f-358f-4891-9791-05c5eb4c2dca"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SummonBoomerang"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d973e61d-e956-4f2a-ac31-524560b8ef2e"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchTimerOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b24bb9a1-bce9-4dad-a13d-40c1d0daeeac"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchTimerOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_HealthDecrease = m_Debug.FindAction("HealthDecrease", throwIfNotFound: true);
        m_Debug_HealthIncrease = m_Debug.FindAction("HealthIncrease", throwIfNotFound: true);
        m_Debug_SwitchTimerOn = m_Debug.FindAction("SwitchTimerOn", throwIfNotFound: true);
        m_Debug_SwitchTimerOff = m_Debug.FindAction("SwitchTimerOff", throwIfNotFound: true);
        m_Debug_SummonHandGun = m_Debug.FindAction("SummonHandGun", throwIfNotFound: true);
        m_Debug_SummonLaserGun = m_Debug.FindAction("SummonLaserGun", throwIfNotFound: true);
        m_Debug_SummonSword = m_Debug.FindAction("SummonSword", throwIfNotFound: true);
        m_Debug_SummonShield = m_Debug.FindAction("SummonShield", throwIfNotFound: true);
        m_Debug_SummonBanana = m_Debug.FindAction("SummonBanana", throwIfNotFound: true);
        m_Debug_SummonBoomerang = m_Debug.FindAction("SummonBoomerang", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Jump;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_HealthDecrease;
    private readonly InputAction m_Debug_HealthIncrease;
    private readonly InputAction m_Debug_SwitchTimerOn;
    private readonly InputAction m_Debug_SwitchTimerOff;
    private readonly InputAction m_Debug_SummonHandGun;
    private readonly InputAction m_Debug_SummonLaserGun;
    private readonly InputAction m_Debug_SummonSword;
    private readonly InputAction m_Debug_SummonShield;
    private readonly InputAction m_Debug_SummonBanana;
    private readonly InputAction m_Debug_SummonBoomerang;
    public struct DebugActions
    {
        private @PlayerControls m_Wrapper;
        public DebugActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @HealthDecrease => m_Wrapper.m_Debug_HealthDecrease;
        public InputAction @HealthIncrease => m_Wrapper.m_Debug_HealthIncrease;
        public InputAction @SwitchTimerOn => m_Wrapper.m_Debug_SwitchTimerOn;
        public InputAction @SwitchTimerOff => m_Wrapper.m_Debug_SwitchTimerOff;
        public InputAction @SummonHandGun => m_Wrapper.m_Debug_SummonHandGun;
        public InputAction @SummonLaserGun => m_Wrapper.m_Debug_SummonLaserGun;
        public InputAction @SummonSword => m_Wrapper.m_Debug_SummonSword;
        public InputAction @SummonShield => m_Wrapper.m_Debug_SummonShield;
        public InputAction @SummonBanana => m_Wrapper.m_Debug_SummonBanana;
        public InputAction @SummonBoomerang => m_Wrapper.m_Debug_SummonBoomerang;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @HealthDecrease.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnHealthDecrease;
                @HealthDecrease.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnHealthDecrease;
                @HealthDecrease.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnHealthDecrease;
                @HealthIncrease.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnHealthIncrease;
                @HealthIncrease.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnHealthIncrease;
                @HealthIncrease.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnHealthIncrease;
                @SwitchTimerOn.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSwitchTimerOn;
                @SwitchTimerOn.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSwitchTimerOn;
                @SwitchTimerOn.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSwitchTimerOn;
                @SwitchTimerOff.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSwitchTimerOff;
                @SwitchTimerOff.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSwitchTimerOff;
                @SwitchTimerOff.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSwitchTimerOff;
                @SummonHandGun.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonHandGun;
                @SummonHandGun.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonHandGun;
                @SummonHandGun.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonHandGun;
                @SummonLaserGun.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonLaserGun;
                @SummonLaserGun.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonLaserGun;
                @SummonLaserGun.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonLaserGun;
                @SummonSword.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonSword;
                @SummonSword.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonSword;
                @SummonSword.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonSword;
                @SummonShield.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonShield;
                @SummonShield.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonShield;
                @SummonShield.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonShield;
                @SummonBanana.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonBanana;
                @SummonBanana.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonBanana;
                @SummonBanana.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonBanana;
                @SummonBoomerang.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonBoomerang;
                @SummonBoomerang.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonBoomerang;
                @SummonBoomerang.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSummonBoomerang;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HealthDecrease.started += instance.OnHealthDecrease;
                @HealthDecrease.performed += instance.OnHealthDecrease;
                @HealthDecrease.canceled += instance.OnHealthDecrease;
                @HealthIncrease.started += instance.OnHealthIncrease;
                @HealthIncrease.performed += instance.OnHealthIncrease;
                @HealthIncrease.canceled += instance.OnHealthIncrease;
                @SwitchTimerOn.started += instance.OnSwitchTimerOn;
                @SwitchTimerOn.performed += instance.OnSwitchTimerOn;
                @SwitchTimerOn.canceled += instance.OnSwitchTimerOn;
                @SwitchTimerOff.started += instance.OnSwitchTimerOff;
                @SwitchTimerOff.performed += instance.OnSwitchTimerOff;
                @SwitchTimerOff.canceled += instance.OnSwitchTimerOff;
                @SummonHandGun.started += instance.OnSummonHandGun;
                @SummonHandGun.performed += instance.OnSummonHandGun;
                @SummonHandGun.canceled += instance.OnSummonHandGun;
                @SummonLaserGun.started += instance.OnSummonLaserGun;
                @SummonLaserGun.performed += instance.OnSummonLaserGun;
                @SummonLaserGun.canceled += instance.OnSummonLaserGun;
                @SummonSword.started += instance.OnSummonSword;
                @SummonSword.performed += instance.OnSummonSword;
                @SummonSword.canceled += instance.OnSummonSword;
                @SummonShield.started += instance.OnSummonShield;
                @SummonShield.performed += instance.OnSummonShield;
                @SummonShield.canceled += instance.OnSummonShield;
                @SummonBanana.started += instance.OnSummonBanana;
                @SummonBanana.performed += instance.OnSummonBanana;
                @SummonBanana.canceled += instance.OnSummonBanana;
                @SummonBoomerang.started += instance.OnSummonBoomerang;
                @SummonBoomerang.performed += instance.OnSummonBoomerang;
                @SummonBoomerang.canceled += instance.OnSummonBoomerang;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnHealthDecrease(InputAction.CallbackContext context);
        void OnHealthIncrease(InputAction.CallbackContext context);
        void OnSwitchTimerOn(InputAction.CallbackContext context);
        void OnSwitchTimerOff(InputAction.CallbackContext context);
        void OnSummonHandGun(InputAction.CallbackContext context);
        void OnSummonLaserGun(InputAction.CallbackContext context);
        void OnSummonSword(InputAction.CallbackContext context);
        void OnSummonShield(InputAction.CallbackContext context);
        void OnSummonBanana(InputAction.CallbackContext context);
        void OnSummonBoomerang(InputAction.CallbackContext context);
    }
}
