using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackSizeText;
    private Item item;
    private int stackSize;
    public Player player; // Reference to the Player script

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnItemClicked);
    }

    public void AddItem(Item newItem, int count)
    {
        item = newItem;
        stackSize = count;
        icon.sprite = item.icon;
        icon.enabled = true;
        UpdateStackSizeText();

        // Play animation when an item is added
        PlayAddItemAnimation();
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        stackSize = 0;
        UpdateStackSizeText();
    }

    public void OnItemClicked()
    {
        if (item != null)
        {
            if (item is SwordItem swordItem)
            {
                player.EquipSword(swordItem);
            }
            else if (item is HealthPotion)
            {
                UseItem();
            }
        }
    }

    public void UseItem()
    {
        if (item != null && stackSize > 0)
        {
            bool used = item.Use();
            if (used)
            {
                RemoveFromStack(1);
            }
        }
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
        if (stackSize <= 0)
        {
            PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
            playerInventory.RemoveItem(item);
            ClearSlot();
        }
        UpdateStackSizeText();
    }

    private void UpdateStackSizeText()
    {
        stackSizeText.text = stackSize > 1 ? stackSize.ToString() : "";
    }

    private void PlayAddItemAnimation()
    {
        // Scale up and then back to normal for a pop effect
        transform.localScale = Vector3.one * 1.2f;
        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
    }
}
