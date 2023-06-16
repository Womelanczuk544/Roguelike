using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<Item> inventory;
    void Start()
    {
        inventory = new List<Item>();
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
