using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private static List<GameObject> activeList = new List<GameObject>();

    void Start()
    {

    }

    public static void add(GameObject element)
    {
        activeList.Add(element);
    }
    public static void remove(GameObject element)
    {        
        activeList.Remove(element);
        Destroy(element);
    }
    public static void clear()
    {
        foreach (GameObject x in activeList)
        {
            Destroy(x);
        }
        activeList.Clear();
    }    
}
