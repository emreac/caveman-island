using UnityEngine;

[System.Serializable]
public class ItemCombination
{
    public Item item1;
    public Item item2;
    public Item result;
}

public class ItemCombinations : MonoBehaviour
{
    public ItemCombination[] combinations;

    public Item GetCombinationResult(Item item1, Item item2)
    {
        foreach (ItemCombination combination in combinations)
        {
            if ((combination.item1 == item1 && combination.item2 == item2) || (combination.item1 == item2 && combination.item2 == item1))
            {
                return combination.result;
            }
        }
        return null;
    }
}
