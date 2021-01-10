using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides functionality to control the level including detecting when the player has
/// won the game.
/// </summary>
public class LevelController : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] GameObject winOverlay;
    [SerializeField] GameObject loseOverlay;
    [SerializeField] float winWaitTime = 4f;

    // State variables
    int numberOfEnemies = 0;
    bool levelTimerFinished = false;

    /// <summary>
    /// Called by unity when the game object this script is attached to is first instantiated.
    /// Disables the win screen overlay.
    /// </summary>
    private void Start()
    {
        if (winOverlay == null || loseOverlay == null)  // Skip if winOverlay and loseOverlay are not defined.
        {
            loseOverlay.SetActive(false);
            winOverlay.SetActive(false);
        }
    }

    /// <summary>
    /// Increments the counter keeping track of currently living enemies.
    /// </summary>
    public void EnemySpawned()
    {
        numberOfEnemies++;
    }

    /// <summary>
    /// Decrements the counter keeping track of currently living enemies.
    /// </summary>
    public void EnemyKilled()
    {
        numberOfEnemies--;
        if(numberOfEnemies <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    /// <summary>
    /// Handles winning the game. Plays a sound effect and shows win text before
    /// loading the next scene.
    /// </summary>
    /// <returns></returns>
    private IEnumerator HandleWinCondition()
    {
        winOverlay.SetActive(true);
        winOverlay.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winWaitTime);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    /// <summary>
    /// Handles when the player fails a level.
    /// </summary>
    public void HandleLevelFail()
    {
        loseOverlay.SetActive(true);
        loseOverlay.GetComponent<AudioSource>().Play();
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Notifies the controller that the level timer has expired, so the player will
    /// win the game if they kill all remaining enemies. Stops further enemy spawning.
    /// </summary>
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopEnemySpawners();
    }

    /// <summary>
    /// Stops all spawners in the level from spawning.
    /// </summary>
    private void StopEnemySpawners()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach(EnemySpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
