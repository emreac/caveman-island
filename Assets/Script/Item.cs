using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int maxStackSize = 99; // Maximum number of items per stack

    public virtual void Use()
    {
        Debug.Log("Using " + itemName);
    }
}
