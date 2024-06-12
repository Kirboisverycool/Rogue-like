using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public int selectedAbility;
    public int currentAbility;

    public Transform dropPoint;
    public GameObject fireballPrefab;
    public GameObject shieldPrefab;

    public bool isTouchingFireballPickup = false;
    public bool isTouchingShieldPickup = false;

    private Dialogue dialogue;

    private void Start()
    {
        currentAbility = selectedAbility;
    }

    private void Update()
    {
        SelectedAbility();

        if (isTouchingFireballPickup == true && Input.GetKeyDown(KeyCode.G))
        {
            PickupFireball();
        }
        if (isTouchingShieldPickup == true && Input.GetKeyDown(KeyCode.G))
        {
            PickupShield();
        }
    }

    private void PickupShield()
    {
        if (selectedAbility == 0)
        {
            Instantiate(fireballPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedAbility == 1)
        {
            Instantiate(shieldPrefab, dropPoint.position, dropPoint.rotation);
        }

        selectedAbility = 1;
        currentAbility = 1;


        Destroy(GameObject.FindWithTag("Shield"));
    }

    private void PickupFireball()
    {
        if (selectedAbility == 1)
        {
            Instantiate(shieldPrefab, dropPoint.position, dropPoint.rotation);
        }
        if (selectedAbility == 0)
        {
            Instantiate(fireballPrefab, dropPoint.position, dropPoint.rotation);
        }

        selectedAbility = 0;
        currentAbility = 0;


        Destroy(GameObject.FindWithTag("Fireball"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            isTouchingFireballPickup = true;
        }

        if (collision.gameObject.tag == "Shield")
        {
            isTouchingShieldPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            isTouchingFireballPickup = false;
        }

        if (collision.gameObject.tag == "Shield")
        {
            isTouchingShieldPickup = false;
        }
    }

    private void SelectedAbility()
    {
        int i = 0;
        foreach (Transform ability in transform)
        {
            if (i == selectedAbility)
            {
                ability.gameObject.SetActive(true);
            }
            else
            {
                ability.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
