using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    int minSpawnDelay;
    int maxSpawnDelay;
    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            int spawnWaitTime = UnityEngine.Random.Range(1, 5);
            yield return new WaitForSeconds(spawnWaitTime);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
