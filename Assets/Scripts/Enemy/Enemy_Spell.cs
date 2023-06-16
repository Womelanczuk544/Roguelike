using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Spell : MonoBehaviour
{
    // Start is called before the first frame update
    private float minDamage;
    private float maxDamage;

    private void Start()
    {
        Cleaner.add(gameObject);
    }
    public void setValues(float minDamage, float maxDamage)
    {
        this.minDamage = minDamage; 
        this.maxDamage = maxDamage;
    }
    void Update()
    {
        if (gameObject.transform.position.x > 18 || gameObject.transform.position.x < -19 ||
            gameObject.transform.position.y > 11 || gameObject.transform.position.y < -11)
        {
            Cleaner.remove(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GameObject().CompareTag("Unit_enemy")) {
            return;
        }
        if (collision.GameObject().CompareTag("Player"))
        {
            Cleaner.remove(gameObject);
            Destroy(gameObject);
            float dmg = Random.Range(minDamage, maxDamage);
            collision.gameObject.GetComponent<PlayerController>().takeDamage(dmg);
        }
        if (collision.GameObject().tag != "Player")
        {
            Cleaner.remove(gameObject);
            Destroy(gameObject);
        }
    }
}
