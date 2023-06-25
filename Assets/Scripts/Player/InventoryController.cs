using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> inventory;
    void Start()
    {
        inventory = new List<Item>();
        if (SaveSystem.LoadInventory() != null)
        {
            List<string> temp = SaveSystem.LoadInventory() as List<string>;
            for(int i = 0; i < temp.Count; i++)
            {
                GameObject prefab = Resources.Load<GameObject>(temp[i]);
                GameObject newObject = Instantiate(prefab);
                //foreach(Item item in allItemes)
                //{
                //    if (item.name == temp[i])
                //    {
                //        add(item);
                //    }
                //}
            }
        }
    }
    public void add(Item item)
    {
        if (item.classId != 0)
            foreach (Item item2 in inventory)
            {
                if (item2.classId == item.classId)
                {
                    item2.onRemove();
                    inventory.Remove(item2);
                }
            }
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
