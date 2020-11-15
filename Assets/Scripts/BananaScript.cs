using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    [SerializeField] private Camera m_camera = null;
    [SerializeField] private float range = 5.0f;

    private WeaponControls weaponControls = null;
    private Rigidbody rigidBody = null;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DebugRaycast();

        // Check if weapon still in player's hand
        if (beenThrown) return;
    }

    void Throw()
    {
        // Update state
        Debug.Log("throwing");
        beenThrown = true;

        rigidBody.AddForce(new Vector3(1, 1, 1) * 400f);
        rigidBody.useGravity = true;
    }

    void Swing()
    {
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with " + collision.gameObject.name);

        // Check if weapon has been thrown
        if (!beenThrown) return;

        // Check if other collider is damageable
        if (collision.gameObject.layer == 11)
        {
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
