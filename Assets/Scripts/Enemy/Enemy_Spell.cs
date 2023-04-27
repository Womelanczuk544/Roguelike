using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Spell : MonoBehaviour
{
    // Start is called before the first frame update
    private float minDamage;
    private float maxDamage;
    public void setValues(float minDamage, float maxDamage)
    {
        this.minDamage = minDamage; 
        this.maxDamage = maxDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
        {
            Destroy(gameObject);
            float dmg = Random.Range(minDamage, maxDamage);
            collision.gameObject.GetComponent<PlayerController>().takeDamage(dmg);
        }
        if (collision.GameObject().tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
