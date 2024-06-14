using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float effectTime = 0.5f;
    public float bulletDamage = 1f;
    public float slowDownEnemySpeed;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        var shootingEnemy = collision.GetComponent<ShootingEnemy>();
        if(enemy)
        {
            enemy.TakeHit(bulletDamage, slowDownEnemySpeed);
        }
        if(shootingEnemy)
        {
            shootingEnemy.TakeHit(bulletDamage, slowDownEnemySpeed);
        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, effectTime);
        Destroy(gameObject);
    }
}
