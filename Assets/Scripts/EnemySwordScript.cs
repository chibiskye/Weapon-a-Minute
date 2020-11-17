using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordScript : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin = null;
    [SerializeField] private float range = 8.0f;
    [SerializeField] private int hitDamage = 10;

    private int layerMask = ~(1 << 12); //attacking doesn't affect the enemies (no friendly fire amongst us)

    // Update is called once per frame
    void FixedUpdate()
    {
        DebugRaycast();
    }

    public void Attack()
    {
        // TODO: assume weapon is a sword, replace with other weapons in the future
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, transform.forward, out hit, range, layerMask))
        {
            if (hit.transform.gameObject.layer == 8)    // successfully hit the player
            {
                Debug.Log("Attack in the name of our Lord and Savior!!!");
            }
            else    // hit something else other than the player
            {
                Debug.Log("If you have the guts, stand there and let me hit you!");
            }
        }
        else
        {
            Debug.Log("Come back here you cowardly trespasser!");
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
