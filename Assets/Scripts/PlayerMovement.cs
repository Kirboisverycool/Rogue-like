using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sp;

    public float moveSpeed = 5f;
    public float dashAmount = 20f;
    public float dashCooldown = 1f;

    public LayerMask dashLayerMask;
    public Rigidbody2D rb;
    public Camera cam;

    bool isDashing = false;
    bool canDash = true;
    bool facingRight = true;

    float horizontal;
    float vertical;

    Vector2 mousePos;
    Vector2 moveDir;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Dash") && canDash == true)
        {
            StartCoroutine(InitiateDash());
        }
    }

    void FixedUpdate()
    {
        Walk();
        //MoveToMouse();
        Dash();
    }

    private IEnumerator InitiateDash()
    {
        isDashing = true;
        canDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void Dash()
    {
        Vector3 dir = new Vector2(horizontal, vertical).normalized;

        if (isDashing == true)
        {
            Vector3 dashPosition = transform.position + dir * dashAmount;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, dir, dashAmount, dashLayerMask);
            if(raycastHit2d.collider != null)
            {
                dashPosition = raycastHit2d.point;
            }

            rb.MovePosition(dashPosition);
            isDashing = false;
        }
    }

    private void MoveToMouse()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void Walk()
    {
        moveDir = new Vector2(horizontal, vertical).normalized;

        animator.SetFloat("speed", Mathf.Abs(horizontal));

        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);

        if(horizontal > 0)
        {
            sp.flipX = false;;
        }
        if(horizontal < 0)
        {
            sp.flipX = true;
        }
    }
}
