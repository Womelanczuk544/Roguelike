using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private GameObject player;
    private Vector3 movementDirection;

    public float speed = 1f;
    public float health = 100;

    public static int counter = 0;

    void Start()
    {
        counter++;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = -(int)transform.position.y;

        movementDirection = player.transform.position - transform.position; 
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection.normalized * speed;
    }

    private void OnDestroy()
    {
        counter--;
    }
}
