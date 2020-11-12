using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletParent = null;
    [SerializeField] private Transform shootDirection = null;
    // [SerializeField] private float range = 3.0f;
    [SerializeField] private float fireRate = 1.0f;
    
    private InputManager inputManager;
    private bool canShoot = true;
    // private float nextTimeToFire = 0f; //currently not used

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
        // weaponControls.Shooter.Shoot.performed += _ => Shoot();
    }

    void Update()
    {
        // Check if player clicked button for shoot
        bool playerShoot = inputManager.GetPlayerAttacked();
        if (playerShoot) Shoot();
    }

    // void FixedUpdate()
    // {
    //     int layerMask = 1 << 8; //does not affect the player
    //     layerMask = ~layerMask;

    //     if (Input.GetButtonDown("Fire1") )//&& Time.time >= nextTimeToFire)
    //     {
    //         nextTimeToFire = Time.time + 1f / fireRate;
    //         Shoot();
    //     }

    //     RaycastHit hit;
    //     if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, range, layerMask))
    //     {
    //         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
    //         //Debug.Log("Did Hit");
    //     }
    //     else
    //     {
    //         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
    //        // Debug.Log("Did not Hit");
    //     }
    // }

    IEnumerator WaitToShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    void Shoot()
    {
        Debug.Log("shooting");

        // Check if able to shoot
        if (!canShoot) return;

        // Instantiate bullet
        GameObject g = Instantiate(bullet, shootDirection.position, shootDirection.rotation, bulletParent);
        g.SetActive(true);

        // Prevents gun from shooting multiple shots too quickly
        StartCoroutine(WaitToShoot());
    }
}
