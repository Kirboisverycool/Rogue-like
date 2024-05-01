using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPickups : MonoBehaviour
{
    public Transform dropPoint;
    public GameObject pistolPrefab;
    public GameObject fastGunPrefab;
    public GameObject heavyGunPrefab;

    public int selectedWeapon = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        SelectedWeapon();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "FastGun":
                StartFastGunSequence();
                break;
            case "Pistol":
                StartPistolSequence();
                break;
            case "Heavy":
                StartHeavySequence();
                break;
        }
    }

    private void StartHeavySequence()
    {
        foreach (Transform weapon in transform)
        {
            if (selectedWeapon == 0)
            {
                GameObject pistol = Instantiate(pistolPrefab, dropPoint.position, dropPoint.rotation);
            }
            if (selectedWeapon == 1)
            {
                GameObject FastGun = Instantiate(fastGunPrefab, dropPoint.position, dropPoint.rotation);
            }
        }
        selectedWeapon = 2;
    }

    private void StartPistolSequence()
    {
        foreach(Transform weapon in transform)
        {
            if(selectedWeapon == 1)
            {
                GameObject FastGun = Instantiate(fastGunPrefab, dropPoint.position, dropPoint.rotation);
            }
            if (selectedWeapon == 2)
            {
                GameObject heavy = Instantiate(heavyGunPrefab, dropPoint.position, dropPoint.rotation);
            }
        }
        selectedWeapon = 0;
    }

    private void StartFastGunSequence()
    {
        foreach (Transform weapon in transform)
        {
            if (selectedWeapon == 0)
            {
                GameObject pistol = Instantiate(pistolPrefab, dropPoint.position, dropPoint.rotation);
            }
            if (selectedWeapon == 2)
            {
                GameObject heavy = Instantiate(heavyGunPrefab, dropPoint.position, dropPoint.rotation);
            }
        }
        selectedWeapon = 1;
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
