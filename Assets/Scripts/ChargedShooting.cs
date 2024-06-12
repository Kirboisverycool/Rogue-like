using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class ChargedShooting : MonoBehaviour
{
    [Header("Shoot")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    private GunPickups gunPickups;
    private CinemachineImpulseSource impulseSource;
    [SerializeField] private ScreenShakeProfile profile;
    public float bulletForce = 20f;
    public float fireRate;
    float time;

    [Header("Charge")]
    public GameObject chargedBulletPrefab;
    public float chargeTime;
    public float chargeSpeed;
    private bool isCharging;

    // Start is called before the first frame update
    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();

        gunPickups = GetComponent<GunPickups>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        float nextFireTime = 1 / fireRate;

        if (Input.GetButtonDown("Shoot") && time >= nextFireTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
            time = 0;
            chargeTime = 0;
        }
        if (Input.GetButton("Shoot") && chargeTime < 2)
        {
            isCharging = true;
            if(isCharging == true)
            {
                chargeTime += Time.deltaTime * chargeSpeed; 
            }
        }
        else if(Input.GetButtonUp("Shoot") && chargeTime >= 2)
        {
            ReleaseChargeShot();
            ScreenShake.instance.ScreenShakeFromProfile(profile, impulseSource);
        }
    }

    private void ReleaseChargeShot()
    {
        GameObject bullet = Instantiate(chargedBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        isCharging = false;
        chargeTime = 0;
    }
}
