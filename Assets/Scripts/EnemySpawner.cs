using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public float spawnWait;
    public float startWait;
    int randEnemy;
    int randSpawnPoint;
    public bool stopSpawning = true;
    public float stopTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(startWait);

        stopSpawning = false;

        while(stopSpawning == false)
        {
            randEnemy = Random.Range(0, enemies.Length);
            randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemies[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.identity);

            yield return new WaitForSeconds(spawnWait);

            StartCoroutine(StopSpawningEnemies());
        }
    }

    private IEnumerator StopSpawningEnemies()
    {
        yield return new WaitForSeconds(stopTimer);

        stopSpawning = true;

        Destroy(gameObject);
    }
}
