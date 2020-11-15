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
    private WeaponControls weaponControls = null;

    // Awake is called once before Start
    void Awake()
    {
        // Instantiate singleton instance of InputManager
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        // Instantiate input actions
        playerControls = new PlayerControls();
        weaponControls = new WeaponControls();
    }

    // OnEnable is called when script is enabled
    void OnEnable()
    {
        playerControls.Enable();
        weaponControls.Enable();
    }

    // OnDisable is called when script is disabled
    void OnDisable()
    {
        playerControls.Disable();
        weaponControls.Disable();
    }

    // public Vector2 GetPlayerMovement()
    // {
    //     return playerControls.Movement.Move.ReadValue<Vector2>();
    // }

    // public Vector2 GetMouseDelta()
    // {
    //     return playerControls.Movement.Look.ReadValue<Vector2>();
    // }

    // public Vector2 GetMousePosition()
    // {
    //     return weaponControls.AttackActions.Aim.ReadValue<Vector2>();
    // }

    // public bool GetPlayerJumped()
    // {
    //     return playerControls.Movement.Jump.triggered;
    // }

    // public bool GetPlayerAttacked()
    // {
    //     return weaponControls.AttackActions.Attack.triggered;
    // }

    // public bool GetPlayerIsDefending()
    // {
    //     return weaponControls.DefendActions.BlockStart.triggered;
    // }

    // public bool GetPlayerNotDefending()
    // {
    //     return weaponControls.DefendActions.BlockEnd.triggered;
    // }

    // // Below are methods used to trigger debug commands

    // public bool GetDebugHealthDecrease()
    // {
    //     return playerControls.Debug.HealthDecrease.triggered;
    // }

    // public bool GetDebugHealthIncrease()
    // {
    //     return playerControls.Debug.HealthIncrease.triggered;
    // }

    // public bool GetDebugSummonHandGun()
    // {
    //     return playerControls.Debug.SummonHandGun.triggered;
    // }

    // public bool GetDebugSummonLaserGun()
    // {
    //     return playerControls.Debug.SummonLaserGun.triggered;
    // }

    // public bool GetDebugSummonSword()
    // {
    //     return playerControls.Debug.SummonSword.triggered;
    // }

    // public bool GetDebugSummonShield()
    // {
    //     return playerControls.Debug.SummonShield.triggered;
    // }
}
