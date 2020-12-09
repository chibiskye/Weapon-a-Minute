using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunScript : WeaponScript
{
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletSpawnPoint = null;
    [SerializeField] private Transform camMid = null;
    [SerializeField] private Transform body = null;
    [SerializeField] private float range = 30.0f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private bool isEnemy = false;
    
    private WeaponControls weaponControls = null;
    private Camera m_camera = null;
    private int layerMask = ~((1 << 10)); //shooting does not affect other bullets TODO fix this
    private bool canShoot = true;
    // private float nextTimeToFire = 0f; //currently not used

    void Awake()
    {
        weaponControls = new WeaponControls();
        weaponControls.GunInputs.Shoot.performed += _ => Shoot();
        m_camera = Camera.main;
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

        // Draw raycast
        Vector3 rayOrigin;
        if (!isEnemy) // if the player is using the gun
        {
            rayOrigin = m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        }
        else
        {
            rayOrigin = body.position;
        }

        Transform rayTransform;
        if (!isEnemy)
        {
            rayTransform = m_camera.transform;
        }
        else
        {
            rayTransform = body;
        }
        
        RaycastHit hit;

        // Instantiate bullet
        HandGunBulletScript bulletScript = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation, bulletSpawnPoint).GetComponent<HandGunBulletScript>();
        bulletScript.SetRange(range);
        GameObject g = bulletScript.gameObject;

        if (Physics.Raycast(rayOrigin, rayTransform.forward, out hit, range, layerMask))
        {
            
            g.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

            // Prevents gun from shooting multiple shots too quickly
            StartCoroutine(WaitToShoot());

            if (hit.transform.gameObject.layer == 12 || hit.transform.gameObject.layer == 8) // successfully hit the target
            {
                Debug.Log("Take this bullet from me!");
                g.transform.LookAt(hit.transform);
            }
            else // hit something else other than the player
            {
                Debug.Log("Darn! What a slippery foe!");
                g.transform.LookAt(hit.point);
            }
            
            g.SetActive(true);
        }
        else
        {
            //Enemies will only shoot if they have something to target
            if (isEnemy)
            {
                Destroy(g);
                return;
            }
            StartCoroutine(WaitToShoot());
            g.transform.LookAt(camMid);
            g.SetActive(true);
        }
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
        Vector3 rayOrigin;
        if(!isEnemy) // if the player is using the gun
        {
            rayOrigin = m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        } else
        {
            rayOrigin = body.position;
        }
        Transform rayTransform;
        if (!isEnemy)
        {
            rayTransform = m_camera.transform;
        }
        else
        {
            rayTransform = body;
        }
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, rayTransform.up, out hit, range, layerMask))
        {
            Debug.Log("D1");
            Debug.DrawRay(rayOrigin, rayTransform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.Log("D2");
            Debug.DrawRay(rayOrigin, rayTransform.forward * 1000, Color.white);
        }
    }
}
