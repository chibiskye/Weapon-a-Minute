using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    [SerializeField] private Camera m_camera = null;
    [SerializeField] private GameObject bananaPeelPrefab = null;
    [SerializeField] private float swingRange = 5.0f;
    [SerializeField] private int swingDamage = 1;

    private WeaponControls weaponControls = null;
    private Rigidbody rigidBody = null;
    private Collider m_collider = null;
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player
    private bool beenThrown = false;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        m_collider = GetComponent<Collider>();

        weaponControls = new WeaponControls();
        weaponControls.BananaInputs.Swing.performed += _ => Swing();
        weaponControls.BananaInputs.Throw.performed += _ => Throw();
    }

    void OnEnable()
    {
        beenThrown = false;
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

    void Throw()
    {
        // Check if player still has weapon in hand
        if (beenThrown) return;
        Debug.Log("Hehehe");

        // Update state
        beenThrown = true;
        gameObject.SetActive(false);

        //To represent the player throwing the banana as a banana peel, without destroying the gameobject 
        //This way the player can use the banana again when it is time to switch weapons
        GameObject bananaPeel = Instantiate(bananaPeelPrefab, transform.position, transform.rotation);
        bananaPeel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    void Swing()
    {
        // Check if player still has weapon in hand
        if (beenThrown) return;

        // Draw raycast
        Vector3 rayOrigin = m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, m_camera.transform.forward, out hit, swingRange, layerMask))
        {
            Health opponentHealth = hit.collider.GetComponent<Health>();
            if (opponentHealth != null) // successfully hit the opponent
            {
                Debug.Log("I slap you with a banana!");
                opponentHealth.LoseHealth(swingDamage);
            }
            else // hit something else other than the player
            {
                Debug.Log("Why are you dodging so seriously? Scared of a tiny little banana?");
            }
        }
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        Vector3 rayOrigin = m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, m_camera.transform.forward, out hit, swingRange, layerMask))
        {
            Debug.DrawRay(rayOrigin, m_camera.transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(rayOrigin, m_camera.transform.forward * 1000, Color.white);
        }
    }
}
