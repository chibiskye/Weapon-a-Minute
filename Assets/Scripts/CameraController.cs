﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float upViewLimit = -90f;
    [SerializeField] private float downViewLimit = 90f;

    private CameraControls cameraControls = null;
    private float xRotation = 0f;

    // Awake is called once before the Start method
    void Awake()
    {
        // Lock cursor to center of screen and make it invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        cameraControls = new CameraControls();
    }

    // OnEnable is called when script is first enabled
    void OnEnable()
    {
        cameraControls.Enable();
    }

    // OnDisable is called when script is disabled
    void OnDisable()
    {
        cameraControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Read mouse position from input controls
        Vector2 lookInput = cameraControls.Player.Look.ReadValue<Vector2>();
        float lookX = lookInput.x * mouseSensitivity * Time.deltaTime;
        playerTransform.Rotate(Vector3.up * lookX);
        
    }
}
