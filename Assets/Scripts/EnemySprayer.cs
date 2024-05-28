using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprayer : MonoBehaviour
{
    public float health = 5f;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public bool firstShot = true;

    public GameObject enemyBullets;
    public GameObject nextEnemyBullets;
    public Transform firePos;
    public Transform firePos1;
    public Transform firePos2;
    public Transform firePos3;
    public Transform firePos4;
    private Transform player;
    public Transform nextFirePos;
    public Transform nextFirePos1;
    public Transform nextFirePos2;
    public Transform nextFirePos3;
    public Transform nextFirePos4;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer <= shootingRange && firstShot == true && nextFireTime < Time.time)
        {
            Instantiate(enemyBullets, firePos.position, firePos.rotation);
            Instantiate(enemyBullets, firePos1.position, firePos1.rotation);
            Instantiate(enemyBullets, firePos2.position, firePos2.rotation);
            Instantiate(enemyBullets, firePos3.position, firePos3.rotation);
            Instantiate(enemyBullets, firePos4.position, firePos4.rotation);
            nextFireTime = Time.time + fireRate;
            firstShot = false;
        }
        else if(distanceFromPlayer <= shootingRange && firstShot == false && nextFireTime < Time.time)
        {
            Instantiate(nextEnemyBullets, nextFirePos.position, nextFirePos.rotation);
            Instantiate(nextEnemyBullets, nextFirePos1.position, nextFirePos1.rotation);
            Instantiate(nextEnemyBullets, nextFirePos2.position, nextFirePos2.rotation);
            Instantiate(nextEnemyBullets, nextFirePos3.position, nextFirePos3.rotation);
            Instantiate(nextEnemyBullets, nextFirePos4.position, nextFirePos4.rotation);
            nextFireTime = Time.time + fireRate;
            firstShot = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    public void TakeHit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
