using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that allows configuration of parameters controlling spawning of new enemies.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    // Constants
    [SerializeField] int minSpawnDelay = 5;
    [SerializeField] int maxSpawnDelay = 10;

    // Configuration parameters
    [SerializeField] Enemy enemy;

    // State variables
    bool spawn = true;

    /// <summary>
    /// Called by Unity when the game object is first instantiated as a co-routine.
    /// Controls the timing of enemy spawning.
    /// </summary>
    /// <returns> Enumerated type yielded by the WaitForSeconds() method until the set time
    /// has passed.
    /// </returns>
    IEnumerator Start()
    {
        while (spawn)
        {
            int spawnWaitTime = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnWaitTime);
            SpawnEnemy();
        }
    }

    /// <summary>
    /// Spawns a new enemy at the location of the spawner.
    /// </summary>
    private void SpawnEnemy()
    {
        Enemy newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        newEnemy.transform.parent = transform;
    }
}
