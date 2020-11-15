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
            ""name"": ""AttackActions"",
            ""id"": ""2e0690cd-c97d-4b62-9845-4fadeea1a2b7"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d4f791d8-419c-46bd-9fe9-04e0d0a81bce"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
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
                    ""id"": ""134a53d0-e094-414d-8f04-a95ff761bcd8"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""538d73db-0ec4-424a-b582-a443cbc9962b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DefendActions"",
            ""id"": ""2daec7dc-a0f0-4787-a978-740532a54960"",
            ""actions"": [
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AttackActions
        m_AttackActions = asset.FindActionMap("AttackActions", throwIfNotFound: true);
        m_AttackActions_Aim = m_AttackActions.FindAction("Aim", throwIfNotFound: true);
        m_AttackActions_Attack = m_AttackActions.FindAction("Attack", throwIfNotFound: true);
        // DefendActions
        m_DefendActions = asset.FindActionMap("DefendActions", throwIfNotFound: true);
        m_DefendActions_BlockStart = m_DefendActions.FindAction("BlockStart", throwIfNotFound: true);
        m_DefendActions_BlockEnd = m_DefendActions.FindAction("BlockEnd", throwIfNotFound: true);
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

    // AttackActions
    private readonly InputActionMap m_AttackActions;
    private IAttackActionsActions m_AttackActionsActionsCallbackInterface;
    private readonly InputAction m_AttackActions_Aim;
    private readonly InputAction m_AttackActions_Attack;
    public struct AttackActionsActions
    {
        private @WeaponControls m_Wrapper;
        public AttackActionsActions(@WeaponControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_AttackActions_Aim;
        public InputAction @Attack => m_Wrapper.m_AttackActions_Attack;
        public InputActionMap Get() { return m_Wrapper.m_AttackActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackActionsActions set) { return set.Get(); }
        public void SetCallbacks(IAttackActionsActions instance)
        {
            if (m_Wrapper.m_AttackActionsActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_AttackActionsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_AttackActionsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_AttackActionsActionsCallbackInterface.OnAim;
                @Attack.started -= m_Wrapper.m_AttackActionsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_AttackActionsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_AttackActionsActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_AttackActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public AttackActionsActions @AttackActions => new AttackActionsActions(this);

    // DefendActions
    private readonly InputActionMap m_DefendActions;
    private IDefendActionsActions m_DefendActionsActionsCallbackInterface;
    private readonly InputAction m_DefendActions_BlockStart;
    private readonly InputAction m_DefendActions_BlockEnd;
    public struct DefendActionsActions
    {
        private @WeaponControls m_Wrapper;
        public DefendActionsActions(@WeaponControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @BlockStart => m_Wrapper.m_DefendActions_BlockStart;
        public InputAction @BlockEnd => m_Wrapper.m_DefendActions_BlockEnd;
        public InputActionMap Get() { return m_Wrapper.m_DefendActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefendActionsActions set) { return set.Get(); }
        public void SetCallbacks(IDefendActionsActions instance)
        {
            if (m_Wrapper.m_DefendActionsActionsCallbackInterface != null)
            {
                @BlockStart.started -= m_Wrapper.m_DefendActionsActionsCallbackInterface.OnBlockStart;
                @BlockStart.performed -= m_Wrapper.m_DefendActionsActionsCallbackInterface.OnBlockStart;
                @BlockStart.canceled -= m_Wrapper.m_DefendActionsActionsCallbackInterface.OnBlockStart;
                @BlockEnd.started -= m_Wrapper.m_DefendActionsActionsCallbackInterface.OnBlockEnd;
                @BlockEnd.performed -= m_Wrapper.m_DefendActionsActionsCallbackInterface.OnBlockEnd;
                @BlockEnd.canceled -= m_Wrapper.m_DefendActionsActionsCallbackInterface.OnBlockEnd;
            }
            m_Wrapper.m_DefendActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @BlockStart.started += instance.OnBlockStart;
                @BlockStart.performed += instance.OnBlockStart;
                @BlockStart.canceled += instance.OnBlockStart;
                @BlockEnd.started += instance.OnBlockEnd;
                @BlockEnd.performed += instance.OnBlockEnd;
                @BlockEnd.canceled += instance.OnBlockEnd;
            }
        }
    }
    public DefendActionsActions @DefendActions => new DefendActionsActions(this);
    public interface IAttackActionsActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface IDefendActionsActions
    {
        void OnBlockStart(InputAction.CallbackContext context);
        void OnBlockEnd(InputAction.CallbackContext context);
    }
}
