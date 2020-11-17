using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunBulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private int hitDamage = 10;

    private Rigidbody rigidBody = null;
    private float timeToLive = 3f;

    // Deletes self after a set amount of time
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * speed;
        StartCoroutine(DestroySelf());
    }

    // OnTriggerEnter is called whenever the game object collides with another collider
    void OnTriggerEnter(Collider other)
    {
        // Destroy bullet regardless of what it hit
        Destroy(gameObject);

        // Check if player was hit
        Health opponentHealth = other.GetComponent<Health>();
        if (opponentHealth != null) // successfully hit the player
        {
            opponentHealth.LoseHealth(hitDamage);
            Debug.Log("Opponent: Arg! Good shot!");
        }
    }
}
