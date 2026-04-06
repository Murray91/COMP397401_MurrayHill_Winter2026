using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Inventory inventory = new Inventory();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Optional: create some items automatically for testing
        AddTestItems();
    }

    public void AddItem(Item item)
    {
        inventory.AddItem(item);
    }

    public void RemoveItem(Item item)
    {
        inventory.RemoveItem(item);
    }

    public void PrintInventory()
    {
        inventory.PrintInventory();
    }

    // Add 4–5 items automatically
    private void AddTestItems()
    {
        AddItem(new Item("Health Potion", "Restores 50 HP", 50));
        AddItem(new Item("Mana Potion", "Restores 30 Mana", 30));
        AddItem(new Item("Fire Gem", "Special ability item", 100));
        AddItem(new Item("Gold Coin", "Collectible currency", 1));
        AddItem(new Item("Magic Scroll", "Boosts attack temporarily", 0));

        Debug.Log("Test items added!");
        PrintInventory();
    }
}
