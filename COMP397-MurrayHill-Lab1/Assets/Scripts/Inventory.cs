using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log("Added item: " + item.itemName);
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log("Removed item: " + item.itemName);
        }
    }

    public void PrintInventory()
    {
        Debug.Log("Inventory Contents:");
        foreach (var item in items)
        {
            Debug.Log("- " + item.itemName + " (Value: " + item.value + ")");
        }
    }
}