using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunScript : MonoBehaviour
{
    [SerializeField] private Camera camera = null;
    [SerializeField] private Transform laserSpawnPoint = null;
    [SerializeField] private float range = 30.0f;
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private float shootDuration = 0.01f;
    // [SerializeField] private int hitDamage = 10; // not used yet

    private InputManager inputManager = null;
    private LineRenderer laserLine = null;
    private int layerMask = ~(1 << 8); //shooting does not affect the player
    private bool canShoot = true;

    void Start()
    {
        inputManager = InputManager.Instance;
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
    IEnumerator HoldLaserLine()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(shootDuration);
        laserLine.enabled = false;
    }

    void Update()
    {
        // Check if player is able to shoot
        if (!canShoot) return;

        // Get input from input manager
        bool playerShoot = inputManager.GetPlayerAttacked();
        if (playerShoot) Shoot();
    }

    void FixedUpdate()
    {
        DebugRaycast();
    }

    void Shoot()
    {
        // Set starting point for laser line
        laserLine.SetPosition(0, laserSpawnPoint.position);

        // Gets center of camera viewport
        Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

        // Set end point for laser line and draw raycast
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, camera.transform.forward, out hit, range, layerMask))
        {
            laserLine.SetPosition(1, hit.point);
            StartCoroutine(HoldLaserLine());
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (camera.transform.forward * range));
        }
    }

    void DebugRaycast()
    {
        Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, camera.transform.forward, out hit, range, layerMask))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(rayOrigin, camera.transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(rayOrigin, camera.transform.forward * 1000, Color.white);
        }
    }
}
