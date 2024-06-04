using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetection : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Collider2D currentSpawnableArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemySpawner.instance.SpawnEnemies(currentSpawnableArea, enemies);

        Destroy(gameObject);
    }
}
