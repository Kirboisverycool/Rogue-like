using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemy : MonoBehaviour
{
    public float health = 5f;
    public int enemyDamage = 1;
    public float currentSpeed;
    public float inLineOfSight;
    public float speed;
    public float slowDownTime;
    public bool isSlowed;
    public float slowDownTimeSpeed;
    private float firstSpeed;
    private int hit = 0;

    private Transform player;
    private Bullet bullet;
    private CinemachineImpulseSource impulseSource;

    [SerializeField] private ScreenShakeProfile profile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        impulseSource = GetComponent<CinemachineImpulseSource>();

        firstSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

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

    private void Movement()
    {
        speed = Random.Range(1, 7);

        currentSpeed = speed;

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < inLineOfSight)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, inLineOfSight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerCollision>();
        if(player)
        {
            player.StartDamageSequence(enemyDamage);
        }
    }

    public void TakeHit(float damage, float slowDown)
    {
        isSlowed = true;
        slowDownTime = 0;

        //ScreenShake.instance.CameraShake(impulseSource);
        //if(ScreenShake.instance.canShake)
        //{
        ScreenShake.instance.ScreenShakeFromProfile(profile, impulseSource);
        //}

        health -= damage;

        hit++;

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if (hit <= 3)
        {
            speed /= slowDown;
        }
    }
}
