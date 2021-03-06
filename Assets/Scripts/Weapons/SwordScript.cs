﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private float range = 8.0f;
    [SerializeField] private int hitDamage = 10;
    [SerializeField] private float hitRate = 0.8f;
    [SerializeField] private AudioSource hitSound = null;
    [SerializeField] private AudioSource letMeHitYou = null;

    private WeaponControls weaponControls = null;
    private Animation anim = null;
    private bool canSwing = true;
    private bool swungOnce = false;
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player
    private bool spoken = false;

    void Awake()
    {
        anim = GetComponent<Animation>();
        //hitSound = GetComponent<AudioSource>();

        weaponControls = new WeaponControls();
        weaponControls.SwordInputs.Swing.performed += _ => Swing();

        canSwing = true;
    }

    void OnEnable()
    {
        weaponControls.Enable();

        canSwing = true;
        swungOnce = false;
        spoken = false;
        hitSound.enabled = true;
    }

    void OnDisable()
    {
        weaponControls.Disable();
        hitSound.enabled = false;
    }

    void Start()
    {
        playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Camera>();
    }

    IEnumerator WaitToSwing()
    {
        canSwing = false;
        yield return new WaitForSeconds(hitRate);
        canSwing = true;
    }

    void FixedUpdate()
    {
        DebugRaycast();
    }

    void Swing()
    {
        Debug.Log("A");
        if (!canSwing) return;
        Debug.Log("B");
        // Quaternion original_rotation = transform.rotation;
        // transform.rotation = new Quaternion(0, -45, 0, 0);
        anim.Play();
        // transform.rotation = original_rotation;

        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.25f, playerCamera.nearClipPlane));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, range, layerMask))
        {
            HealthScript opponentHealth = hit.collider.GetComponent<HealthScript>();
            if (opponentHealth != null) // successfully hit the opponent
            {
                if (!swungOnce) {
                    hitSound.Play();
                }
                opponentHealth.LoseHealth(hitDamage);
                Debug.Log("I'll stab you to death!");
            }
            else 
            {
                Debug.Log("I dare you to come closer!");
                if (!spoken) {
                    letMeHitYou.Play();
                    spoken = true;
                }
            }
        }
        StartCoroutine(WaitToSwing());
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, playerCamera.nearClipPlane));
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
