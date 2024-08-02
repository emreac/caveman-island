using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public UISlot[] slots;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateUI()
    {
        // Clear all slots first
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetItem(null);
            Debug.Log("Slot " + i + " cleared");
        }

        // Add items to slots
        for (int i = 0; i < Inventory.instance.items.Count; i++)
        {
            slots[i].SetItem(Inventory.instance.items[i]);
            Debug.Log("Slot " + i + " set to item: " + Inventory.instance.items[i].itemName);
        }
    }
}
