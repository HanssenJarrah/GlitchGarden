using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls functionality specific to the Rube enemy.
/// </summary>
public class Rube : MonoBehaviour
{
    /// <summary>
    /// Called by Unity when the trigger collider of this Rube comes into contact with another collider.
    /// If the game object with the other collider is a defender, the Rube will attack.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Enemy>().Attack(otherObject);
        }
    }
}
