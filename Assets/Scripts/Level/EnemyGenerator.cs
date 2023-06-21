using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public List<GameObject> enemies;
    public static int currentLevel = 1;
    public bool playerIsInBossRoom = false;
    public GameObject teleport;

    //private GameObject active = null;

    private void Start()
    {
        if(SaveSystem.levelExist())
        {
            SaveSystem.LoadLevel().level= currentLevel;
        }
    }
    public void generate(string cameFrom)
    {
        playerIsInBossRoom = false;
        int numOfEnemies = UnityEngine.Random.Range(3 + (int)(currentLevel * 1.3f), 4 + (int)(currentLevel * 1.3f));
        float minX = (cameFrom == "left") ? -9 : -17;
        float maxX = (cameFrom == "right") ? 9 : 16;
        float minY = (cameFrom == "down") ? -1 : -9;
        float maxY = (cameFrom == "up") ? 1 : 9;
        for (int i = 0; i < numOfEnemies; i++)
        {
            int index = UnityEngine.Random.Range(0, enemies.Count);
            float posX = UnityEngine.Random.Range(minX, maxX);
            float posY = UnityEngine.Random.Range(minY, maxY);
            Instantiate(enemies[index], new Vector2(posX, posY), Quaternion.identity);
        }
    }

    public void nextLevel()
    {
        currentLevel++;
        Debug.Log(currentLevel);
    }

    public void generateBoss()
    {
        playerIsInBossRoom = true;
        int index = UnityEngine.Random.Range(0, enemies.Count);
        float posX = UnityEngine.Random.Range(-9, 9);
        float posY = UnityEngine.Random.Range(-1, 1);
        GameObject boss = Instantiate(enemies[index], new Vector2(posX, posY), Quaternion.identity);
        boss.transform.localScale *= 2;

        float minDmg = 20 + currentLevel * 2f;
        float maxDmg = 35 + currentLevel * 2f;
        float health = 270 + currentLevel * 50f;

        if (boss.name == "rat(Clone)") //to jest tak glupie 
        {
            boss.GetComponent<BaseEnemyDmg>().minDamage = minDmg;
            boss.GetComponent<BaseEnemyDmg>().maxDamage = maxDmg;
            boss.GetComponent<EnemyController>().health = health;
        }
        else if (boss.name == "small robot(Clone)")
        {
            boss.GetComponent<BaseEnemyDmg>().minDamage = minDmg;
            boss.GetComponent<BaseEnemyDmg>().maxDamage = maxDmg;
            boss.GetComponent<EnemyController>().health = health;
        }
        else if (boss.name == "Base_enemy_spawner(Clone)")
        {
            boss.GetComponent<spawner>().health = health;
            boss.GetComponent<spawner>().spawnTimer = 2f / currentLevel;
            boss.GetComponent<spawner>().maxSpanws = 4 + currentLevel;
            boss.GetComponent<spawner>().minDamage = minDmg;
            boss.GetComponent<spawner>().maxDamage = maxDmg;

        }
        else if (boss.name == "Enemy_schooting_triangle(Clone)")
        {
            boss.GetComponent<Schooting_enemy>().health = health;
            boss.GetComponent<Schooting_enemy>().minDmg = minDmg;
            boss.GetComponent<Schooting_enemy>().maxDmg = maxDmg;
            boss.GetComponent<Schooting_enemy>().projectileForce = 10 + 2 * currentLevel;
            boss.GetComponent<Schooting_enemy>().frequency = 2f / currentLevel;
        }
    }

    public void generateTeleport()
    {
        GameObject tp = Instantiate(teleport, new Vector3(0, 0, 0), Quaternion.identity);
        Cleaner.add(tp);
    }
    public int getCurrnetLevel()
    {
        return currentLevel;
    }
}
