using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private GameObject bananaPeelPrefab = null;
    [SerializeField] private float swingRange = 5.0f;
    // [SerializeField] private int swingDamage = 1;
    [SerializeField] private float waitTime = 5.0f;
    [SerializeField] private AudioSource giggle = null;

    private WeaponControls weaponControls = null;
    private Rigidbody rigidBody = null;
    private Collider m_collider = null;
    private bool ready = true;
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player
    private bool beenThrown = false;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        m_collider = GetComponent<Collider>();

        weaponControls = new WeaponControls();
        weaponControls.BananaInputs.Throw.performed += _ => Throw();

        ready = true;
    }

    void Start()
    {
        playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Camera>();
    }

    void OnEnable()
    {
        beenThrown = false;
        ready = true;
        if (weaponControls == null) { return; }
        weaponControls.Enable();
    }

    void OnDisable()
    {
        if (weaponControls == null) { return; }
        weaponControls.Disable();
    }

    void FixedUpdate()
    {
        GetComponentInChildren<MeshRenderer>().enabled = ready; //Hide when not ready
        m_collider.enabled = ready;
        DebugRaycast();
    }

    IEnumerator WaitForNextBanana()
    {
        ready = false;
        yield return new WaitForSeconds(waitTime);
        ready = true;
    }

    void Throw()
    {
        // Check if player still has weapon in hand
        if(!ready) { return; };
        Debug.Log("Hehehe");
        giggle.Play();

        // Update state
        beenThrown = true;
        //gameObject.SetActive(false);
        StartCoroutine(WaitForNextBanana());

        //To represent the player throwing the banana as a banana peel, without destroying the gameobject 
        //This way the player can use the banana again when it is time to switch weapons
        GameObject bananaPeel = Instantiate(bananaPeelPrefab, transform.position, transform.rotation);
        bananaPeel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, swingRange, layerMask))
        {
            Debug.DrawRay(rayOrigin, playerCamera.transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(rayOrigin, playerCamera.transform.forward * 1000, Color.white);
        }
    }
}
