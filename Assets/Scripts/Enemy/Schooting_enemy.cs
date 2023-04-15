using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Schooting_enemy : MonoBehaviour
{
    private float time;
    private GameObject player;

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
        Vector2 myPos = transform.position;
        Vector2 target = player.transform.position;
        Vector2 direction = (target - myPos).normalized;

        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); follow player

        //float angle = Vector3.Angle(target, transform.forward);
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        time += Time.deltaTime;
        if (time >= frequency)
        {            
            GameObject spell = Instantiate(projectile, myPos + direction, Quaternion.identity);
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
        
    }
}
