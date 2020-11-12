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
            ""name"": ""Shooter"",
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
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Shooter
        m_Shooter = asset.FindActionMap("Shooter", throwIfNotFound: true);
        m_Shooter_Aim = m_Shooter.FindAction("Aim", throwIfNotFound: true);
        m_Shooter_Shoot = m_Shooter.FindAction("Shoot", throwIfNotFound: true);
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

    // Shooter
    private readonly InputActionMap m_Shooter;
    private IShooterActions m_ShooterActionsCallbackInterface;
    private readonly InputAction m_Shooter_Aim;
    private readonly InputAction m_Shooter_Shoot;
    public struct ShooterActions
    {
        private @WeaponControls m_Wrapper;
        public ShooterActions(@WeaponControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Shooter_Aim;
        public InputAction @Shoot => m_Wrapper.m_Shooter_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Shooter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShooterActions set) { return set.Get(); }
        public void SetCallbacks(IShooterActions instance)
        {
            if (m_Wrapper.m_ShooterActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_ShooterActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ShooterActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ShooterActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_ShooterActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ShooterActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ShooterActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_ShooterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public ShooterActions @Shooter => new ShooterActions(this);
    public interface IShooterActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
