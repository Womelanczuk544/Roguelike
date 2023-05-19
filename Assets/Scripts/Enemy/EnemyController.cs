using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private GameObject player;
    private Vector3 movementDirection;
    private Animator animator;

    public float speed = 1f;
    public float health = 100;
    private bool isAlive = true;
    public static int counter = 0;

    void Start()
    {
        counter++;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        animator.SetBool("isAlive", false);
        isAlive = false;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {

            rb.velocity = movementDirection.normalized * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnDestroy()
    {
        counter--;
    }
}
