using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent; // The parent object of all the item slots
    public GameObject inventoryUI; // The entire UI object to turn on and off

    InventorySlot[] slots; // Array to hold all the slots

    void Start()
    {
        // Get all the slots from the items parent
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void UpdateUI(List<Item> items)
    {
        // Clear all slots first
        foreach (var slot in slots)
        {
            slot.ClearSlot();
        }

        // Loop through all slots and update them with the items
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].AddItem(items[i], 1); // Assuming 1 as the count for simplicity
        }
    }

    public int GetSlotCount()
    {
        return slots.Length;
    }
}
