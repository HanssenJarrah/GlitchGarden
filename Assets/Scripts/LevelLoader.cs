using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script that controls the loading of game scenes/levels.
/// </summary>
public class LevelLoader : MonoBehaviour
{
    // State variables
    int currentSceneIndex;

    // Constants
    int waitTime = 3;

    /// <summary>
    /// This method is called by Unity when the game object is fist instantiated.
    /// It controls the transition from the splash screen to the start screen.
    /// </summary>
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    /// <summary>
    /// Coroutine that shows the splash screen for 3 seconds before going to the start screen.
    /// </summary>
    /// <returns> Enumerated type yielded by the WaitForSeconds() method until the set time
    /// has passed.
    /// </returns>
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitTime);
        LoadNextScene();
    }

    /// <summary>
    /// Loads the next scene according to the build manager scene index.
    /// </summary>
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
