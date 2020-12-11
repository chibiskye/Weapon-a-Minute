using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunScript : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private Transform laserSpawnPoint = null;
    [SerializeField] private float range = 30.0f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float shootDuration = 0.01f;
    [SerializeField] private int hitDamage = 10;
    [SerializeField] private AudioSource laserGunSF = null;
    [SerializeField] private AudioSource pinkRayLine = null;

    private WeaponControls weaponControls = null;
    private LineRenderer laserLine = null;
    private int layerMask = ~(1 << 8); //shooting does not affect the player
    private bool canShoot = true;
    private bool pinkRayLineSpoken = false;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        
        weaponControls = new WeaponControls();
        weaponControls.GunInputs.Shoot.performed += _ => Shoot();
    }

    void OnEnable()
    {
        weaponControls.Enable();
        canShoot = true;
        pinkRayLineSpoken = false;
    }

    void OnDisable()
    {
        weaponControls.Disable();
    }

    void Start()
    {
        playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Camera>();
    }

    // Makes sure that the player cannot spam laser beams
    IEnumerator WaitToShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    // Renders laser line for as long as specified shoot duration
    IEnumerator DrawLaserLine()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(shootDuration);
        laserLine.enabled = false;
    }

    void FixedUpdate()
    {
        DebugRaycast();
    }

    void Shoot()
    {
        // Check if player is able to shoot
        if (!canShoot) return;

        // Set starting point for laser line
        laserLine.SetPosition(0, laserSpawnPoint.position);

        // Gets center of playerCamera viewport
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

        // Set end point for laser line and draw raycast
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, range, layerMask))
        {
            laserGunSF.Play();

            laserLine.SetPosition(1, hit.point);
            StartCoroutine(DrawLaserLine());
            StartCoroutine(WaitToShoot());

            float distance = Vector3.Distance(rayOrigin, hit.collider.transform.position);

            HealthScript opponentHealth = hit.collider.GetComponent<HealthScript>();
            if (opponentHealth != null) // successfully hit the opponent
            {
                opponentHealth.LoseHealth((int)((distance / range) * hitDamage)); //more distance = more damage
                Debug.Log("Try and dodge this pink ray of death!");
                if (!pinkRayLineSpoken) {
                    pinkRayLine.Play();
                }
                
                pinkRayLineSpoken = true;
            }
            else 
            {
                Debug.Log("Darn! What a slippery foe!");
            }
        }
        else if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, 400, layerMask)) //TODO this can probably be simplified
        {
            laserLine.SetPosition(1, hit.point);
            StartCoroutine(DrawLaserLine());
            StartCoroutine(WaitToShoot());
        }
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, range, layerMask))
        {
            Debug.DrawRay(rayOrigin, playerCamera.transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(rayOrigin, playerCamera.transform.forward * 1000, Color.white);
        }
    }
}
