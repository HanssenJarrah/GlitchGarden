using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 2;
    [SerializeField] ParticleSystem deathParticles;

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        ParticleSystem deathVFX = Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(deathVFX, 1f);
    }
}
