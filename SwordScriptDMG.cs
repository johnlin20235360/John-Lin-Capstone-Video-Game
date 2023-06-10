using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScriptDMG : MonoBehaviour
{
    public float attackRange = 2f;
    public int damage = 10;
    public LayerMask enemyLayer;
    public Transform cam;
    public float attackCooldown = 1f;
    private float lastAttackTime = -Mathf.Infinity;
    public Animator swordAnimator;
    public string swordDrawnStateName = "SwordDrawn";

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time - lastAttackTime > attackCooldown && IsSwordDrawn())
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, attackRange, enemyLayer))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            lastAttackTime = Time.time;
        }
    }
    private bool IsSwordDrawn()
    {
        if (swordAnimator == null)
        {
            Debug.LogWarning("Sword animator reference not set!");
            return false;
        }

        // Check if the sword animation controller is in the "SwordDrawn" state
        return swordAnimator.GetCurrentAnimatorStateInfo(0).IsName(swordDrawnStateName);
    }
}






