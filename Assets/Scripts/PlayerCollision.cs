using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Health hitpoints;

    public int healthBoostAmount = 1;
    public int healAmount = 1;
    public int dealDamage;

    [Header("IFrames")]
    public Color flashColour;
    public Color regularColour;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer mySprite;

    private void Start()
    {
        hitpoints = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "HealthBoost":
                StartHealthBoostSequence();
                break;
            case "Heal":
                StartHealSequence();
                break;
            case "Enemy":
                StartDamageSequence(dealDamage);
                break;
        }
    }

    private void StartHealSequence()
    {
        hitpoints.health += healAmount;
    }

    public void StartDamageSequence(int damage)
    {
        hitpoints.health -= damage;
    }

    private void StartHealthBoostSequence()
    {
        if(hitpoints.numOfHealth == 10)
        {
            return;
        }

        hitpoints.numOfHealth += healthBoostAmount;
        hitpoints.health = hitpoints.numOfHealth;
    }
}
