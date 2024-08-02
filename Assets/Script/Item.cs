using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public int maxStackSize = 99;

    public virtual void Use()
    {
        Debug.Log("Using " + itemName);
    }
}
