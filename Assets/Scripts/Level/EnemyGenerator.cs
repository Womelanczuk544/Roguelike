using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject variant1;
    public GameObject variant2;
    public GameObject variant3;

    private List<GameObject> gameObjects;

    private GameObject active = null;
   
    private void Start()
    {
        gameObjects = new List<GameObject>();
        gameObjects.Add(variant1);
        gameObjects.Add(variant2);
        gameObjects.Add(variant3);
    }
    public void generate()
    {
        int index = UnityEngine.Random.Range(0,3);
        active = Instantiate(gameObjects[index]);
    }
    public void remove()
    {
        if (active != null)
            Destroy(active);
        active = null;
    }
}
