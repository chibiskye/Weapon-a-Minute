using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    [SerializeField] private Camera m_camera = null;
    [SerializeField] private float swingRange = 5.0f;
    [SerializeField] private float throwForce = 400f;
    [SerializeField] private int swingDamage = 1;
    [SerializeField] private int throwDamage = 10;

    private WeaponControls weaponControls = null;
    private Rigidbody rigidBody = null;
    private Collider collider = null;
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
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DebugRaycast();
    }

    IEnumerator tempTrigger()
    {
        //temporarily make it a trigger
        collider.isTrigger = true;
        yield return new WaitForSeconds(0.5f);
        collider.isTrigger = false;
    }

    void Throw()
    {
        // Update state
        Debug.Log("throwing");

        // Detach weapon from player
        transform.parent = null;

        // Unfreeze the position, but still freeze the rotation
        rigidBody.constraints = RigidbodyConstraints.None;
        rigidBody.freezeRotation = true;

        beenThrown = true;
        StartCoroutine(tempTrigger());
        Vector3 throwDirection = transform.forward + new Vector3(100f, 0f, 0f);
        rigidBody.AddForce(throwDirection * throwForce);
        rigidBody.useGravity = true;
    }

    void Swing()
    {
        // Check if weapon still in player's hand
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

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with " + collision.gameObject.name);

        // Check if weapon has been thrown
        if (!beenThrown) return;

        // Check if other collider is damageable
        if (collision.gameObject.layer == 11)
        {
            collider.isTrigger = false;
            rigidBody.velocity = Vector3.zero;
        }
        else 
        {
            Debug.Log("Damage");
            // TODO: damage the player/enemy that the weapon collided with
            Destroy(gameObject);
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
