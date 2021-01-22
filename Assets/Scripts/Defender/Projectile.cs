using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class defining projectiles able to be fired by shooters.
/// </summary>
public class Projectile : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] int projectileDamage = 1;
    [SerializeField][Range(0f, 10f)] float velocity = 1f;

    /// <summary>
    /// Called by Unity once per frame.
    /// Moves the projectile accross the screen (frame independant).
    /// </summary>
    void Update()
    {
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }

    /// <summary>
    /// Called by Unity when the collider attached to the game object is triggered by collision
    /// with an enemy. Causes the projectile to deal damage and then be destroyed.
    /// </summary>
    /// <param name="otherCollider"> Collider of the game object the projectile collided with. </param>
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var enemy = otherCollider.GetComponent<Enemy>();

        if (enemy && health)
        {
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
