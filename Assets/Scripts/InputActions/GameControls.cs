// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""GameState"",
            ""id"": ""e8c93e55-0b37-43bc-84a0-e5d1f13bb99e"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""00768d01-76c9-4d53-923b-c25a95d880f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bbaf8a2d-aaf8-415f-9d6c-9b1e92c08106"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16025fa5-0bf5-4a4a-a967-4bf77ead879e"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameState
        m_GameState = asset.FindActionMap("GameState", throwIfNotFound: true);
        m_GameState_Pause = m_GameState.FindAction("Pause", throwIfNotFound: true);
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

    // GameState
    private readonly InputActionMap m_GameState;
    private IGameStateActions m_GameStateActionsCallbackInterface;
    private readonly InputAction m_GameState_Pause;
    public struct GameStateActions
    {
        private @GameControls m_Wrapper;
        public GameStateActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GameState_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GameState; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameStateActions set) { return set.Get(); }
        public void SetCallbacks(IGameStateActions instance)
        {
            if (m_Wrapper.m_GameStateActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameStateActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameStateActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameStateActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameStateActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameStateActions @GameState => new GameStateActions(this);
    public interface IGameStateActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
