using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    [Header("Attacking")]
    public float attackDistance = 3f;
    public float attackDelay = 0.4f;
    public float attackSpeed = 1f;
    public int damage = 10;
    public LayerMask whatIsEnemy;
    public Transform cam;

    bool attacking = false;
    bool readyToAttack = true;
    


    public void Attack()
    {
        if (!readyToAttack || attacking) return;

        readyToAttack = false;
        attacking = true;

        Invoke(nameof(ResetAttack), attackSpeed);
        Invoke(nameof(AttackRaycast), attackDelay);

       // audioSource.pitch = Random.Range(0.9f, 1.1f);
       // audioSource.PlayOneShot(swordSwing);
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void AttackRaycast()
    {
        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, attackDistance, whatIsEnemy))
        {

            if (hit.collider.CompareTag("whatIsEnemy"))
                hit.collider.GetComponent<Enemy>().TakeDamage(damage);
            //if (hit.transform.TryGetComponent<Enemy>(out Enemy T))
            //{ T.TakeDamage(attackDamage); }
            //Enemy enemy = hit.collider.GetComponent<Enemy>();
            //if (enemy != null)
            //{
            // Invoke the TakeDamage function on the enemy, passing in the sword's damage value
            //enemy.TakeDamage(damage);
            //}
        }
    }

   
}

