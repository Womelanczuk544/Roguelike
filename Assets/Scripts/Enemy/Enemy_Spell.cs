using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Spell : MonoBehaviour
{
    // Start is called before the first frame update
    public float minDamage;
    public float maxDamage;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
        {
            Debug.Log("Motorniczy dostal, nie mozemy jechac");
            Destroy(gameObject);
            float dmg = Random.Range(minDamage, maxDamage);
            collision.gameObject.GetComponent<PlayerController>().takeDamage(dmg);
        }
        if (collision.GameObject().tag != "Player")
        {
            Destroy(gameObject);
            print(collision.gameObject.name);
        }
    }
}
