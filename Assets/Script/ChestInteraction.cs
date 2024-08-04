using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public Animator chestAnimator; // Reference to the Animator component
    public SwordItem swordItem; // Reference to the SwordItem ScriptableObject
    private bool isOpened = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            OpenChest(other.gameObject);
        }
    }

    void OpenChest(GameObject player)
    {
        // Play the opening animation
        chestAnimator.SetTrigger("Open");
        isOpened = true;

        // Give the player the sword item
        PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.AddItem(swordItem);
        }

        // Optionally, play a sound effect or particle effect
    }
}
