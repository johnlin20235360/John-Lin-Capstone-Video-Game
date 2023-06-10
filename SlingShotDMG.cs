using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotDMG : MonoBehaviour
{
    public Transform cam;
    public float attackCooldown = 1f;
    private float lastAttackTime = -Mathf.Infinity;
    public Animator slingAnimator;
    public string slingDrawnStateName = "SlingPull";
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletForce = 1000f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time - lastAttackTime > attackCooldown && IsSlingDrawn())
        {
            Vector3 spawnPosition = bulletSpawn.position;
            Quaternion spawnRotation = bulletSpawn.rotation;

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, spawnRotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                // Calculate the forward direction based on the bulletSpawn rotation
                Vector3 forwardDirection = bulletSpawn.forward;

                // Apply force to the bullet in the forward direction with the specified bulletForce
                bulletRigidbody.AddForce(forwardDirection * bulletForce);
            }

            lastAttackTime = Time.time;
        }
    }

    private bool IsSlingDrawn()
    {
        if (slingAnimator == null)
        {
            Debug.LogWarning("Sling animator reference not set!");
            return false;
        }

        // Check if the sling animation controller is in the "slingDrawnStateName" state
        return slingAnimator.GetCurrentAnimatorStateInfo(0).IsName(slingDrawnStateName);
    }
}






