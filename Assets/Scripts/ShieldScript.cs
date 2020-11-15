using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    // TODO: player should not be able to block if hit from behind

    [SerializeField] private Camera camera = null;
    [SerializeField] private float attackRange = 5.0f;
    // [SerializeField] private int hitDamage = 10; // not used yet

    private WeaponControls weaponControls = null;
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player
    private bool canDefend = true;
    private bool canAttack = true;

    void Awake()
    {
        weaponControls = new WeaponControls();

        // Detect player input
        weaponControls.AttackActions.Attack.performed += _ => ShieldBash();
        weaponControls.DefendActions.BlockStart.performed += _ => Blocking();
        weaponControls.DefendActions.BlockEnd.performed += _ => NotBlocking();
    }

    void OnEnable()
    {
        weaponControls.Enable();
    }

    void OnDisable()
    {
        weaponControls.Disable();
    }

    void NotBlocking()
    {
        // Check if player is performing one action at a time
        if (!canDefend) return;

        Debug.Log("done blocking");
        canAttack = true;
    }


    void Blocking()
    {
        // Check if player is performing one action at a time
        if (!canDefend) return;
        
        Debug.Log("blocking");
        canAttack = false;
    }

    void DebugRaycast()
    {
        Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, camera.transform.forward, out hit, attackRange, layerMask))
        {
            Debug.DrawRay(rayOrigin, camera.transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(rayOrigin, camera.transform.forward * 1000, Color.white);
        }
    }

    void FixedUpdate()
    {
        DebugRaycast();
    }

    void ShieldBash()
    {
        // Check if player is performing on action at a time
        if (!canAttack) return;
        canDefend = false;

        Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, camera.transform.forward, out hit, attackRange, layerMask))
        {
            Debug.Log(hit.transform.name);
        }
        else
        {
            Debug.Log("missed");
        }

        // End attack action
        canDefend = true;
    }
}
