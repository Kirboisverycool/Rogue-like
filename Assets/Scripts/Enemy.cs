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
        Movement();
    }

    private void Movement()
    {
        float speed = Random.Range(1, 7);

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

    public void TakeHit(float damage)
    {
        //ScreenShake.instance.CameraShake(impulseSource);
        //if(ScreenShake.instance.canShake)
        //{
            ScreenShake.instance.ScreenShakeFromProfile(profile, impulseSource);
        //}

        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
