using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spell : MonoBehaviour
{
    private float time = 0;

    public float timeToLive = 100;
    public float minDamage;
    public float maxDamage;
    public bool isMele;
    void Start()
    {
        Cleaner.add(gameObject);
        float temp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getDamageMultiplayer();
        minDamage *= temp;
        maxDamage *= temp;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeToLive)
        {
            Cleaner.remove(gameObject);
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x > 18 || gameObject.transform.position.x < -19 ||
            gameObject.transform.position.y > 11 || gameObject.transform.position.y < -11)
        {
            Cleaner.remove(gameObject);
            Destroy(gameObject);
        }
    }
    public void meleAttack(float ttl)
    {
        timeToLive = ttl;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player") return;
        if (collision.GameObject().tag == "Unit_enemy")
        {
            //Destroy(gameObject);
            float dmg = Random.Range(minDamage, maxDamage);
            collision.gameObject.GetComponent<EnemyController>().takeDamage(dmg);
        }
        if (collision.GameObject().tag == "spawner")
        {
            //Destroy(gameObject);
            float dmg = Random.Range(minDamage, maxDamage);
            collision.gameObject.GetComponent<spawner>().takeDamage(dmg);
        }
        if (collision.GameObject().tag == "Unit_enemy_schooting")
        {
            //Destroy(gameObject);
            float dmg = Random.Range(minDamage, maxDamage);
            collision.gameObject.GetComponent<Schooting_enemy>().takeDamage(dmg);
        }
        if (collision.GameObject().tag == "Obstacle")
        {
            //Destroy(gameObject);
        }
        if(isMele == false)
        {
            Cleaner.remove(gameObject);
            Destroy(gameObject);
        }
    }
}
