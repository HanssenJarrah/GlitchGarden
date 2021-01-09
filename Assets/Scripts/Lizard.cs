using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls functionality specific to the Lizard enemy.
/// </summary>
public class Lizard : MonoBehaviour
{
    /// <summary>
    /// Called by Unity when the trigger collider of this Lizard comes into contact with another collider.
    /// If the game object with the other collider is a defender, the Lizard will attack.
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
