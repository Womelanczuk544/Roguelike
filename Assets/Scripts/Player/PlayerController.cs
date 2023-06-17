using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    private float damageMultiplayer;
    private SpellController spellController;
    private HealthBar healthbarScript;
    private float scale;

    public float speed = 4.5f;
    public float dashForce = 30f;
    public float dashiingTime = 0.09f;
    public float baseHealth = 100f;
    public GameObject healthBar;
    public GameObject gun;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        healthbarScript = healthBar.GetComponent<HealthBar>();
        scale = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spellController = GetComponent<SpellController>();

        damageMultiplayer = 1;
        currentHealth = baseHealth;
        maxHealth = baseHealth;
        healthbarScript.SetMaxHealth(baseHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //spriteRenderer.sortingOrder = -(int)transform.position.y;
        movementDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;
        Vector2 direction = (mousePos - myPos).normalized;
        if (direction.x < 0)
        {
            //this.spriteRenderer.flipX = true;
            transform.localScale = new Vector3(-scale, scale, scale);
            gun.transform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(scale, scale, scale);
            gun.transform.localScale = new Vector3(1, 1, 1);
        }

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("isRunning", true);


            if (movementDirection.x > 0 && direction.x > 0 || movementDirection.x < 0 && direction.x < 0)
            {
                animator.SetBool("lookingWhereGoing", true);
            }
            else
            {
                animator.SetBool("lookingWhereGoing", false);
            }

        }
        else
        {
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
        if (movementDirection == Vector3.zero)
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

    public void changeSpeed(float value)
    {
        speed *= value;
    }

    public void changeDamage(float value)
    {
        damageMultiplayer *= value;
    }
    public void setDamage(float _damage)
    {
        damageMultiplayer = _damage;
    }

    public float getDamageMultiplayer()
    {
        return damageMultiplayer;
    }

    public void getPoints(int _score)
    {
        score += _score;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        healthbarScript.SetHealth(currentHealth);
        if (currentHealth < 0)
        {
            shop.money += score;
            SceneManager.LoadScene("Game over");
        }
        if (currentHealth > maxHealth)
            currentHealth = maxHealth; //heal works as damage
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = movementDirection.normalized * dashForce;
        yield return new WaitForSeconds(dashiingTime);
        canDash = true;
        isDashing = false;
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = movementDirection.normalized * speed;

        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        speed = data.speed;
        dashForce = data.dashForce;
        dashForce = data.dashiingTime;
        baseHealth = data.baseHealth;
    }
}
