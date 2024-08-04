using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 30; // Amount of damage the player deals
    public float attackRate = 1f; // Time between attacks in seconds
    private float nextAttackTime = 0f;
    private Collider enemyInRange;
    public Animator playerAnimator;

    void Update()
    {
        if (enemyInRange != null && Time.time >= nextAttackTime)
        {
            Attack(enemyInRange);
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange = other;
            playerAnimator.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange = null;
            playerAnimator.SetBool("isAttacking", false);
        }
    }

    void Attack(Collider enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Debug.Log("Attacked enemy, dealing " + damage + " damage.");
        }
    }

    public void OnEnemyKilled()
    {
        if (enemyInRange != null)
        {
            enemyInRange = null;
            playerAnimator.SetBool("isAttacking", false);
        }
    }
}
