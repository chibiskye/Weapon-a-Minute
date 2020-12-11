using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;

    void Start()
    {
        playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Camera>();
    }

    void FixedUpdate() {
        transform.LookAt(playerCamera.transform);
    }
}
