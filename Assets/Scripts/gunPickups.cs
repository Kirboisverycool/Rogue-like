using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPickups : MonoBehaviour
{
    public int selectedWeapon = 0;

    private void Update()
    {
        SelectedWeapon();
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
