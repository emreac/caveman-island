using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
  
    private Item item;
    private int stackSize;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(UseItem);
    }

    public void AddItem(Item newItem, int count)
    {
        item = newItem;
        stackSize = count;
        icon.sprite = item.icon;
        icon.enabled = true;
     
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        stackSize = 0;
     
    }

    public void UseItem()
    {
        if (item != null)
        {
            if (CanUseItem())
            {
                item.Use();
                RemoveFromStack(1);
            }
            else
            {
                Debug.Log("Item cannot be used right now.");
            }
        }
    }

    private bool CanUseItem()
    {
        if (item is HealthPotion)
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            return playerHealth != null && playerHealth.currentHealth < playerHealth.maxHealth;
        }
        return true; // For other item types, you might have different conditions
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
        if (stackSize <= 0)
        {
            Inventory inventory = FindObjectOfType<Inventory>();
            inventory.Remove(item);
        }
        
    }

 
}
