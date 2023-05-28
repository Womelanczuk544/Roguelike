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

    public bool flyThrough;
    public float lifesteal;
    public float bloodDamage;

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
        if (collision.GameObject().tag == "Unit_enemy" || collision.GameObject().tag == "spawner" || collision.GameObject().tag == "Unit_enemy_schooting")
        {
            float dmg = Random.Range(minDamage, maxDamage);
            collision.gameObject.GetComponent<Enemy>().takeDamage(dmg);
        }
        if (collision.GameObject().tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        if (flyThrough == false)
        {
            Cleaner.remove(gameObject);
            Destroy(gameObject);
        }
    }
}
