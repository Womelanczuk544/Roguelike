using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryController : MonoBehaviour
{
    public List<Item> inventory;
    public static List<Item> allItemes = new List<Item>();
    private bool addAll = true;
    void Start()
    {
        inventory = new List<Item>();
        addAll = false;
        foreach (Item item in allItemes)
        {            
            add(item);
        }
        addAll = true;
    }
    public void add(Item item)
    {
        bool d = false;
        Item temp = item;
        if (item.classId != 0)
            foreach (Item item2 in inventory)
            {
                if (item2.classId == item.classId)
                {
                    temp = item2;
                    d = true;
                }
            }
        if (d == true)
        {
            temp.onRemove();
            inventory.Remove(temp);
            allItemes.Remove(temp);
        }
        inventory.Add(item);
        if (addAll==true)
            allItemes.Add(item);
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
