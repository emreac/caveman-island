using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    public int maxItems = 20;

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

    public void AddItem(Item item)
    {
        if (items.Count < maxItems)
        {
            items.Add(item);
            Debug.Log("Item added: " + item.itemName);
            Debug.Log("Current inventory items: " + string.Join(", ", items.ConvertAll(i => i.itemName)));
            UIManager.instance.UpdateUI();
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }
}
