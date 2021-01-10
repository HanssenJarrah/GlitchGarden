using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script attached to the lose collider for when an enemy makes it all to the end.
/// </summary>
public class LoseGame : MonoBehaviour
{
    /// <summary>
    /// Loads the lose scene when a player lets an enemy through. This method is
    /// called by Unity when the engine detects a collision trigger event with the
    /// collider attached to the same game object as this script.
    /// </summary>
    /// <param name="collision"> Object that the collider collided with. </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        // Checks that the collision was with an enemy.
        if (otherObject.GetComponent<Enemy>())
        {
            FindObjectOfType<LevelController>().HandleLevelFail();
        }
    }
}
