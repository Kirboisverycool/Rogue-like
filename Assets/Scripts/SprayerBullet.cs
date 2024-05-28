using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayerBullet : MonoBehaviour
{
    public Transform firePoint;
    public float bulletForce;
    public GameObject hitEffect;
    public float effectTime = 0.5f;
    public int enemyBulletDamage = 1;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}