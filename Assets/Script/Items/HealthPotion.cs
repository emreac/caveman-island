using UnityEngine;

[CreateAssetMenu(fileName = "New Health Potion", menuName = "Inventory/HealthPotion")]
public class HealthPotion : Item
{
    public int healthAmount;
   

    public override void Use()
    {
        base.Use();
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {

            if (playerHealth.currentHealth < playerHealth.maxHealth)
            {
                playerHealth.Heal(healthAmount);
                Debug.Log("Health potion used, healing " + healthAmount);
                base.Use();
            }
            else
            {
                Debug.Log("Health is already full. Cannot use health potion.");
            }
        }
        else
        {
            Debug.LogWarning("Health is Full");
        }
    }
}
