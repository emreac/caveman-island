using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText; // Reference to the UI Text element for current health
    public TextMeshProUGUI maxHealthText; // Reference to the UI Text element for max health
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script

    void Start()
    {
        // Initialize the health texts
        UpdateHealthText();
        UpdateMaxHealthText();
    }

    public void UpdateHealthText()
    {
        if (healthText != null && playerHealth != null)
        {
            healthText.text = "" + playerHealth.currentHealth;
        }
    }

    public void UpdateMaxHealthText()
    {
        if (maxHealthText != null && playerHealth != null)
        {
            maxHealthText.text = "" + playerHealth.maxHealth;
        }
    }
}
