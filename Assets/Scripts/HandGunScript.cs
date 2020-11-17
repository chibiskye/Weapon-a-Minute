﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunScript : MonoBehaviour
{
    [SerializeField] private Camera m_camera = null;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletSpawnPoint = null;
    [SerializeField] private float range = 30.0f;
    [SerializeField] private float fireRate = 0.5f;
    // [SerializeField] private int hitDamage = 10; // not used yet
    
    private WeaponControls weaponControls = null;
    private int layerMask = ~((1 << 8) | (1 << 10)); //shooting does not affect the player or other bullets
    private bool canShoot = true;
    // private float nextTimeToFire = 0f; //currently not used

    void Awake()
    {
        weaponControls = new WeaponControls();
        weaponControls.GunInputs.Shoot.performed += _ => Shoot();
    }

    void OnEnable()
    {
        weaponControls.Enable();
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
        Debug.Log("shooting");

        // Draw raycast
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

        // Instantiate bullet
        GameObject g = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation, bulletSpawnPoint);
        g.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        g.SetActive(true);

        // Prevents gun from shooting multiple shots too quickly
        StartCoroutine(WaitToShoot());
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