using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    Renderer rend;
    Color c;

    private Health hitpoints;

    public float levelLoadWaitTime = 1f;
    public int healthBoostAmount = 1;
    public int healAmount = 1;
    public int dealDamage;
    public float invulnerabilityTime = 2f;

    public Rigidbody2D playerRb;

    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        hitpoints = GetComponent<Health>();
        playerRb = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        c = rend.material.color;
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
            case "Exit":
                StartNextSceneSequence();
                break;
        }
    }

    private void StartNextSceneSequence()
    {
        Invoke("LoadNextScene", levelLoadWaitTime);
    }

    private void LoadNextScene()
    {
        if (SceneManager.sceneCountInBuildSettings - 1 == currentSceneIndex)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
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
            StartCoroutine(GetInvulnerable());
        }
        else
        {
            hitpoints.health -= damage;
            StartCoroutine(GetInvulnerable());
        }
    }

    private IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Physics2D.IgnoreLayerCollision(6, 13, true);
        Physics2D.IgnoreLayerCollision(6, 15, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(invulnerabilityTime);
        Physics2D.IgnoreLayerCollision(6, 8, false);
        Physics2D.IgnoreLayerCollision(6, 13, false);
        Physics2D.IgnoreLayerCollision(6, 15, false);
        c.a = 1f;
        rend.material.color = c;
    }

    private void StartHealthBoostSequence()
    {
        if(hitpoints.maxHealth == 10)
        {
            return;
        }

        hitpoints.maxHealth += healthBoostAmount;
        hitpoints.health = hitpoints.maxHealth;
    }
}
