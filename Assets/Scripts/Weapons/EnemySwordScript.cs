using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordScript : WeaponScript
{
    [SerializeField] private Transform raycastOrigin = null;
    [SerializeField] private float range = 8.0f;
    [SerializeField] private int hitDamage = 10;

    private Animation anim = null;
    private int layerMask = ~(1 << 12); //attacking doesn't affect the enemies (no friendly fire amongst us)

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DebugRaycast();
    }

    public override void Attack()
    {
        // TODO: assume weapon is a sword, replace with other weapons in the future
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, transform.forward, out hit, range, layerMask))
        {
            Health opponentHealth = hit.collider.GetComponent<Health>();
            if (opponentHealth != null) // successfully hit the player
            {
                Debug.Log("Opponent: Attack in the name of our Lord and Savior!!!");
                opponentHealth.LoseHealth(hitDamage);
            }
            else // hit something else other than the player
            {
                Debug.Log("Opponent: If you have the guts, stand there and let me hit you!");
            }

            // Play attack animation
            anim.Play();
        }
        else
        {
            Debug.Log("Opponent: Come back here you cowardly trespasser!");
        }
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, transform.forward, out hit, range, layerMask))
        {
            Debug.DrawRay(raycastOrigin.position, transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(raycastOrigin.position, transform.forward * 1000, Color.white);
        }
    }
}
