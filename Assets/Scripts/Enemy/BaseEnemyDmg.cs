using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyDmg: MonoBehaviour
{
    private float time = 0;
    private bool isAttacking = false;
    private GameObject player;

    public float minDamage;
    public float maxDamage;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
        if (isAttacking==true)
        {
            time += Time.deltaTime;
            if(time > 1)
            {
                time = 0;
                float dmg = Random.Range(minDamage, maxDamage);
                player.GetComponent<PlayerController>().takeDamage(dmg);
            }
        }
        if (gameObject.GetComponent<EnemyController>().health <= 0)
        {
            minDamage = 0; 
            maxDamage = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.GameObject().tag == "Player")
        {
            isAttacking = true;
            float dmg = Random.Range(minDamage, maxDamage);
            collision.gameObject.GetComponent<PlayerController>().takeDamage(dmg);
        }
    }
    public void setDmg(float minDmg, float maxDmg)
    {
        minDamage = minDmg;
        maxDamage = maxDmg;
    }
}
