using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class controlling characteristics of enemies that will attack the player.
/// </summary>
public class Enemy : MonoBehaviour
{
    // State variables
    float movementSpeed = 0f;

    /// <summary>
    /// This method is called by Unity when the game object is fist instantiated.
    /// Sets collision to false to temporarily prevent the enemy from being hit by projectiles.
    /// </summary>
    private void Start()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    /// <summary>
    /// This method is called by Unity once per frame.
    /// Controls the movement of the enemy accross the play space (frame independant).
    /// </summary>
    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Causes the enemy to begin walking, and allow collistion to take damage from projectiles.
    /// This method is called by an animation event to approriately time the start of walking.
    /// </summary>
    /// <param name="newSpeed"> The new speed for the enemy to walk at. </param>
    public void StartWalking(float newSpeed)
    {
        movementSpeed = newSpeed;
        GetComponent<Collider2D>().enabled = true;
    }
}
