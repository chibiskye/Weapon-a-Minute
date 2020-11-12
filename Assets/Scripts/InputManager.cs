using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // InputManager is a singleton
    private static InputManager _instance;
    public static InputManager Instance
    {
        get {
            return _instance;
        }
    }

    private PlayerControls playerControls = null;

    // Awake is called once before Start
    void Awake()
    {
        // Instantiate singleton instance of InputManager
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        // Instantiate player controls input actions
        playerControls = new PlayerControls();
    }

    // OnEnable is called when script is enabled
    void OnEnable()
    {
        playerControls.Enable();
    }

    // OnDisable is called when script is disabled
    void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Movement.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Movement.Look.ReadValue<Vector2>();
    }
}
