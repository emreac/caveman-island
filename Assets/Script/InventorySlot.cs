using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text stackSizeText; // UI element to display stack size
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
            item.Use();
            // Optionally reduce stack size after use
            RemoveFromStack(1);
        }
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
