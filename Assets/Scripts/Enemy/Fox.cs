using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls functionality specific to the Fox enemy.
/// </summary>
public class Fox : MonoBehaviour
{
    /// <summary>
    /// Called by Unity when the trigger collider of this Fox comes into contact with another collider.
    /// If the game object with the other collider is a GraveStone defender, the fox will jump over it.
    /// If the game object is any other type of defender, the Fox will attack.
    /// </summary>
    /// <param name="collision"> Collider of the other game object collided with. </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        // Jump over gravestones
        if (otherObject.GetComponent<GraveStone>())
        {
            GetComponent<Animator>().SetTrigger("Jump");
        }
        // Attack all other defenders
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Enemy>().Attack(otherObject);
        }
    }
}
