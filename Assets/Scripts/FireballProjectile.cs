using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage = 5f;
    public float fireballTime = 2f;
    public float effectTime;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, fireballTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        var shootingEnemy = collision.GetComponent<ShootingEnemy>();
        if (enemy)
        {
            enemy.TakeHit(damage, 1);
        }
        if(shootingEnemy)
        {
            shootingEnemy.TakeHit(damage, 1);
        }

        if (collision.CompareTag("Wall") == true)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, effectTime);
            Destroy(gameObject);
        }
    }
}
