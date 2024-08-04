using UnityEngine;

[CreateAssetMenu(fileName = "New Health Potion", menuName = "Inventory/HealthPotion")]
public class HealthPotion : Item
{
    public int healthAmount;
    public GameObject healEffectPrefab; // Reference to the particle system prefab

    public override bool Use()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            if (playerHealth.currentHealth < playerHealth.maxHealth)
            {
                playerHealth.Heal(healthAmount);
                Debug.Log("Health potion used, healing " + healthAmount);

                // Instantiate and play the heal effect at the player's position
                if (healEffectPrefab != null)
                {
                    GameObject healEffect = Instantiate(healEffectPrefab, playerHealth.transform.position, Quaternion.identity);
                    ParticleSystem particleSystem = healEffect.GetComponent<ParticleSystem>();
                    if (particleSystem != null)
                    {
                        particleSystem.Play();
                    }
                    Destroy(healEffect, 2f); // Destroy the particle system after it finishes
                }

                return true; // Potion was used
            }
            else
            {
                Debug.Log("Health is already full. Cannot use health potion.");
                return false; // Potion was not used
            }
        }
        else
        {
            Debug.LogWarning("PlayerHealth component not found in the scene.");
            return false; // Potion was not used
        }
    }
}
