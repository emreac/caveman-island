using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory; // Reference to the Inventory script

    public void AddItem(Item item)
    {
        bool added = inventory.Add(item);
        if (added)
        {
            Debug.Log("Added " + item.name + " to inventory");
        }
    }

    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
        Debug.Log("Removed " + item.name + " from inventory");
    }
}
