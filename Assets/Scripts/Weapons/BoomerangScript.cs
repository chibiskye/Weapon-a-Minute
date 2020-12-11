using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    [SerializeField] private Transform playerWeaponHold = null;
    [SerializeField] private float range = 25.0f;
    [SerializeField] private float throwDuration = 1.5f;
    [SerializeField] private int hitDamage = 10;
    // [SerializeField] private Transform bulletSpawnPoint = null; // reference to the bullet spawn point
    [SerializeField] private AudioSource hitSF;
    public bool isThrown; // public for debug purposes
    public bool movingForward; // public for debug purposes

    private WeaponControls weaponControls = null;
    private Rigidbody rigidBody = null;
    private IEnumerator boomCoroutine = null;
    private Camera playerCamera = null;
    private Vector3 throwLocation;
    private Quaternion originalRotation;
    private int layerMask = ~((1 << 10)); //shooting does not affect other bullets TODO fix this

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;

        weaponControls = new WeaponControls();
        weaponControls.BoomerangInputs.Throw.performed += _ => Throw();
    }

    void OnEnable()
    {
        weaponControls.Enable();

        // Brings boomerang back to the player when enabled
        isThrown = false;
        movingForward = false;
        transform.position = playerWeaponHold.position;
        transform.rotation = originalRotation;
        
        hitSF.enabled = true;
    }

    void OnDisable()
    {
        weaponControls.Disable();

        hitSF.enabled = false;
    }

    void Start()
    {
        playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Camera>();
    }

    IEnumerator Boom()
    {
        movingForward = true;
        yield return new WaitForSeconds(throwDuration);
        movingForward = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DebugRaycast();
        // Check if boomerang has been thrown
        if (isThrown)
        {
            // Rotate boomerang while still flying through the air
            transform.Rotate(0, Time.deltaTime * 500, 0);

            if (movingForward) // Boomerang either just been thrown or still moving forward
            {
                transform.position = Vector3.MoveTowards(transform.position, throwLocation, Time.deltaTime * 40);
            }
            else // Boomerang is returning back to player
            {
                transform.position = Vector3.MoveTowards(transform.position, playerWeaponHold.position, Time.deltaTime * 40);
            }

            // Boomerang returns to player position
            if (!movingForward && Vector3.Distance(playerWeaponHold.position, transform.position) < 0.1f)
            {
                Debug.Log("Boomerang retrieved");

                isThrown = false;
                transform.rotation = originalRotation;
                transform.position = playerWeaponHold.position;
                rigidBody.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    void Throw()
    {
        // Check if boomerang has been thrown already
        if (isThrown) { return; }
        Debug.Log("Boomerang deployed");

        //Set to the position of the dot
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        //transform.position = rayOrigin;
        //transform.rotation = Quaternion.Euler(Camera.main.transform.localEulerAngles);

        // originalRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        // transform.position = bulletSpawnPoint.position;
        // transform.rotation = bulletSpawnPoint.rotation;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, 400, layerMask)) {
            transform.LookAt(hit.point);
        }

        // Set throw location
        throwLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * range;
        isThrown = true;
        
        // Restart coroutine
        if (boomCoroutine != null)
        {
            StopCoroutine(boomCoroutine);
        }
        boomCoroutine = Boom();
        StartCoroutine(boomCoroutine);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bommerang collides with " + collision.gameObject.name);
        
        if (isThrown && collision.gameObject.layer != 8) // ignore player collider
        {
            hitSF.Play();
            HealthScript opponentHealth = collision.gameObject.GetComponent<HealthScript>();
            if (opponentHealth != null) // successfully hit the opponent
            {
                opponentHealth.LoseHealth(movingForward ? hitDamage : 3 * hitDamage); //more damage if boomerang is going backwards
                Debug.Log("Bet you didn't see that coming~");
            }
            else 
            {
                Debug.Log("Tch, you're lucky that obstacle was in the way.");
            }

            // Return boomerang to player if anything was hit
            StopCoroutine(boomCoroutine);
            movingForward = false;
        }
    }

    void DebugRaycast()
    {
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, 400, layerMask)) {
            Debug.DrawRay(rayOrigin, transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            // Debug.Log("D2");
            Debug.DrawRay(rayOrigin, transform.forward * 1000, Color.white);
        }
    }
}