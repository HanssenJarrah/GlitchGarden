using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that allows configuration of parameters controlling spawning of new enemies.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] int minSpawnDelay = 5;
    [SerializeField] int maxSpawnDelay = 10;
    [SerializeField] Enemy[] enemies;

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
            SpawnEnemy(ChooseEnemy());
        }
    }

    /// <summary>
    /// Stops this spawner from spawning any more enemies.
    /// </summary>
    public void StopSpawning()
    {
        spawn = false;
    }

    /// <summary>
    /// Chooses a random enemy to spawn from the array of enemies.
    /// </summary>
    /// <returns> Enemy to spawn. </returns>
    private Enemy ChooseEnemy()
    {
        int enemyId = UnityEngine.Random.Range(0, enemies.Length);
        return enemies[enemyId];
    }

    /// <summary>
    /// Spawns a new enemy at the location of the spawner.
    /// </summary>
    private void SpawnEnemy(Enemy enemyToSpawn)
    {
        Enemy newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        newEnemy.transform.parent = transform;
    }
}
