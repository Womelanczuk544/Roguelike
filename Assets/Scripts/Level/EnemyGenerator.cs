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
    public void generate(string cameFrom)
    {
        int numOfEnemies = UnityEngine.Random.Range(2 + currentLevel, 4 + currentLevel);
        float minX = (cameFrom == "left") ? -9 : -17;
        float maxX = (cameFrom == "right") ? 9 : 16;
        float minY = (cameFrom == "down") ? -1 : -9;
        float maxY = (cameFrom == "up") ? 1 : 9;
        for (int i = 0; i < numOfEnemies; i++)
        {
            int index = UnityEngine.Random.Range(0, 3);
            float posX = UnityEngine.Random.Range(minX, maxX);
            float posY = UnityEngine.Random .Range(minY, maxY);
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
