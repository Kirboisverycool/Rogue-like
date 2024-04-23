using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashAmount = 20f;
    public float dashCooldown = 1f;

    public LayerMask dashLayerMask;
    public Rigidbody2D rb;
    public Camera cam;

    bool isDashing = false;
    bool canDash = true;

    float x;
    float y;

    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetButtonDown("Dash") && canDash == true)
        {
            StartCoroutine(InitiateDash());
        }
    }

    void FixedUpdate()
    {
        Walk();
        MoveToMouse();
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
        Vector3 dir = new Vector2(x, y).normalized;

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
        Vector2 moveDir = new Vector2(x, y).normalized;

        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }
}
