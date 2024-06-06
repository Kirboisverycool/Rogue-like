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
    public GameObject shotgunPrefab;

    public bool isTouchingPistolPickup = false;
    public bool isTouchingFastPickup = false;
    public bool isTouchingHeavyPickup = false;
    public bool isTouchingShotgunPickup = false;

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
        if (isTouchingShotgunPickup == true && Input.GetKeyDown(KeyCode.G))
        {
            PickupShotgun();
        }
    }

    private void PickupShotgun()
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
            Instantiate(shotgunPrefab, dropPoint.position, dropPoint.rotation);
        }

        selectedWeapon = 3;
        currentWeapon = 3;


        Destroy(GameObject.FindWithTag("Shotgun"));
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
            Instantiate(shotgunPrefab, dropPoint.position, dropPoint.rotation);
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
            Instantiate(shotgunPrefab, dropPoint.position, dropPoint.rotation);
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
            Instantiate(shotgunPrefab, dropPoint.position, dropPoint.rotation);
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

        if (collision.gameObject.tag == "Shotgun")
        {
            isTouchingShotgunPickup = true;
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

        if (collision.gameObject.tag == "Shotgun")
        {
            isTouchingShotgunPickup = false;
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
