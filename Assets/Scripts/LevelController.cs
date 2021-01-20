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
    bool levelFailed = false;

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
        if(numberOfEnemies <= 0 && levelTimerFinished && !levelFailed)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    /// <summary>
    /// Handles winning the game. Plays a sound effect and shows win text before loading
    /// the next scene.
    /// </summary>
    /// <returns> Enumerated type yielded by the WaitForSeconds() method until the set time
    /// has passed.
    /// </returns>
    private IEnumerator HandleWinCondition()
    {
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) // Music player will not exist if game not started from start screen
        {
            musicPlayer.PauseMusic();
        }

        winOverlay.SetActive(true);
        AudioSource winAudio = winOverlay.GetComponent<AudioSource>();
        winAudio.volume = PlayerPrefsController.GetMasterVolume();
        winAudio.Play();

        yield return new WaitForSeconds(winWaitTime);

        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        if (levelLoader) //Prevent null reference exception
        {
            levelLoader.LoadNextScene();
        }
    }

    /// <summary>
    /// Handles when the player fails a level.
    /// </summary>
    public void HandleFailCondition()
    {
        levelFailed = true;
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) // Music player will not exist if game not started from start screen
        { 
            musicPlayer.PauseMusic(); 
        }

        loseOverlay.SetActive(true);
        Time.timeScale = 0f;

        AudioSource loseAudio = loseOverlay.GetComponent<AudioSource>();
        loseAudio.volume = PlayerPrefsController.GetMasterVolume();
        loseAudio.Play();
    }

    /// <summary>
    /// Notifies the controller that the level timer has expired, so the player will
    /// win the game if they kill all remaining enemies. Stops further enemy spawning.
    /// </summary>
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        // StopEnemySpawners();
    }
}
