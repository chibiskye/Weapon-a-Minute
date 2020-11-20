using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunScript : MonoBehaviour
{
    [SerializeField] private Camera m_camera = null;
    [SerializeField] private Transform laserSpawnPoint = null;
    [SerializeField] private float range = 30.0f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float shootDuration = 0.01f;
    [SerializeField] private int hitDamage = 10;

    private WeaponControls weaponControls = null;
    private LineRenderer laserLine = null;
    private int layerMask = ~(1 << 8); //shooting does not affect the player
    private bool canShoot = true;

    void Awake()
    {
        weaponControls = new WeaponControls();
        weaponControls.GunInputs.Shoot.performed += _ => Shoot();
    }

    void OnEnable()
    {
        weaponControls.Enable();
        canShoot = true;
    }

    void OnDisable()
    {
        weaponControls.Disable();
    }

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
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

        // Gets center of m_camera viewport
        Vector3 rayOrigin = m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

        // Set end point for laser line and draw raycast
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, m_camera.transform.forward, out hit, range, layerMask))
        {
            Debug.Log(hit.transform.name);

            laserLine.SetPosition(1, hit.point);
            StartCoroutine(DrawLaserLine());
            StartCoroutine(WaitToShoot());

            Health opponentHealth = hit.collider.GetComponent<Health>();
            if (opponentHealth != null) // successfully hit the opponent
            {
                opponentHealth.LoseHealth(hitDamage);
                Debug.Log("Try and dodge this pink ray of death!");
            }
            else 
            {
                Debug.Log("Darn! What a slippery foe!");
            }
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (m_camera.transform.forward * range));
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
