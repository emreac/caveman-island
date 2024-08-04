using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public HealthUI healthUI; // Reference to the HealthUI script

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthUI.UpdateHealthText(); // Initialize the health text
        healthUI.UpdateMaxHealthText(); // Initialize the max health text
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
        healthUI.UpdateHealthText(); // Update the health text
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthBar.SetHealth(currentHealth);
        healthUI.UpdateHealthText(); // Update the health text

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth; // Optionally, set current health to new max health
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        healthUI.UpdateMaxHealthText(); // Update the max health text
        healthUI.UpdateHealthText(); // Update current health text to reflect new max health
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Implement death behavior (e.g., respawn, game over screen, etc.)
    }
}
