using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<int> itemCounts = new List<int>(); // To keep track of item counts
    public Transform itemsParent;
    public InventorySlot[] slots;

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public bool Add(Item item)
    {
        if (IsFull(item))
        {
            Debug.Log("Inventory is full!");
            return false; // Inventory is full
        }

        int index = items.IndexOf(item);
        if (index >= 0)
        {
            // Item already exists, increase stack size
            itemCounts[index]++;
        }
        else
        {
            // New item, add to inventory
            items.Add(item);
            itemCounts.Add(1);
        }
        UpdateUI();
        return true;
    }

    public void Remove(Item item)
    {
        int index = items.IndexOf(item);
        if (index >= 0)
        {
            itemCounts[index]--;
            if (itemCounts[index] <= 0)
            {
                items.RemoveAt(index);
                itemCounts.RemoveAt(index);
            }
        }
        UpdateUI();
    }

    public bool IsFull(Item item)
    {
        // Check if there is an empty slot or a slot with the same item that can stack more
        if (items.Count < slots.Length)
        {
            return false;
        }

        int index = items.IndexOf(item);
        if (index >= 0 && itemCounts[index] < item.maxStackSize)
        {
            return false; // Found a slot with space for more items of the same type
        }

        return true;
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].AddItem(items[i], itemCounts[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
