using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script controlling how long each level lasts, and the slider to display that
/// information to the player.
/// </summary>
public class GameTimer : MonoBehaviour
{
    // Configuration parameters
    [Tooltip("Level time in seconds")]
    [SerializeField] float gameTime = 10f;

    // State variables
    bool timeFinished = false;

    /// <summary>
    /// Called by Unity once each frame. Sets the slider to the appropriate position
    /// and detects if the level timer has expired. When the timer has expired, this
    /// information is shared with the LevelController.
    /// </summary>
    private void Update()
    {
        if (!timeFinished)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / gameTime;

            timeFinished = Time.timeSinceLevelLoad >= gameTime;
            if (timeFinished)
            {
                FindObjectOfType<LevelController>().LevelTimerFinished();
            }
        }
    }
}
