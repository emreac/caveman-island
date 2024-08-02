using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }

    void PickUp()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if (inventory.Add(item))
        {
            Destroy(gameObject); // Destroy the item in the scene only if it was successfully added
        }
        else
        {
            Debug.Log("Could not pick up item. Inventory is full.");
        }
    }
}
