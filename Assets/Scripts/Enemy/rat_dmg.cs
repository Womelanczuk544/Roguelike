using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat_dmg : MonoBehaviour
{
    public float minDamage;
    public float maxDamage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("to");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("dzia³a");
            float dmg = Random.Range(minDamage, maxDamage);
            collision.gameObject.GetComponent<PlayerController>().takeDamage(dmg);
        }
    }
}
