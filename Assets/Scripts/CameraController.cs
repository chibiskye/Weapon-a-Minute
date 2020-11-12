using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float upViewLimit = -90f;
    [SerializeField] private float downViewLimit = 90f;

    private InputManager inputManager = null;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Read mouse position from input controls
        Vector2 lookInput = inputManager.GetMouseDelta();
        float lookX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float lookY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // Rotate camera in the y-direction (look up or down)
        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, upViewLimit, downViewLimit);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player in the x-direction (turn left or right)
        playerTransform.Rotate(Vector3.up * lookX);
    }
}
