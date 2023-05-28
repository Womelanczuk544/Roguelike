using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Schooting_enemy : Enemy
{
    private float time;
    private GameObject player;
    private Vector2 myPos;
    private Vector2 target;
    private Vector2 direction;
    private Vector3 movementDirection;
    private bool isAlive = true;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public GameObject projectile;
    public float projectileForce;
    public float health;
    public float frequency;
    public float minDmg;
    public float maxDmg;
    public Rigidbody2D rb;
    public float speed = 1f;
    public float radius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        onCreate();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myPos = transform.position;
        target = player.transform.position;
        direction = (target - myPos).normalized;
        movementDirection = player.transform.position - transform.position;
        if (movementDirection.x < 0)
        {
           spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX= false;
        }

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
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (radius < Math.Sqrt(Math.Pow(myPos.x - player.transform.position.x, 2) + Math.Pow(myPos.y - player.transform.position.y, 2)))
        {
            if (isAlive)
            {
                animator.SetBool("isMoving", true);
                rb.velocity = movementDirection.normalized * speed;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
            rb.velocity = Vector3.zero;
        }
    }
}
