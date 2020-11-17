using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordScript : MonoBehaviour
{


    [SerializeField] private float range = 8.0f;
    private int layerMask = ~(1 << 13); //attacking doesn't affect the enemies



    // Start is called before the first frame update
    void Start()
    {

    }

    public void Attack()
    {
        //For now we assume the weapon is holding a sword
        Vector3 rayOrigin = transform.position;
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, transform.forward, out hit, range, layerMask))
        {
            Debug.Log(hit.transform.name);
        }
        else
        {
            Debug.Log("missed");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        DebugRaycast();
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugRaycast()
    {
        Vector3 rayOrigin = transform.position;
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, transform.forward, out hit, range, layerMask))
        {
            Debug.DrawRay(rayOrigin, transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(rayOrigin, transform.forward * 1000, Color.white);
        }
    }
}
