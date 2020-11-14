using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private float range = 3.0f;

    private InputManager inputManager = null;
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    void DebugRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DebugRaycast();

        // Check if player clicked button for swing
        bool playerSwing = inputManager.GetPlayerAttacked();
        if (playerSwing) Swing();

    }

    void Swing()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask))
        {
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }
}
