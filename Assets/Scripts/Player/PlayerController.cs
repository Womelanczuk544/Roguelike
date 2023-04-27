using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 movementDirection;
    private SpriteRenderer spriteRenderer;
    private bool isDashing = false;
    private bool canDash = true;
    private float maxHealth;
    private float currentHealth;


    public float speed = 1f;
    public float dashForce = 1f;
    public float dashiingTime = 2f;
    //public float health;
    private SpellController spellController;
    public float baseHealth;
    public GameObject healthBar;
    private HealthBar healthbarScript;

    // Start is called before the first frame update
    void Start()
    {
        healthbarScript = healthBar.GetComponent<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spellController = GetComponent<SpellController>();
        //rb.isKinematic = true;

    
        currentHealth = baseHealth;
        maxHealth = baseHealth;
        healthbarScript.SetMaxHealth(baseHealth);
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = -(int)transform.position.y;
        movementDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        animator.SetFloat("walkDirectionX", (float)movementDirection.x);
        animator.SetFloat("walkDirectionY", (float)movementDirection.y);
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
            if(movementDirection.x != 0)
            {
                animator.SetBool("isRunningSideways", true);
            }
            else
            {
                animator.SetBool("isRunningSideways", false);
            }

        }
        else
        {
            animator.SetBool("isRunningSideways", false);
            StartCoroutine(ChangeIsRunning());
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

    }

    IEnumerator ChangeIsRunning()
    {
        yield return new WaitForSeconds(0.05f);
        if(movementDirection == Vector3.zero)
        {
            animator.SetBool("isRunning", false);
            
        }
    }
    
    public void boostMaxHealth(float value, bool is_healed)
    {        
        maxHealth += value;
        if (is_healed) currentHealth += value;
        healthbarScript.SetMaxHealth(maxHealth);
        healthbarScript.SetHealth(currentHealth);
        Debug.Log(currentHealth);
        Debug.Log(maxHealth);
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        healthbarScript.SetHealth(currentHealth);
        if (currentHealth < 0)
        {
            Debug.Log("dowodca nie zyje");
        }
        if (currentHealth > maxHealth) 
            currentHealth = maxHealth; //heal works as damage
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("tam");
    //    if (collision.gameObject.tag == "Obstacle")
    //    {
    //        transform.position = transform.position;
    //        Debug.Log("tu");
    //    }
    //}
    
/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Obstacle")
        {
            //it is called property, hoever it doesn't stop player
            transform.position = transform.position;
        }
    }*/

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = movementDirection.normalized * dashForce;
        /* rb.AddForce(movementDirection.normalized * dashForce, ForceMode2D.Impulse);*/
        yield return new WaitForSeconds(dashiingTime);
        canDash = true;
        isDashing = false;
    }

    private void FixedUpdate()
    {
        if (!spellController.canShoot)
        {
            rb.velocity = Vector2.zero;
        }
        if (!isDashing && spellController.canShoot)
        {
            rb.velocity = movementDirection.normalized * speed;
        }
    }

}
