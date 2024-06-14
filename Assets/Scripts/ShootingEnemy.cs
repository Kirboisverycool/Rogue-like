using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShootingEnemy : MonoBehaviour
{
    public float health = 5f;
    public int enemyDamage = 1;
    public float speed;
    public float slowDownTime;
    public bool isSlowed;
    public float slowDownTimeSpeed;
    private float firstSpeed;
    public float shootingRange;
    public float inLineOfSight;
    public float fireRate = 1f;
    private float nextFireTime;
    public int hit = 0;

    public GameObject enemyBullet;
    public Transform firePos;
    private Transform player;
    private SpriteRenderer sp;
    private CinemachineImpulseSource impulseSource;

    [SerializeField] private ScreenShakeProfile profile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        impulseSource = GetComponent<CinemachineImpulseSource>();
        sp = GetComponent<SpriteRenderer>();

        firstSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();

        if (isSlowed == true)
        {
            slowDownTime += Time.deltaTime * slowDownTimeSpeed;
        }

        if (slowDownTime >= 3)
        {
            speed = firstSpeed;
            hit = 0;
            isSlowed = false;
        }
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

    public void TakeHit(float damage, float slowDown)
    {
        isSlowed = true;
        slowDownTime = 0;

        //if(ScreenShake.instance.canShake)
        //{
            ScreenShake.instance.ScreenShakeFromProfile(profile, impulseSource);
        //}

        health -= damage;

        hit++;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (hit <= 3)
        {
            speed /= slowDown;
        }
    }
}
