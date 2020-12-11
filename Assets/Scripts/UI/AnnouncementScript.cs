using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnnouncementScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponAnnounceText = null;
    [SerializeField] private TextMeshProUGUI countdown = null;
    // [SerializeField] private float warningTime = 2f;
    [SerializeField] private float announceTime = 5f;

    private Dictionary<string, string> weaponAnnounceMsg = null;

    void Awake()
    {
        weaponAnnounceText.text = "";
        weaponAnnounceText.enabled = false;
        // countdown.text = "";
        // countdown.enabled = false;

        weaponAnnounceMsg = new Dictionary<string, string>();
        weaponAnnounceMsg.Add("WeaponChange", "One minute is up! Weapon changing soon!");
        weaponAnnounceMsg.Add("Sword", "You received a sword you picked up off the ground!");
        weaponAnnounceMsg.Add("HandGun", "You received a pistol that somehow fell from the sky!");
        weaponAnnounceMsg.Add("LaserGun", "You received a laser gun that the aliens left behind!");
        weaponAnnounceMsg.Add("Boomerang", "You received a boomerang you bought in a gift shop!");
        weaponAnnounceMsg.Add("Banana", "You received an unlimited supply of bananas!");
        weaponAnnounceMsg.Add("Hammer", "You received a hammer used to make rice cake!");
        weaponAnnounceMsg.Add("Bamboo", "You received an old monk's bamboo staff!");
    }

    // public IEnumerator InitiateCountdown()
    // {
    //     if (countdown == null) yield break;
    //     countdown.enabled = true;
    //     countdown.text = "3";
    //     yield return new WaitForSeconds(1f * Time.deltaTime);
    //     countdown.text = "2";
    //     yield return new WaitForSeconds(1f * Time.deltaTime);
    //     countdown.text = "1";
    //     yield return new WaitForSeconds(1f * Time.deltaTime);
    //     countdown.text = "";
    //     countdown.enabled = false;
    // }

    public IEnumerator Announce(string weaponName)
    {
        if (weaponAnnounceText == null) yield break;
        weaponAnnounceText.enabled = true;

        string msg = weaponAnnounceMsg[weaponName];
        weaponAnnounceText.text = msg;
        if (weaponName == "WeaponChange")
        {
            yield break;
        }
        else if (msg != "")
        {
            yield return new WaitForSeconds(announceTime);
        }
        else 
        {
            Debug.Log($"Unknown weapon name: {weaponName}");
        }

        weaponAnnounceText.text = "";
        weaponAnnounceText.enabled = false;
    }
}
