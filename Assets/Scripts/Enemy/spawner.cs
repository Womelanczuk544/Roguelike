using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : Enemy
{    
    private float time;    

    public float health;
    public float spawnTimer;
    public GameObject enemyPrefab;
    public Transform spawnPosition;
    public int maxSpanws;
    public float minDamage;
    public float maxDamage;
    //public int maxChildren; //optionaly todo

    // Start is called before the first frame update
    void Start()
    {
        onCreate();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > spawnTimer && EnemyController.counter < maxSpanws)
        {            
            GameObject baseEnemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity);
            baseEnemy.GetComponent<BaseEnemyDmg>().setDmg(minDamage, maxDamage);
            time = 0;
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <=0)
        {
            Destroy(gameObject);
        }
    }
}
