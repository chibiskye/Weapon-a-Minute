using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunScript : MonoBehaviour
{
    public GameObject bullet;

    [SerializeField] float range = 3.0f;
    public float fireRate = 15f; //currently not used

    private float nextTimeToFire = 0f; //currently not used
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        int layerMask = 1 << 8; //does not affect the player
        layerMask = ~layerMask;


        if (Input.GetButtonDown("Fire1") )//&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, range, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
           // Debug.Log("Did not Hit");
        }
    }

    void Shoot()
    {
        Debug.Log("shooting");
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
