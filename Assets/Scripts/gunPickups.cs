using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickups : MonoBehaviour
{
    public int selectedWeapon;
    public int currentWeapon;

    public Transform dropPoint;
    public GameObject pistolPrefab;
    public GameObject fastPrefab;
    public GameObject heavyPrefab;
    public GameObject chargePrefab;
    public GameObject freezePrefab;

    public bool isTouchingPistolPickup = false;
    public bool isTouchingFastPickup = false;
    public bool isTouchingHeavyPickup = false;
    public bool isTouchingChargePickup = false;
    public bool isTouchingFreezePickup = false;

    private Dialogue dialogue;

    private void Start()
    {
        currentWeapon = selectedWeapon;
    }

    private void Update()
    {
        SelectedWeapon();

        if (isTouchingPistolPickup == true && Input.GetKeyDown(KeyCode.G))
        {
            PickupPistol();
        }
        if (isTouchingFastPickup == true && Input.GetKeyDown(KeyCode.G))
        {
            PickupFastGun();
        }
        if (isTouchingHeavyPickup == true && Input.GetKeyDown(KeyCode.G))
        {
            PickupHeavy();
        }
        if (isTouchingChargePickup == true && Input.GetKeyDown(KeyCode.G))
        {
            PickupChargeGun();
        }
        if (isTouchingFreezePickup == true && Input.GetKeyDown(KeyCode.G))
        {
            PickupFreeze();
        }
    }

    private void PickupFreeze()
    {
        if (selectedWeapon == 1)
        {
            Instantiate(fastPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 0)
        {
            Instantiate(pistolPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 2)
        {
            Instantiate(heavyPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 3)
        {
            Instantiate(chargePrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 4)
        {
            Instantiate(freezePrefab, dropPoint.position, dropPoint.rotation);
        }

        selectedWeapon = 4;
        currentWeapon = 4;


        Destroy(GameObject.FindWithTag("FreezeGun"));
    }

    private void PickupChargeGun()
    {
        if (selectedWeapon == 1)
        {
            Instantiate(fastPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 0)
        {
            Instantiate(pistolPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 2)
        {
            Instantiate(heavyPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 3)
        {
            Instantiate(chargePrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 4)
        {
            Instantiate(freezePrefab, dropPoint.position, dropPoint.rotation);
        }

        selectedWeapon = 3;
        currentWeapon = 3;


        Destroy(GameObject.FindWithTag("ChargeGun"));
    }

    private void PickupHeavy()
    {
        if (selectedWeapon == 1)
        {
            Instantiate(fastPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 0)
        {
            Instantiate(pistolPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 2)
        {
            Instantiate(heavyPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 3)
        {
            Instantiate(chargePrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 4)
        {
            Instantiate(freezePrefab, dropPoint.position, dropPoint.rotation);
        }

        selectedWeapon = 2;
        currentWeapon = 2;


        Destroy(GameObject.FindWithTag("Heavy"));
    }

    private void PickupFastGun()
    {
        if (selectedWeapon == 0)
        {
            Instantiate(pistolPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 2)
        {
            Instantiate(heavyPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 1)
        {
            Instantiate(fastPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 3)
        {
            Instantiate(chargePrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 4)
        {
            Instantiate(freezePrefab, dropPoint.position, dropPoint.rotation);
        }

        selectedWeapon = 1;
        currentWeapon = 1;


        Destroy(GameObject.FindWithTag("FastGun"));
    }

    private void PickupPistol()
    {
        if(selectedWeapon == 1)
        {
            Instantiate(fastPrefab, dropPoint.position, dropPoint.rotation);
        }
        if(selectedWeapon == 2)
        {
            Instantiate(heavyPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 0)
        {
            Instantiate(pistolPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 3)
        {
            Instantiate(chargePrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedWeapon == 4)
        {
            Instantiate(freezePrefab, dropPoint.position, dropPoint.rotation);
        }

        selectedWeapon = 0;
        currentWeapon = 0;


        Destroy(GameObject.FindWithTag("Pistol"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pistol")
        {
            isTouchingPistolPickup = true;
        }

        if (collision.gameObject.tag == "FastGun")
        {
            isTouchingFastPickup = true;
        }

        if (collision.gameObject.tag == "Heavy")
        {
            isTouchingHeavyPickup = true;
        }

        if (collision.gameObject.tag == "ChargeGun")
        {
            isTouchingChargePickup = true;
        }

        if (collision.gameObject.tag == "FreezeGun")
        {
            isTouchingFreezePickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pistol")
        {
            isTouchingPistolPickup = false;
        }

        if (collision.gameObject.tag == "FastGun")
        {
            isTouchingFastPickup = false;
        }

        if (collision.gameObject.tag == "Heavy")
        {
            isTouchingHeavyPickup = false;
        }

        if (collision.gameObject.tag == "ChargeGun")
        {
            isTouchingChargePickup = false;
        }

        if (collision.gameObject.tag == "FreezeGun")
        {
            isTouchingFreezePickup = false;
        }
    }

    private void SelectedWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
