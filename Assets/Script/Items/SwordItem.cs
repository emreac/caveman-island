using UnityEngine;

[CreateAssetMenu(fileName = "New Sword Item", menuName = "Inventory/SwordItem")]
public class SwordItem : Item
{
    public int additionalDamage; // Additional damage when the sword is equipped
}
