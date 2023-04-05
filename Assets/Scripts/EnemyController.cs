using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public GameObject player;
    private Vector3 movementDirection;
    public float speed = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
}
