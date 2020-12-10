using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera controls implemented with the help of the following tutorials:
// - Mouse sensitivity and x-rotation = https://youtu.be/_QajrabyTJc
// - Third person Cinemachine camera = https://youtu.be/4HpC--2iowE 

public class CameraController : MonoBehaviour
{
    // [SerializeField] private Transform playerTransform = null;
    // [SerializeField] private float mouseSensitivity = 100f;
    // [SerializeField] private float upViewLimit = -90f;
    // [SerializeField] private float downViewLimit = 90f;

    private CameraControls cameraControls = null;
    // private float xRotation = 0f;

    // Awake is called once before the Start method
    void Awake()
    {
        cameraControls = new CameraControls();

        // Lock cursor to center of screen and make it invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        // // Read mouse position from input controls
        // Vector2 lookInput = cameraControls.Player.Look.ReadValue<Vector2>();
        // float lookX = lookInput.x * mouseSensitivity * Time.deltaTime;
        // float lookY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // // Rotate camera in the y-direction (look up or down)
        // xRotation -= lookY;
        // xRotation = Mathf.Clamp(xRotation, upViewLimit, downViewLimit);
        // transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // // Rotate player in the x-direction (turn left or right)
        // playerTransform.Rotate(Vector3.up * lookX);
    }
}
