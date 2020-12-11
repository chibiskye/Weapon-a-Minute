using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunScript : WeaponScript
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform bulletSpawnPoint = null;
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private Transform bodyTransform = null;
    [SerializeField] private float range = 30.0f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private bool isEnemy = false;
    [SerializeField] private AudioSource handGunSF = null;
    
    private WeaponControls weaponControls = null;
    private int layerMask = ~((1 << 10)); //shooting does not affect other bullets, TODO fix this
    private bool canShoot = true;

    void Awake()
    {
        if (!isEnemy)
        {
            weaponControls = new WeaponControls();
            weaponControls.GunInputs.Shoot.performed += _ => Shoot();
        }
    }

    void OnEnable()
    {
        if (weaponControls != null)
        {
            weaponControls.Enable();
        }
        canShoot = true;
        handGunSF.enabled = true;
    }

    void OnDisable()
    {
        if (weaponControls != null)
        {
            weaponControls.Disable();
        }
        handGunSF.enabled = false;
    }

    void Start()
    {
        if (!isEnemy)
        {
            playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Camera>();
        }
    }

    IEnumerator WaitToShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    void FixedUpdate()
    {
        DebugRaycast();
    }

    void Shoot()
    {
        // Check if able to shoot
        if (!canShoot) return;

        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation, bulletSpawnPoint);
        bullet.gameObject.transform.parent = null; // detaches bullet from shooter so rotation not affected by shooter
        HandGunBulletScript bulletScript = bullet.GetComponent<HandGunBulletScript>();
        bulletScript.SetRange(range);

        // Draw raycast
        Vector3 rayOrigin = (!isEnemy) ? playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f)) : bodyTransform.position;
        Transform rayTransform = (!isEnemy) ? playerCamera.transform : bodyTransform;
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayTransform.forward, out hit, range, layerMask))
        {
            handGunSF.Play();
            // bullet.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

            // Prevents gun from shooting multiple shots too quickly
            StartCoroutine(WaitToShoot());

            if (hit.transform.gameObject.layer == 12 || hit.transform.gameObject.layer == 8) // successfully hit the target
            {
                Debug.Log("Take this bullet from me!");
                bullet.transform.LookAt(hit.transform);
            }
            else // hit something else other than the player
            {
                Debug.Log("Darn! What a slippery foe!");
                bullet.transform.LookAt(hit.point);
            }
        }
        else if (Physics.Raycast(rayOrigin, rayTransform.forward, out hit, 400, layerMask))
        {
            //Enemies will only shoot if they have something to target
            if (isEnemy)
            {
                 Destroy(bullet);
                 return;
            }
            StartCoroutine(WaitToShoot());
            bullet.transform.LookAt(hit.point);
        }

        // Fire away!
        bullet.SetActive(true);
    }

    public override void Attack()
    {
        Shoot();
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        Vector3 rayOrigin = (!isEnemy) ? playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f)) : bodyTransform.position;
        Transform rayTransform = (!isEnemy) ? playerCamera.transform : bodyTransform;
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayTransform.up, out hit, range, layerMask))
        {
            // Debug.Log("D1");
            Debug.DrawRay(rayOrigin, rayTransform.forward * hit.distance, Color.yellow);
        }
        else
        {
            // Debug.Log("D2");
            Debug.DrawRay(rayOrigin, rayTransform.forward * 1000, Color.white);
        }
    }
}
