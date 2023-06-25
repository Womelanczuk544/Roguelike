using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> inventory;
<<<<<<< Updated upstream
    void Start()
    {
        inventory = new List<Item>();
        if(SaveSystem.LoadInventory() != null)
           foreach (Item item in SaveSystem.LoadInventory())
           {
                add(item);
           }
=======
    public static List<Item> allItemes;
    private bool addAll = true;
    void Start()
    {
        inventory = new List<Item>();
        if (SaveSystem.LoadInventory() != null)
        {
            List<string> temp = SaveSystem.LoadInventory() as List<string>;
            
            for(int i = 0; i < temp.Count; i++)
            {
                //Item nowy = new Item("nazwa");
                //allItemes.Add(nowy);
                addAll = false;
                foreach(Item item in allItemes)
                {
                    if (item.name == temp[i])
                    {
                        add(item);
                    }
                }
                addAll = true;
            }
        }
>>>>>>> Stashed changes
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
