using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject swordObject; // The 3D sword object in the player's hand
    public int baseDamage = 30;
    private int currentDamage;
    private SwordItem equippedSword;

    void Start()
    {
        currentDamage = baseDamage;
        swordObject.SetActive(false); // Ensure the sword is initially inactive
    }

    public void EquipSword(SwordItem sword)
    {
        equippedSword = sword;
        swordObject.SetActive(true);
        currentDamage = baseDamage + sword.additionalDamage;
        Debug.Log("Sword equipped, current damage: " + currentDamage);
    }

    public void UnequipSword()
    {
        equippedSword = null;
        swordObject.SetActive(false);
        currentDamage = baseDamage;
        Debug.Log("Sword unequipped, current damage: " + currentDamage);
    }

    public int GetCurrentDamage()
    {
        return currentDamage;
    }

    public void Heal(int amount)
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(amount);
        }
    }
}
