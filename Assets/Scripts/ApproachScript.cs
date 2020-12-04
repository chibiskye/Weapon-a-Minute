using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Approach(Vector3 target, float speed) {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
