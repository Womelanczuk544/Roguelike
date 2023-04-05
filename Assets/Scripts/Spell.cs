using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
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
        Destroy(gameObject);
        print(collision.gameObject.name);

        float dmg = Random.Range(minDamage, maxDamage);
        collision.gameObject.GetComponent<EnemyController>().takeDamage(dmg);
    }
}
