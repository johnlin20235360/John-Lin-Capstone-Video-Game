using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj : MonoBehaviour
{
    public int damageAmount = 5;
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is an enemy
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Damage the enemy
            enemy.TakeDamage(damageAmount);
        }

        // Destroy the projectile
        Destroy(gameObject);
    }
}
