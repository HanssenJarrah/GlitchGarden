using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int projectileDamage = 1;
    [SerializeField][Range(0f, 10f)] float velocity = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }

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
