using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    [SerializeField] private int value = 10;
    [SerializeField] private float rotationSpeed = 80f;
    private Collider m_collider = null;
    private bool ready;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider>();
        ready = false;
    }

    void FixedUpdate()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
        m_collider.enabled = ready;
        GetComponent<SpriteRenderer>().enabled = ready; 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (!ready) { return; }
        if (other.gameObject.tag == "Player") {
            HealthScript health = other.gameObject.GetComponent<HealthScript>();
            if (health != null) {
                health.AddHealth(value);
                Destroy(gameObject);
            }
        }
    }

    public void SetValue(int newValue)
    {
        value = newValue;
    }

    public void MakeReady()
    {
        ready = true;
    }
}
