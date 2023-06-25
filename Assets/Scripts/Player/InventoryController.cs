using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<Item> inventory;
    private static InventoryController instance;
    void Start()
    {
        inventory = new List<Item>();
<<<<<<< Updated upstream
=======
        List<Item> list = new List<Item>();
        if (SaveSystem.LoadInventory() != null)
        {
            List<string> temp = SaveSystem.LoadInventory() as List<string>;
            list = StartCoroutine(itemAdd(temp));
            //for(int i = 0; i < 3; i++)
            //{
            //    Debug.Log(temp.Count + "kurwo jebana");
            //    //GameObject prefab = Resources.Load<GameObject>(temp[i]);
            //    //add(prefab.GetComponent<Item>());
            //}
        }
        else
        {
            Debug.Log("nie by³o mnie tam");
        }
    }

    IEnumerator itemAdd(List<string> temp)
    {
        List<Item> list = new List<Item>();
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(temp.Count + "kurwo jebana");
            GameObject prefab = Resources.Load<GameObject>(temp[i]);
            list.Add(prefab.GetComponent<Item>());
        }
        return list;
>>>>>>> Stashed changes
    }
/*    private void Awake()
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
    }*/

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
