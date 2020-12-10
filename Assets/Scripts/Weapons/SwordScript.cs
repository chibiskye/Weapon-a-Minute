using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private Camera m_camera = null;
    [SerializeField] private float range = 8.0f;
    [SerializeField] private int hitDamage = 10;
    [SerializeField] private float hitRate = 0.8f;

    private WeaponControls weaponControls = null;
    private Animation anim = null;
    private bool canSwing = true;
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player

    void Awake()
    {
        anim = GetComponent<Animation>();

        weaponControls = new WeaponControls();
        weaponControls.SwordInputs.Swing.performed += _ => Swing();
    }

    void OnEnable()
    {
        weaponControls.Enable();
    }

    void OnDisable()
    {
        weaponControls.Disable();
    }

    IEnumerator WaitToSwing()
    {
        canSwing = false;
        yield return new WaitForSeconds(hitRate);
        canSwing = true;
    }

    void FixedUpdate()
    {
        DebugRaycast();
    }

    void Swing()
    {
        if (!canSwing) return;
        // Quaternion original_rotation = transform.rotation;
        // transform.rotation = new Quaternion(0, -45, 0, 0);
        anim.Play();
        // transform.rotation = original_rotation;

        Vector3 rayOrigin = m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.25f, m_camera.nearClipPlane));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, m_camera.transform.forward, out hit, range, layerMask))
        {
            Health opponentHealth = hit.collider.GetComponent<Health>();
            if (opponentHealth != null) // successfully hit the opponent
            {
                opponentHealth.LoseHealth(hitDamage);
                Debug.Log("I'll stab you to death!");
            }
            else 
            {
                Debug.Log("I dare you to come closer!");
            }
        }
        StartCoroutine(WaitToSwing());
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        Vector3 rayOrigin = m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, m_camera.nearClipPlane));
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
