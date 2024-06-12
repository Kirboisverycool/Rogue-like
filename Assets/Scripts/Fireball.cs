using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [Header("Fireball")]
    public Transform fireballFirePoint;
    public GameObject fireballPrefab;
    public float fireballForce;
    public float fireballCooldownTime;
    private float nextFireballFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFireballFireTime)
        {
            if (Input.GetButtonDown("Ability"))
            {
                ShootFireball();
                nextFireballFireTime = Time.time + fireballCooldownTime;
            }
        }
    }

    private void ShootFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, fireballFirePoint.position, fireballFirePoint.rotation);
        Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();
        fireballRb.AddForce(fireballFirePoint.right * fireballForce, ForceMode2D.Impulse);
    }
}
