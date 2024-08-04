using UnityEngine;

[System.Serializable]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int maxStackSize = 99; // Maximum number of items per stack

    public virtual bool Use()
    {
        Debug.Log("Using " + itemName);
        return true; // Default implementation, override in derived classes
    }
}
