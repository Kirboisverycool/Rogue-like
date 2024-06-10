using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShootingEnemy : MonoBehaviour
{
    public float health = 5f;
    public int enemyDamage = 1;
    public float speed;
    public float shootingRange;
    public float inLineOfSight;
    public float fireRate = 1f;
    private float nextFireTime;

    public GameObject enemyBullet;
    public Transform firePos;
    private Transform player;
    private CinemachineImpulseSource impulseSource;

    [SerializeField] private ScreenShakeProfile profile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    private void Mouvement()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < inLineOfSight && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(enemyBullet, firePos.position, firePos.rotation);
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.DrawWireSphere(transform.position, inLineOfSight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerCollision>();
        if (player)
        {
            player.StartDamageSequence(enemyDamage);
        }
    }

    public void TakeHit(float damage)
    {
        //if(ScreenShake.instance.canShake)
        //{
            ScreenShake.instance.ScreenShakeFromProfile(profile, impulseSource);
        //}

        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
