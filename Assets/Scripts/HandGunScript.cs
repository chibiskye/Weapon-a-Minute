using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletSpawnPoint = null;
    [SerializeField] private float range = 3.0f;
    [SerializeField] private float fireRate = 0.5f;
    
    private InputManager inputManager = null;
    private bool canShoot = true;
    int layerMask = ~((1 << 8) | (1 << 10)); //shooting does not affect the player or other bullets
    // private float nextTimeToFire = 0f; //currently not used

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    void FixedUpdate()
    {
        DebugRaycast();

        // Check if player clicked button for shoot
        bool playerShoot = inputManager.GetPlayerAttacked();
        if (playerShoot) Shoot();
    }

    void DebugRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, range, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
        }
    }

    IEnumerator WaitToShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    void Shoot()
    {
        // Check if able to shoot
        if (!canShoot) return;
        Debug.Log("shooting");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, range, layerMask))
        {
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.Log("Did not Hit");
        }

        // Instantiate bullet
        GameObject g = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation, bulletSpawnPoint);
        g.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        g.SetActive(true);

        // Prevents gun from shooting multiple shots too quickly
        StartCoroutine(WaitToShoot());
    }
}
