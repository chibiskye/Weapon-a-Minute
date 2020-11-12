using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunBulletScript : MonoBehaviour
{
    public Rigidbody rigidbody;

    public float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
