using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public EnemyHealthBar healthBar;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Enemy died!");

        // Notify the enemy script to stop attacking
        Enemy enemyScript = GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.OnDeath();
        }

        // Implement death behavior (e.g., play death animation, etc.)
        Destroy(gameObject, 2f); // Delay destruction to allow for animations
    }
}
