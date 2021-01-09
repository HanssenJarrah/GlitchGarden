using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the configuration of health 
/// </summary>
public class Health : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] int health = 2;
    [SerializeField] GameObject deathParticles;

    /// <summary>
    /// Reduces the health of this game object. If health goes below 0, the object is destroyed, and has death
    /// effects triggered.
    /// </summary>
    /// <param name="damage"> Amount of damage to be dealt. </param>
    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Returns the current health of the game object this script is attached to.
    /// </summary>
    /// <returns> The current health of this game object. </returns>
    public int GetHealth()
    {
        return health;
    }

    /// <summary>
    /// Instatiates a death particle effect at the position of this game object.
    /// </summary>
    private void TriggerDeathVFX()
    {
        if (!deathParticles) { return; }
        GameObject deathVFX = Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(deathVFX, 1f);
    }
}
