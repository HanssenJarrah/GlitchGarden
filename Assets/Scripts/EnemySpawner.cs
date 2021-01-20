using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that allows configuration of parameters controlling spawning of new enemies.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// Struct used to store a single enemy spawn event and its delay to wait after the previous event.
    /// </summary>
    [Serializable]
    public struct SpawnEvent
    {
        [SerializeField] internal float delay;
        [SerializeField] internal Enemy enemy;
    }

    /// <summary>
    /// This array of spawn events defines the schedule on which enemies are to spawn. This includes the
    /// type of enemy as well as the delay between the previous and current event.
    /// </summary>
    [SerializeField] SpawnEvent[] spawnSchedule;

    /// <summary>
    /// Called by Unity as a co-routine when the game object this script is attached to is
    /// first instantiated. Starts the scheduled spawning of enemies.
    /// </summary>
    /// <returns> Enumerated type yielded by the WaitForSeconds() method until the set time
    /// has passed. </returns>
    IEnumerator Start()
    {
        foreach (SpawnEvent spawnEvent in spawnSchedule)
        {
            yield return new WaitForSeconds(spawnEvent.delay);
            SpawnEnemy(spawnEvent.enemy);
        }
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
