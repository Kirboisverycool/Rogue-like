using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Fireball")]
    public Transform fireballFirePoint;
    public GameObject fireballPrefab;
    public float fireballForce;
    public float fireballFireRate;
    float fireballTime;

    // Update is called once per frame
    void Update()
    {
        fireballTime += Time.deltaTime;
        float nextFireballFireTime = 1 / fireballFireRate;

        if(Input.GetButtonDown("Fireball") && fireballTime >= nextFireballFireTime)
        {
            Fireball();
            fireballTime = 0;
        }
    }

    private void Fireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, fireballFirePoint.position, fireballFirePoint.rotation);
        Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();
        fireballRb.AddForce(fireballFirePoint.up * fireballForce, ForceMode2D.Impulse);
    }
}
