using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField] private LayerMask layersEnemyCannotSpawnOn;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SpawnEnemies(Collider2D spawnableAreaCollider, GameObject[] enemies)
    {
        foreach(GameObject enemy in enemies)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition(spawnableAreaCollider);
            GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetRandomSpawnPosition(Collider2D spawnableAreaCollider)
    {
        Vector2 spawnPosition = Vector2.zero;
        bool isSpawnPosValid = false;

        int attemptCount = 0;
        int maxAttemps = 200;

        while(!isSpawnPosValid && attemptCount < maxAttemps)
        {
            spawnPosition = GetRandomPointInCollider(spawnableAreaCollider);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 2f);

            bool isInvalidCollision = false;
            foreach(Collider2D collider in colliders)
            {
                if(((1 << collider.gameObject.layer) & layersEnemyCannotSpawnOn) != 0 ?)
                {

                }
            }

            if(!isInvalidCollision)
            {
                isSpawnPosValid = true;
            }

            attemptCount++;
        }

        if(!isSpawnPosValid)
        {
            Debug.LogWarning("No Good Spots :(");
        }

        return spawnPosition;
    }

    private Vector2 GetRandomPointInCollider(Collider2D collider, float offset = 1f)
    {
        Bounds collBounds = collider.bounds;

        Vector2 minBounds = new Vector2(collBounds.min.x + offset, collBounds.min.y + offset);
        Vector2 maxBounds = new Vector2(collBounds.max.x - offset, collBounds.max.y - offset);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);

        return new Vector2(randomX, randomY);
    }
}
