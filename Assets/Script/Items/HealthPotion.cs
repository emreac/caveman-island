using UnityEngine;

public class HealthPotion : Item
{
    public int healthAmount;
    public PlayerHealth playerHealth;

    public override void Use()
    {
        base.Use();
        if (playerHealth != null)
        {
            playerHealth.Heal(healthAmount);
            Debug.Log("Health potion used, healing " + healthAmount);
        }
        else
        {
            Debug.LogWarning("PlayerHealth component not assigned.");
        }
    }
}
