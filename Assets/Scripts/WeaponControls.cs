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
                },
                {
                    ""name"": ""SecondAction"",
                    ""type"": ""Button"",
                    ""id"": ""dc88ff8a-b902-4401-8fb5-4068f0ae8fef"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""75c2d5ec-f6bc-4b44-8ec4-f1f5985da136"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondAction"",
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
        m_AttackActions_SecondAction = m_AttackActions.FindAction("SecondAction", throwIfNotFound: true);
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
    private readonly InputAction m_AttackActions_SecondAction;
    public struct AttackActionsActions
    {
        private @WeaponControls m_Wrapper;
        public AttackActionsActions(@WeaponControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_AttackActions_Aim;
        public InputAction @Attack => m_Wrapper.m_AttackActions_Attack;
        public InputAction @SecondAction => m_Wrapper.m_AttackActions_SecondAction;
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
                @SecondAction.started -= m_Wrapper.m_AttackActionsActionsCallbackInterface.OnSecondAction;
                @SecondAction.performed -= m_Wrapper.m_AttackActionsActionsCallbackInterface.OnSecondAction;
                @SecondAction.canceled -= m_Wrapper.m_AttackActionsActionsCallbackInterface.OnSecondAction;
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
                @SecondAction.started += instance.OnSecondAction;
                @SecondAction.performed += instance.OnSecondAction;
                @SecondAction.canceled += instance.OnSecondAction;
            }
        }
    }
    public AttackActionsActions @AttackActions => new AttackActionsActions(this);
    public interface IAttackActionsActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSecondAction(InputAction.CallbackContext context);
    }
}
