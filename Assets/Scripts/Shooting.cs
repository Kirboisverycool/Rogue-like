using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private GunPickups gunPickups;
    private CinemachineImpulseSource impulseSource;

    [SerializeField] private ScreenShakeProfile profile;

    public float bulletForce = 20f;
    public float fireRate;

    float time;

    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();

        gunPickups = GetComponent<GunPickups>();
    }

    // Update is called once per frame
    public void Update()
    {
        time += Time.deltaTime;

        float nextFireTime = 1 / fireRate;

        if (Input.GetButton("Shoot") && time >= nextFireTime)
        {
            Shoot();
            time = 0;
            ScreenShake.instance.ScreenShakeFromProfile(profile, impulseSource);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
