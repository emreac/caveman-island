using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Transform itemsParent;
    public InventorySlot[] slots;

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void Add(Item item)
    {
        items.Add(item);
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].AddItem(items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
