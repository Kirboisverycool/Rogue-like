using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    GameObject target;
    public int enemyBulletDamage = 1;
    public float bulletSpeed;
    Rigidbody2D rb;
    private PlayerCollision playerCollision;
    Vector3 lastPos;
    public bool isPlayerMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        playerCollision = GetComponent<PlayerCollision>();
    }

    private void Update()
    {
        if (target.transform.position != lastPos)
        {
            isPlayerMoving = true;
        }
        else
        {
            isPlayerMoving = false;
        }

        lastPos = target.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerCollision>();
        if (target.transform.position != lastPos)
        {
            player.StartDamageSequence(enemyBulletDamage);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
