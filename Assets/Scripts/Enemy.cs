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
    GameObject currentTarget;

    /// <summary>
    /// This method is called by Unity once per frame.
    /// Controls the movement of the enemy accross the play space (frame independant).
    /// </summary>
    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Sets the enemy's movement speed accross the playspace. This method is called by 
    /// animation events to approriately time the start/stop of walking.
    /// </summary>
    /// <param name="newSpeed"> The new speed for the enemy to walk at. </param>
    public void SetMovementSpeed(float newSpeed)
    {
        movementSpeed = newSpeed;
    }

    /// <summary>
    /// Sets this enemy into the attacking state.
    /// </summary>
    /// <param name="target"> Defender target that the enemy's collider collided with. </param>
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    /// <summary>
    /// Causes this enemy to attack once, dealing damage to the current target. This also controls the
    /// animation state of the enemy and defender being attacked.
    /// </summary>
    /// <param name="damage"> Amount of damage to deal. </param>
    public void StrikeCurrentTarget(int damage)
    {
        // If another enemy killed the target
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
            currentTarget.GetComponent<Animator>().SetTrigger("TookDamage");

            // Check if the defender is now dead
            if(health.GetHealth() <= 0)
            {
                GetComponent<Animator>().SetBool("IsAttacking", false);
            }
        }
    }
}
