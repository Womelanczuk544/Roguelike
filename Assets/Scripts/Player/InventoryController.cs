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
            List<string> inventoryFromFile = SaveSystem.LoadInventory() as List<string>;
            for (int i = 0; i < inventoryFromFile.Count; i++)
            {
                string current = inventoryFromFile[i].Substring(0, inventoryFromFile[i].Length - 7);
                Debug.Log(current + " siema byku dodaje itemka");


                GameObject prefab = Resources.Load<GameObject>(current);
                if (prefab != null)
                {
                    add(prefab.GetComponent<Item>());
                }
                else
                {
                    Debug.Log("nie ma takiego itemka");
                }
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
                    break;
                }
            }
        else
        {
            item.onAdd();
            return;
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
