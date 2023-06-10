using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public LayerMask collisionLayerMask;

    private void Start()
    {
        // Call the DestroyBullet function after 3 seconds
        Invoke("DestroyBullet", 3f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (((1 << collision.gameObject.layer) & collisionLayerMask) != 0)
            {
                // Destroy the projectile on collision
                Destroy(gameObject);
            }
        }
    }

    private void DestroyBullet()
    {
        // Destroy the projectile after 3 seconds
        Destroy(gameObject);
    }
}