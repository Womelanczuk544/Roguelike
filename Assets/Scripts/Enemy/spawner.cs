using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private float health;
    private float time;

    public float spawnTimer;
    public GameObject enemyPrefab;
    public Transform spawnPosition;
    public int maxSpanws;
    //public int maxChildren; //optionaly todo

    // Start is called before the first frame update
    void Start()
    {
        health = 150;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > spawnTimer && EnemyController.count < maxSpanws)
        {            
            Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity);
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
