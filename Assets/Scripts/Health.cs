using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public int health;
    public int numOfHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Extra Health")]
    public int extraHealth;
    public int numOfExtraHealth;
    public Image[] extraHearts;
    public Sprite fullExtraHeart;

    // Update is called once per frame
    void Update()
    {
        Hitpoints();
        ExtraHitpoints();
    }

    private void ExtraHitpoints()
    {
        if (health > numOfHealth)
        {
            health = numOfHealth;
        }

        for (int i = 0; i < extraHearts.Length; i++)
        {
            if (i < extraHealth)
            {
                extraHearts[i].sprite = fullExtraHeart;
            }
            else
            {
                extraHearts[i].sprite = emptyHeart;
            }

            if (i < numOfExtraHealth)
            {
                extraHearts[i].enabled = true;
            }
            else
            {
                extraHearts[i].enabled = false;
            }
        }
    }

    void Hitpoints()
    {
        if (health > numOfHealth)
        {
            health = numOfHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
