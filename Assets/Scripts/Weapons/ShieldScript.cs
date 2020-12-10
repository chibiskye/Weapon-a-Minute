using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private float attackRange = 8.0f;
    [SerializeField] private int hitDamage = 10;

    private WeaponControls weaponControls = null;
    private Vector3 blockPosition = new Vector3(2f, 0f, 1.75f);
    private Vector3 holdPosition = new Vector3(0f, 0f, 1.75f);
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player
    private bool canDefend = true;
    private bool canAttack = true;

    void Awake()
    {
        weaponControls = new WeaponControls();
        weaponControls.ShieldInputs.ShieldBash.performed += _ => ShieldBash();
        weaponControls.ShieldInputs.BlockStart.performed += _ => Block();
        weaponControls.ShieldInputs.BlockEnd.performed += _ => Unblock();
    }

    void OnEnable()
    {
        // Reset default values
        canDefend = true;
        canAttack = true;
        transform.localPosition = holdPosition;
        weaponControls.Enable();
    }

    void OnDisable()
    {
        weaponControls.Disable();
    }

    void Start()
    {
        playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        DebugRaycast();
    }

    void Block()
    {
        // Check if player is performing one action at a time
        if (!canDefend) return;
        canAttack = false;

        // Move shield in front of the player
        Debug.Log("blocking");
        transform.localPosition = blockPosition;
    }

    void Unblock()
    {
        // Check if player is performing one action at a time
        if (!canDefend) return;
        canAttack = true;

        // Move shield away from front of player
        Debug.Log("not blocking");
        transform.localPosition = holdPosition;
    }

    void ShieldBash()
    {
        // Check if player is performing on action at a time
        if (!canAttack) return;
        canDefend = false;

        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, attackRange, layerMask))
        {
            Health opponentHealth = hit.collider.GetComponent<Health>();
            if (opponentHealth != null) // successfully hit the opponent
            {
                opponentHealth.LoseHealth(hitDamage);
                Debug.Log("Hahaha! How did my shield taste?");
            }
            else 
            {
                Debug.Log("There's more where that came from!");
            }
        }

        // End attack action
        canDefend = true;
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, attackRange, layerMask))
        {
            Debug.DrawRay(rayOrigin, playerCamera.transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(rayOrigin, playerCamera.transform.forward * 1000, Color.white);
        }
    }
}
