using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void FixedUpdate(){
        transform.LookAt(Camera.main.transform);
    }
}
