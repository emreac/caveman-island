using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public void AddItem(Item newItem)
    {
        icon.sprite = newItem.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}
