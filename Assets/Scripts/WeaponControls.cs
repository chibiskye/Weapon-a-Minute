// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/WeaponControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @WeaponControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @WeaponControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""WeaponControls"",
    ""maps"": [
        {
            ""name"": ""GunInputs"",
            ""id"": ""2e0690cd-c97d-4b62-9845-4fadeea1a2b7"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a770111c-6133-41d6-adde-ea0a3935e89e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""538d73db-0ec4-424a-b582-a443cbc9962b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ShieldInputs"",
            ""id"": ""2daec7dc-a0f0-4787-a978-740532a54960"",
            ""actions"": [
                {
                    ""name"": ""ShieldBash"",
                    ""type"": ""Button"",
                    ""id"": ""33fad526-44de-488c-afba-f03fe32e9797"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BlockStart"",
                    ""type"": ""Button"",
                    ""id"": ""a3c2e99f-5c57-4e81-ae5a-4954211efa01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BlockEnd"",
                    ""type"": ""Button"",
                    ""id"": ""34529302-d3fe-4984-a655-f2f0310d1204"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2bd4e85c-9d19-40e6-8c19-d9e0f135f869"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BlockStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff89bf09-8cda-4337-a765-515cca70c066"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BlockEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2deb9ba3-6142-4d3d-9cd6-b61bef07bf42"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShieldBash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SwordInputs"",
            ""id"": ""3406f3e5-4026-4684-8645-be411fcce537"",
            ""actions"": [
                {
                    ""name"": ""Swing"",
                    ""type"": ""Button"",
                    ""id"": ""17d880e3-2ef5-4469-b55c-8ee1a8beddf3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""39917a7e-32e8-459e-a4fd-ed0a71e26b46"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""BananaInputs"",
            ""id"": ""0ffe825a-9c82-4a70-a729-35e39060211b"",
            ""actions"": [
                {
                    ""name"": ""Swing"",
                    ""type"": ""Button"",
                    ""id"": ""c0a895e1-b468-496e-af8c-790f7c787e16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""0205c9ea-06ad-43bb-9234-a96b9db6f518"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7dcc2bbe-09a3-4ba1-9b1d-1f6e1de90b26"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca0a9ff7-9534-476c-bb98-a1c6c8e6d204"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GunInputs
        m_GunInputs = asset.FindActionMap("GunInputs", throwIfNotFound: true);
        m_GunInputs_Shoot = m_GunInputs.FindAction("Shoot", throwIfNotFound: true);
        // ShieldInputs
        m_ShieldInputs = asset.FindActionMap("ShieldInputs", throwIfNotFound: true);
        m_ShieldInputs_ShieldBash = m_ShieldInputs.FindAction("ShieldBash", throwIfNotFound: true);
        m_ShieldInputs_BlockStart = m_ShieldInputs.FindAction("BlockStart", throwIfNotFound: true);
        m_ShieldInputs_BlockEnd = m_ShieldInputs.FindAction("BlockEnd", throwIfNotFound: true);
        // SwordInputs
        m_SwordInputs = asset.FindActionMap("SwordInputs", throwIfNotFound: true);
        m_SwordInputs_Swing = m_SwordInputs.FindAction("Swing", throwIfNotFound: true);
        // BananaInputs
        m_BananaInputs = asset.FindActionMap("BananaInputs", throwIfNotFound: true);
        m_BananaInputs_Swing = m_BananaInputs.FindAction("Swing", throwIfNotFound: true);
        m_BananaInputs_Throw = m_BananaInputs.FindAction("Throw", throwIfNotFound: true);
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

    // GunInputs
    private readonly InputActionMap m_GunInputs;
    private IGunInputsActions m_GunInputsActionsCallbackInterface;
    private readonly InputAction m_GunInputs_Shoot;
    public struct GunInputsActions
    {
        private @WeaponControls m_Wrapper;
        public GunInputsActions(@WeaponControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_GunInputs_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_GunInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GunInputsActions set) { return set.Get(); }
        public void SetCallbacks(IGunInputsActions instance)
        {
            if (m_Wrapper.m_GunInputsActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_GunInputsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GunInputsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GunInputsActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_GunInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public GunInputsActions @GunInputs => new GunInputsActions(this);

    // ShieldInputs
    private readonly InputActionMap m_ShieldInputs;
    private IShieldInputsActions m_ShieldInputsActionsCallbackInterface;
    private readonly InputAction m_ShieldInputs_ShieldBash;
    private readonly InputAction m_ShieldInputs_BlockStart;
    private readonly InputAction m_ShieldInputs_BlockEnd;
    public struct ShieldInputsActions
    {
        private @WeaponControls m_Wrapper;
        public ShieldInputsActions(@WeaponControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShieldBash => m_Wrapper.m_ShieldInputs_ShieldBash;
        public InputAction @BlockStart => m_Wrapper.m_ShieldInputs_BlockStart;
        public InputAction @BlockEnd => m_Wrapper.m_ShieldInputs_BlockEnd;
        public InputActionMap Get() { return m_Wrapper.m_ShieldInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShieldInputsActions set) { return set.Get(); }
        public void SetCallbacks(IShieldInputsActions instance)
        {
            if (m_Wrapper.m_ShieldInputsActionsCallbackInterface != null)
            {
                @ShieldBash.started -= m_Wrapper.m_ShieldInputsActionsCallbackInterface.OnShieldBash;
                @ShieldBash.performed -= m_Wrapper.m_ShieldInputsActionsCallbackInterface.OnShieldBash;
                @ShieldBash.canceled -= m_Wrapper.m_ShieldInputsActionsCallbackInterface.OnShieldBash;
                @BlockStart.started -= m_Wrapper.m_ShieldInputsActionsCallbackInterface.OnBlockStart;
                @BlockStart.performed -= m_Wrapper.m_ShieldInputsActionsCallbackInterface.OnBlockStart;
                @BlockStart.canceled -= m_Wrapper.m_ShieldInputsActionsCallbackInterface.OnBlockStart;
                @BlockEnd.started -= m_Wrapper.m_ShieldInputsActionsCallbackInterface.OnBlockEnd;
                @BlockEnd.performed -= m_Wrapper.m_ShieldInputsActionsCallbackInterface.OnBlockEnd;
                @BlockEnd.canceled -= m_Wrapper.m_ShieldInputsActionsCallbackInterface.OnBlockEnd;
            }
            m_Wrapper.m_ShieldInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ShieldBash.started += instance.OnShieldBash;
                @ShieldBash.performed += instance.OnShieldBash;
                @ShieldBash.canceled += instance.OnShieldBash;
                @BlockStart.started += instance.OnBlockStart;
                @BlockStart.performed += instance.OnBlockStart;
                @BlockStart.canceled += instance.OnBlockStart;
                @BlockEnd.started += instance.OnBlockEnd;
                @BlockEnd.performed += instance.OnBlockEnd;
                @BlockEnd.canceled += instance.OnBlockEnd;
            }
        }
    }
    public ShieldInputsActions @ShieldInputs => new ShieldInputsActions(this);

    // SwordInputs
    private readonly InputActionMap m_SwordInputs;
    private ISwordInputsActions m_SwordInputsActionsCallbackInterface;
    private readonly InputAction m_SwordInputs_Swing;
    public struct SwordInputsActions
    {
        private @WeaponControls m_Wrapper;
        public SwordInputsActions(@WeaponControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Swing => m_Wrapper.m_SwordInputs_Swing;
        public InputActionMap Get() { return m_Wrapper.m_SwordInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SwordInputsActions set) { return set.Get(); }
        public void SetCallbacks(ISwordInputsActions instance)
        {
            if (m_Wrapper.m_SwordInputsActionsCallbackInterface != null)
            {
                @Swing.started -= m_Wrapper.m_SwordInputsActionsCallbackInterface.OnSwing;
                @Swing.performed -= m_Wrapper.m_SwordInputsActionsCallbackInterface.OnSwing;
                @Swing.canceled -= m_Wrapper.m_SwordInputsActionsCallbackInterface.OnSwing;
            }
            m_Wrapper.m_SwordInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Swing.started += instance.OnSwing;
                @Swing.performed += instance.OnSwing;
                @Swing.canceled += instance.OnSwing;
            }
        }
    }
    public SwordInputsActions @SwordInputs => new SwordInputsActions(this);

    // BananaInputs
    private readonly InputActionMap m_BananaInputs;
    private IBananaInputsActions m_BananaInputsActionsCallbackInterface;
    private readonly InputAction m_BananaInputs_Swing;
    private readonly InputAction m_BananaInputs_Throw;
    public struct BananaInputsActions
    {
        private @WeaponControls m_Wrapper;
        public BananaInputsActions(@WeaponControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Swing => m_Wrapper.m_BananaInputs_Swing;
        public InputAction @Throw => m_Wrapper.m_BananaInputs_Throw;
        public InputActionMap Get() { return m_Wrapper.m_BananaInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BananaInputsActions set) { return set.Get(); }
        public void SetCallbacks(IBananaInputsActions instance)
        {
            if (m_Wrapper.m_BananaInputsActionsCallbackInterface != null)
            {
                @Swing.started -= m_Wrapper.m_BananaInputsActionsCallbackInterface.OnSwing;
                @Swing.performed -= m_Wrapper.m_BananaInputsActionsCallbackInterface.OnSwing;
                @Swing.canceled -= m_Wrapper.m_BananaInputsActionsCallbackInterface.OnSwing;
                @Throw.started -= m_Wrapper.m_BananaInputsActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_BananaInputsActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_BananaInputsActionsCallbackInterface.OnThrow;
            }
            m_Wrapper.m_BananaInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Swing.started += instance.OnSwing;
                @Swing.performed += instance.OnSwing;
                @Swing.canceled += instance.OnSwing;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
            }
        }
    }
    public BananaInputsActions @BananaInputs => new BananaInputsActions(this);
    public interface IGunInputsActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IShieldInputsActions
    {
        void OnShieldBash(InputAction.CallbackContext context);
        void OnBlockStart(InputAction.CallbackContext context);
        void OnBlockEnd(InputAction.CallbackContext context);
    }
    public interface ISwordInputsActions
    {
        void OnSwing(InputAction.CallbackContext context);
    }
    public interface IBananaInputsActions
    {
        void OnSwing(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
    }
}
