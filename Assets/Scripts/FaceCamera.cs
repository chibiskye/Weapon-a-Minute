using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private GameObject camera = null;
    void FixedUpdate(){
        transform.LookAt(camera.transform);
    }
}
