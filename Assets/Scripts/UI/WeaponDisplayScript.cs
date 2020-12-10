// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponDisplayScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text = null;

    public void DisplayWeapon(string weapon)
    {
        text.SetText(weapon);
    }
}
