using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> inventory;
    void Start()
    {
        inventory = new List<Item>();
        if(SaveSystem.LoadInventory() != null)
           foreach (Item item in SaveSystem.LoadInventory())
            {
                add(item);
            }
    }
    public void add(Item item)
    {
        inventory.Add(item);
        item.onAdd();
    }
    public void dropAllItems()
    {
        foreach (Item item in inventory)
        {
            item.onRemove();
        }
        inventory.Clear();
    }
}
