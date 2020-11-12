﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunBulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;

    private Rigidbody rigidbody;
    private float timeToLive = 3.0f;

    // Deletes self after a set amount of time
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0f, 0f, speed);
        StartCoroutine(DestroySelf());
    }

    // OnTriggerEnter is called whenever the game object collides with another collider
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
