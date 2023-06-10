using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPullout : MonoBehaviour
{
    [Header("Weapons")]
    public GameObject sword;
    public GameObject sling;
    public GameObject staff;

    [Header("Key Bindings")]
    public KeyCode swordKey = KeyCode.Alpha1;
    public KeyCode slingKey = KeyCode.Alpha2;
    public KeyCode staffKey = KeyCode.Alpha3;

    private Dictionary<KeyCode, GameObject> weapons;
    private Animator currentWeaponAnimator;
    private GameObject currentWeapon;

    private void Start()
    {
        // Initialize the weapons dictionary
        weapons = new Dictionary<KeyCode, GameObject>
        {
            { swordKey, sword },
            { slingKey, sling },
            { staffKey, staff }
        };
    }

    private void Update()
    {
        foreach (KeyCode key in weapons.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                // Check if the pressed key corresponds to the currently active weapon
                if (currentWeaponAnimator != null && weapons[key] == currentWeapon)
                {
                    PutBackWeapon();
                }
                else
                {
                    SwitchWeapon(weapons[key]);
                }
                break;
            }
        }
    }

    private void SwitchWeapon(GameObject weapon)
    {
        if (currentWeaponAnimator != null)
        {
            PutBackWeapon();
        }

        currentWeapon = weapon;
        currentWeaponAnimator = weapon.GetComponent<Animator>();
        currentWeaponAnimator.SetTrigger("Pull");
    }

    private void PutBackWeapon()
    {
        if (currentWeaponAnimator != null)
        {
            currentWeaponAnimator.SetTrigger("PutBack");
            currentWeaponAnimator = null;
            currentWeapon = null;
        }
    }
}








