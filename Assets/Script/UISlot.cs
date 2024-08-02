using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Image icon;

    public void SetItem(Item item)
    {
        if (item != null)
        {
            icon.sprite = item.itemIcon;
            icon.enabled = true;
            Debug.Log("UISlot set to item: " + item.itemName);
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
            Debug.Log("UISlot cleared");
        }
    }
}
