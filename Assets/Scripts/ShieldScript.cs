using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    [SerializeField] private Camera m_camera = null;
    [SerializeField] private float range = 8.0f;
    // [SerializeField] private int hitDamage = 10; // not used yet

    private WeaponControls weaponControls = null;
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
        weaponControls.Enable();
    }

    void OnDisable()
    {
        weaponControls.Disable();
    }

    void FixedUpdate()
    {
        DebugRaycast();
    }

    void Block()
    {
        // Check if player is performing one action at a time
        if (!canDefend) return;

        // TODO: player should not be able to block if hit from behind
        
        Debug.Log("blocking");
        canAttack = false;
    }

    void Unblock()
    {
        // Check if player is performing one action at a time
        if (!canDefend) return;

        Debug.Log("not blocking");
        canAttack = true;
    }

    void ShieldBash()
    {
        // Check if player is performing on action at a time
        if (!canAttack) return;
        canDefend = false;

        Vector3 rayOrigin = m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, m_camera.transform.forward, out hit, range, layerMask))
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

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        Vector3 rayOrigin = m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, m_camera.transform.forward, out hit, range, layerMask))
        {
            Debug.DrawRay(rayOrigin, m_camera.transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(rayOrigin, m_camera.transform.forward * 1000, Color.white);
        }
    }
}
