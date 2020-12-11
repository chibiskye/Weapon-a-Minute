using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPatch : MonoBehaviour
{
    [SerializeField] GameObject turnOffSignal = null;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!turnOffSignal.activeSelf) {
            gameObject.SetActive(false);
        }
    }
}
