using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float fireRate;

    float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        float nextFireTime = 1 / fireRate;

        if (Input.GetButton("Shoot") && time >= nextFireTime)
        {
            Shoot();
            time = 0;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}