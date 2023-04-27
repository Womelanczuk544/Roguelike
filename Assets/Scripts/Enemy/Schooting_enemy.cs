using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Schooting_enemy : MonoBehaviour
{
    private float time;
    private GameObject player;
    private Vector2 myPos;
    private Vector2 target;
    private Vector2 direction;

    public GameObject projectile;
    public float projectileForce;
    public float health;
    public float frequency;
    public float minDmg;
    public float maxDmg;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        myPos = transform.position;
        target = player.transform.position;
        direction = (target - myPos).normalized;

        time += Time.deltaTime;
        if (time >= frequency)
        {            
            GameObject spell = Instantiate(projectile, myPos + direction, Quaternion.identity);
            spell.GetComponent<Enemy_Spell>().setValues(minDmg, maxDmg);
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.transform.right = direction;
            time = 0;
        }
    }

    public void takeDamage(float damage)
    {
        health-=damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookdir = target - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
