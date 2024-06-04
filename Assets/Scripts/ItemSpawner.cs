using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("RandomDrop")]
    public GameObject[] items;
    int randObject;
    public Transform dropPoint;
    private Gate gate;
    public BoxCollider2D col;

    private void Start()
    {
        gate = GetComponent<Gate>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnItem();
        gameObject.SetActive(false);
    }

    private void SpawnItem()
    {
        // Spawn Random Weapon Or Item
        randObject = Random.Range(0, items.Length);

        Instantiate(items[randObject], dropPoint.position, Quaternion.identity);
    }
}