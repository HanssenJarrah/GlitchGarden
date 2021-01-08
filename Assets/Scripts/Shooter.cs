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

    /// <summary>
    /// Fires the configured projectile from the location of the configured weapon.
    /// </summary>
    public void Fire()
    {
        Instantiate(projectile, weapon.transform.position, Quaternion.identity);
    }
}
