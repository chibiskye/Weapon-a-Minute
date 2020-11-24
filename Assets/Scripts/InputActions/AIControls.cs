// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/AIControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @AIControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @AIControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AIControls"",
    ""maps"": [
        {
            ""name"": ""Debug"",
            ""id"": ""6f4a89ff-cdd8-47d5-919c-5d4129223174"",
            ""actions"": [
                {
                    ""name"": ""ToggleMovement"",
                    ""type"": ""Button"",
                    ""id"": ""0f666fe3-1e5a-44b6-b848-5cea31aa33a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ccf10630-b934-4519-bdde-7e169cb1e5a4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_ToggleMovement = m_Debug.FindAction("ToggleMovement", throwIfNotFound: true);
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

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_ToggleMovement;
    public struct DebugActions
    {
        private @AIControls m_Wrapper;
        public DebugActions(@AIControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleMovement => m_Wrapper.m_Debug_ToggleMovement;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @ToggleMovement.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleMovement;
                @ToggleMovement.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleMovement;
                @ToggleMovement.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleMovement;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleMovement.started += instance.OnToggleMovement;
                @ToggleMovement.performed += instance.OnToggleMovement;
                @ToggleMovement.canceled += instance.OnToggleMovement;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IDebugActions
    {
        void OnToggleMovement(InputAction.CallbackContext context);
    }
}
