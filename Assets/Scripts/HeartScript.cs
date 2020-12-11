using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    [SerializeField] private int value = 10;
    [SerializeField] private float rotationSpeed = 80f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") {
            HealthScript health = other.gameObject.GetComponent<HealthScript>();
            if (health != null) {
                health.AddHealth(value);
                Destroy(gameObject);
            }
        }
    }
}
