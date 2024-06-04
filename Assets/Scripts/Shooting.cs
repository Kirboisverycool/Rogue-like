using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    private GunPickups gunPickups;

    public float bulletForce = 20f;
    public float fireRate;

    float time;

    private void Start()
    {
        gunPickups = GetComponent<GunPickups>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        float nextFireTime = 1 / fireRate;

        if (Input.GetButton("Shoot") && time >= nextFireTime)
        {
            if(gunPickups.selectedWeapon == 3)
            {
                Shotgun();
            }
            Shoot();
            time = 0;
        }
    }

    private void Shotgun()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        rb1.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
