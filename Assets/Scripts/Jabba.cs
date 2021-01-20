using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls behaviour specific to the Jabba boss enemy.
/// </summary>
public class Jabba : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] GameObject attackPoint;
    [SerializeField] LineRenderer attackRay;
    [SerializeField] GameObject laserParticles;

    // State variables
    GameObject targetedDefender;

    /// <summary>
    /// Called by Unity when the trigger collider of this Jabba comes into contact with another collider.
    /// If the game object with the other collider is a defender, the Jabba will perform its special attack.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            targetedDefender = otherObject;
            GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    /// <summary>
    /// Enables the Jabba attack ray to be shown and sets its start and end position. The targeted object
    /// is destroyed.
    /// </summary>
    public void StartAttacking()
    {
        Vector2 attackRayStartPos = attackPoint.transform.position;
        Vector2 attackRayEndPos = targetedDefender.transform.position;

        attackRay.SetPosition(0, attackRayStartPos);
        attackRay.SetPosition(1, attackRayEndPos);
        attackRay.enabled = true;

        GameObject laserVFX = Instantiate(laserParticles, attackRayEndPos, Quaternion.identity);
        Destroy(laserVFX, 1f);
    }

    /// <summary>
    /// Disables the Jabba attack ray from being shown.
    /// </summary>
    public void StopAttacking()
    {
        attackRay.enabled = false;
        Destroy(targetedDefender);
    }
}
