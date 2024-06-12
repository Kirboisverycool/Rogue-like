using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Renderer rend;
    Color c;

    public float invulnerabilityTime = 5f;
    public float cooldownTime;
    private float nextCooldownTime = 0f;
    public bool isInvulnerable;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInParent<Renderer>();
        c = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCooldownTime)
        {
            if (Input.GetButtonDown("Ability"))
            {
                StartCoroutine(Invulnerable());
            }
        }
    }

    private IEnumerator Invulnerable()
    {
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Physics2D.IgnoreLayerCollision(6, 13, true);
        Physics2D.IgnoreLayerCollision(6, 15, true);
        c.a = 0.5f;
        rend.material.color = c;
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        nextCooldownTime = Time.time + cooldownTime;
        Physics2D.IgnoreLayerCollision(6, 8, false);
        Physics2D.IgnoreLayerCollision(6, 13, false);
        Physics2D.IgnoreLayerCollision(6, 15, false);
        c.a = 1f;
        rend.material.color = c;
        isInvulnerable = false;
    }
}
