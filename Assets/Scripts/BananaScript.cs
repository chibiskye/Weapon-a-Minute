using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    [SerializeField] private Camera m_camera = null;
    [SerializeField] private float swingRange = 5.0f;
    [SerializeField] private float throwForce = 5f;
    [SerializeField] private int swingDamage = 1;
    [SerializeField] private int throwDamage = 10;

    private WeaponControls weaponControls = null;
    private Rigidbody rigidBody = null;
    private Collider m_collider = null;
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player
    private bool beenThrown = false;

    void Awake()
    {
        weaponControls = new WeaponControls();
        weaponControls.BananaInputs.Swing.performed += _ => Swing();
        weaponControls.BananaInputs.Throw.performed += _ => Throw();
    }

    void OnEnable()
    {
        weaponControls.Enable();
    }

    void OnDisable()
    {
        weaponControls.Disable();
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        m_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DebugRaycast();
    }

    void Throw()
    {
        // Check if player still has weapon in hand
        if (beenThrown) return;

        // Update state
        Debug.Log("Catch this!");
        beenThrown = true;

        // Detach weapon from player
        transform.parent = null;

        // Unfreeze the position, but still freeze the rotation
        rigidBody.constraints = RigidbodyConstraints.FreezeRotation;

        // Throw banana as a projectile
        rigidBody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        rigidBody.AddForce(transform.up * throwForce, ForceMode.Impulse);

        // Make the collider a trigger
        m_collider.isTrigger = true;
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

    private void OnTriggerEnter(Collider other)
    {
        // Check if weapon has been thrown
        if (!beenThrown) return;
        Debug.Log("Collided with " + other.gameObject.name);

        // If opponent was not hit, remain in the scene
        if (other.gameObject.layer == 11)
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.useGravity = false;
        }
        // If opponent was hit, decrease opponent health and destroy self
        else if (other.gameObject.layer == 12)
        {
            Debug.Log("Opponent: A trap! I was careless!");
            Destroy(gameObject);

            Health opponentHealth = other.gameObject.GetComponent<Health>();
            opponentHealth.LoseHealth(throwDamage);
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
