using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public List<GameObject> enemies;
    public int currentLevel = 1;

    //private GameObject active = null;

    private void Start()
    {
    }
    public void generate()
    {
        int numOfEnemies = UnityEngine.Random.Range(2 + currentLevel, 3 + currentLevel);
        for (int i = 0; i < numOfEnemies; i++)
        {
            int index = UnityEngine.Random.Range(0, 3);
            float posX = UnityEngine.Random.Range(-17, 16);
            float posY = UnityEngine.Random .Range(-9, 9);
            Instantiate(enemies[index], new Vector2(posX,posY), Quaternion.identity);

        }
    }
/*    public void remove()
    {
        if (active != null)
            Destroy(active);
        active = null;
    }*/
}
