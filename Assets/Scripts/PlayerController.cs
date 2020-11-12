using UnityEngine;

// Script will not run if game object does not have a character controller component
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    // SerializeField makes private variables visible in the Inspector without making the variable public to other scripts
    [SerializeField] private LayerMask detectMasks;
    [SerializeField] private Transform groundTransform = null;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float moveSpeed = 10f;

    private CharacterController characterController = null;
    private InputManager inputManager = null;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Prevent additional player movement when player is in mid-air
        isGrounded = Physics.CheckSphere(groundTransform.position, groundDistance, detectMasks);
        if (!isGrounded) return;

        // Read movement value from input controls
        Vector2 moveInput = inputManager.GetPlayerMovement();
        bool jumpInput = inputManager.GetPlayerJumped();
        if (jumpInput) {
            Debug.Log("jumped");
        }

        // Move the player
        Vector3 moveVector = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move(moveVector.normalized * moveSpeed * Time.deltaTime);
    }
}
