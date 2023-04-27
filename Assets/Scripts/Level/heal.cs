using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class heal : MonoBehaviour
{
    public float minHeal;
    public float maxHeal;
    public float upgradebase;
    // Start is called before the first frame update
    void Start()
    {
        if (minHeal > 0) minHeal = -minHeal;
        if (maxHeal > 0) maxHeal = -maxHeal;
        if (minHeal < maxHeal)
        {
            maxHeal = maxHeal + minHeal;
            minHeal = maxHeal - minHeal;
            maxHeal = maxHeal - minHeal;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
        {
            Destroy(gameObject);
            float heal = Random.Range(minHeal, maxHeal);
            collision.gameObject.GetComponent<PlayerController>().takeDamage(heal);
            if (upgradebase > 0)
                collision.gameObject.GetComponent<PlayerController>().boostMaxHealth(upgradebase, true);
        }
    }
}
