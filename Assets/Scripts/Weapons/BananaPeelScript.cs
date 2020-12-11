using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPeelScript : MonoBehaviour
{
    [SerializeField] private int throwDamage = 10;
    [SerializeField] private float throwForce = 5f;
    [SerializeField] private AudioSource sf;
    private Rigidbody rigidBody = null;
    private Collider m_collider = null;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        m_collider = GetComponent<Collider>();

        // Throw banana peel as a projectile
        rigidBody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        rigidBody.AddForce(transform.up * throwForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Collided with " + other.gameObject.name);

        // If opponent was not hit, remain in the scene
        if (other.gameObject.layer == 11)
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.useGravity = false;
        }
        // If opponent was hit, decrease opponent health and destroy self
        else if (other.gameObject.layer == 12)
        {
            sf.Play();
            Debug.Log("Opponent: A trap! I was careless!");
            Destroy(gameObject, 0.5f);

            HealthScript opponentHealth = other.gameObject.GetComponent<HealthScript>();
            if (opponentHealth != null) {
                opponentHealth.LoseHealth(throwDamage);
            }
        }
    }
}
