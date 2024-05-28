using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    public GameObject myPlayer;

    private void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        mousePos.Normalize();

        float rotationZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
}
