using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that allows game objects with this component to shoot projectiles.
/// </summary>
public class Shooter : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject weapon;

    // State variables
    EnemySpawner laneSpawner;
    Animator animator;

    /// <summary>
    /// Called by Unity when the game object is first instantiated.
    /// Sets the enemy spawner corresponding to this shooters lane.
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    /// <summary>
    /// Called once per frame by Unity. This controls the behaviour of shooters, where
    /// they will only shoot if there is an enemy in their lane.
    /// </summary>
    private void Update()
    {
        if (AttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    /// <summary>
    /// Finds the enemy spawner corresponding to the lane this shooter is on.
    /// </summary>
    private void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in spawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                laneSpawner = spawner;
                return;
            }
        }
        Debug.LogError("Shooter was unable to find spawner corresponding to its lane.");
    }

    /// <summary>
    /// Detects if there is an enemy in this shooters lane.
    /// </summary>
    /// <returns> True if there is an enemy in this shooters lane. False otherwise. </returns>
    private bool AttackerInLane()
    {
        // Each attacker is instatiated as a child of the spawner, so we check the number of
        // children to find the number of enemies in the lane.
        int enemiesInLane = laneSpawner.transform.childCount;
        return enemiesInLane > 0;
    }

    /// <summary>
    /// Fires the configured projectile from the location of the configured weapon.
    /// </summary>
    public void Fire()
    {
        Instantiate(projectile, weapon.transform.position, Quaternion.identity);
    }
}
