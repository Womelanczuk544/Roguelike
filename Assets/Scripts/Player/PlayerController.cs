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
    public float maxHealth;
    public float currentHealth;
    private float damageMultiplayer;
    private SpellController spellController;
    private HealthBar healthbarScript;
    private float scale;
    private static PlayerController instance;

    public float speed = 1f;
    public float dashForce = 1f;
    public float dashiingTime = 2f;
    public float baseHealth;
    public GameObject gun;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
       
        scale = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spellController = GetComponent<SpellController>();

        damageMultiplayer = 1;
        currentHealth = baseHealth;
        maxHealth = baseHealth;
        instance = this;
    }
    private void Awake()
    {
        if (instance == null)
        {
            // If not, set the current instance as the active instance
            instance = this;
            // Set this object as the root of the hierarchy so it won't be destroyed
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
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
        if (maxHealth < 230)
        {
            float lenghtChanged = value*3.5f + maxHealth + 250;
            GameObject.Find("Border").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, lenghtChanged);
            Debug.Log(maxHealth);
            
        }
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
<<<<<<< Updated upstream
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            shop.money += score;
=======
        if (damage < 0)//heal works as damage
        {
            currentHealth -= damage;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }
        else
        {

            currentHealth -= armor * damage;
        }
        healthbarScript.SetHealth(currentHealth);
        if (currentHealth < 0)
        {
            shop.money += score;
            currentHealth = maxHealth;
            SaveSystem.DeleteLevel();
            SaveSystem.DeleteInventory();
>>>>>>> Stashed changes
            SceneManager.LoadScene("Game over");
        }

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
<<<<<<< Updated upstream
=======

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            speed = data.speed;
            dashForce = data.dashForce;
            dashiingTime = data.dashiingTime;
            baseHealth = data.baseHealth;
            currentHealth = data.currentHealth;
        }
    }
>>>>>>> Stashed changes
}
