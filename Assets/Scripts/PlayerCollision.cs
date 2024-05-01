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
            case "ExtraHealth":
                StartExtraHealthSequence();
                break;
            case "Enemy":
                StartDamageSequence(dealDamage);
                break;
        }
    }

    private void StartExtraHealthSequence()
    {
        hitpoints.numOfExtraHealth += healAmount;
        hitpoints.extraHealth = hitpoints.numOfExtraHealth;
    }

    private void StartHealSequence()
    {
        if (hitpoints.numOfExtraHealth == 10)
        {
            return;
        }

        hitpoints.health += healAmount;
    }

    public void StartDamageSequence(int damage)
    {
        if (hitpoints.numOfExtraHealth >= 1)
        {
            hitpoints.numOfExtraHealth -= damage;
        }
        else
        {
            hitpoints.health -= damage;
        }
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
