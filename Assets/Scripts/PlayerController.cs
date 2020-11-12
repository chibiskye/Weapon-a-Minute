using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // SerializeField makes private variables visible in the Inspector without making the variable public to other scripts
    [SerializeField] private float movementSpeed;

    private PlayerControls playerControls;
    private CharacterController characterController;

    // Awake is called once before Start
    void Awake()
    {
        playerControls = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // OnEnable is called when script is enabled
    void OnEnable()
    {
        playerControls.Enable();
    }

    // OnDisable is called when script is disabled
    void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Read movement value from input controls
        Vector2 movementInput = playerControls.Default.Move.ReadValue<Vector2>();
        Vector3 moveVector = new Vector3(movementInput.x, 0f, movementInput.y);

        // Move the player
        characterController.Move(moveVector * movementSpeed * Time.deltaTime);
    }
}
