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
        inventory.Add(item);
        Destroy(gameObject); // Destroy the item in the scene
    }
}
