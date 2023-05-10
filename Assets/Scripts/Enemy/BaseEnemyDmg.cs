using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyDmg: MonoBehaviour
{
    public float minDamage;
    public float maxDamage;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GameObject().tag == "Player")
    //    {
    //        float dmg = Random.Range(minDamage, maxDamage);
    //        collision.gameObject.GetComponent<PlayerController>().takeDamage(dmg);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GameObject().tag == "Player")
        {
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
