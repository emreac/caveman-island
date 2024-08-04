using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10; // Amount of damage the enemy deals
    public float attackRate = 1f; // Time between attacks in seconds
    private float nextAttackTime = 0f;
    private bool isAttacking = false;
    private bool isDead = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                if (!isAttacking)
                {
                    animator.SetBool("isAttacking", true);
                    isAttacking = true;
                }

                playerHealth.TakeDamage(damage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("Player"))
        {
            animator.SetBool("isAttacking", false);
            isAttacking = false;
        }
    }

    public void OnDeath()
    {
        isDead = true;
        animator.SetBool("isAttacking", false);
        animator.SetTrigger("Die");
        isAttacking = false;
        NotifyPlayerOfDeath();
        StopAllCoroutines(); // Stop any ongoing coroutines
        StartCoroutine(DieAfterAnimation());
    }

    
    private IEnumerator DieAfterAnimation()
    {
        // Wait for the length of the death animation before destroying the game object
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }

    private void NotifyPlayerOfDeath()
    {
        // Notify the player to stop attacking
        PlayerAttack playerAttack = FindObjectOfType<PlayerAttack>();
        if (playerAttack != null)
        {
            playerAttack.OnEnemyKilled();
        }
    }
}
