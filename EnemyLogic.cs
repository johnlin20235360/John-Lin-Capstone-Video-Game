using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    
    public int maxHealth;
    public int currentHealth;
    public int attackDamage;
    public float detectionRadius;
    public float chaseSpeed;
    public LayerMask whatIsPlayer;

    private Transform player;
    private bool isPlayerDetected;
    private bool isAttacking;
    private Quaternion initialRotation;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialRotation = transform.rotation;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
        // Additional code for death animation or enemy removal can be added here
        Destroy(gameObject);
    }

    private void Update()
    {
        CheckPlayerDetection();

        if (isPlayerDetected)
        {
            LookAtPlayer();
            if (!isAttacking)
            {
                ChasePlayer();
            }
        }
        else
        {
            transform.rotation = initialRotation;
        }
    }

    private void CheckPlayerDetection()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, whatIsPlayer);
        if (hits.Length > 0)
        {
            isPlayerDetected = true;
        }
        else
        {
            isPlayerDetected = false;
        }
    }

    private void LookAtPlayer()
    {
        Vector3 playerDirection = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        // Melee Attack
        if (Vector3.Distance(transform.position, player.position) <= 1.5f && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(MeleeAttack());
        }
    }

    private System.Collections.IEnumerator MeleeAttack()
    {
        // Play attack animation or perform other attack-related actions here

        yield return new WaitForSeconds(1f); // Adjust the delay for your attack animation or attack cooldown

        // Apply attack damage or other attack-related actions here

        isAttacking = false;
    }
}