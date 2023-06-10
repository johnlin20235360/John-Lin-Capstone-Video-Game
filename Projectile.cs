using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;             
    public LayerMask collisionLayerMask;
    private HealthScript hs;

    private void Start()
    {
        // Call the DestroyBullet function after 3 seconds
        Invoke("DestroyProjectile", 3f);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(damage);
            }


            if (((1 << collision.gameObject.layer) & collisionLayerMask) != 0)
            {
                // Destroy the projectile on collision
                Destroy(gameObject);
            }
        }
    }
    private void DestroyProjectile()
    {
        // Destroy the projectile after 3 seconds
        Destroy(gameObject);
    }

}
