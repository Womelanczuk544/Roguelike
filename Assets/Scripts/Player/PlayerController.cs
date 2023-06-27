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
    private SpellController spellController;
    private HealthBar healthbarScript;
    private float scale;

    public float damageMultiplayer = 1f;
    public float dashRechargeTime = 2f;
    public float armor = 1.0f;
    public float currentHealth;
    public float speed = 4.5f;
    public float dashForce = 30f;
    public float dashiingTime = 0.09f;
    public float baseHealth = 100f;
    public static int score;
    public bool dashBought = false;
    public GameObject healthBar;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
        healthbarScript = healthBar.GetComponent<HealthBar>();
        scale = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spellController = GetComponent<SpellController>();
        Debug.Log(score + " punkciki");

        //currentHealth = baseHealth;
        maxHealth = baseHealth;
        healthbarScript.SetMaxHealth(baseHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("TextCurrentHp")!=null)
        {
            GameObject.Find("TextCurrentHp").GetComponent<Text>().text= currentHealth.ToString() + "/" + maxHealth.ToString();
        }
        //spriteRenderer.sortingOrder = -(int)transform.position.y;
        movementDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        healthbarScript.SetHealth(currentHealth);

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

        if (Input.GetKeyDown(KeyCode.Space) && canDash && dashBought)
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
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
        if(healthbarScript != null)
        {

        healthbarScript.SetMaxHealth(maxHealth);
        healthbarScript.SetHealth(currentHealth);
        }
    }
    public void changeDashingRecharge(float value)
    {
        dashRechargeTime *= value;
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
        Debug.Log(score + " tyle bratku teraz jest");
    }

    public void takeDamage(float damage)
    {
        if (damage < 0) 
            currentHealth -= damage;
        else
            currentHealth -= armor*damage;
        healthbarScript.SetHealth(currentHealth);
        if (currentHealth < 0)
        {
            GameObject.FindWithTag("Shop").GetComponent<shop>().money += score;
            SaveSystem.SaveShop(GameObject.FindGameObjectWithTag("Shop").GetComponent<shop>());
            currentHealth = maxHealth;
            SaveSystem.DeleteLevel();
            SaveSystem.DeleteInventory();
            SaveSystem.DeletePlayer();
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
        isDashing = false;
        yield return new WaitForSeconds(dashRechargeTime);
        canDash = true;
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
        if (data != null)
        {
            speed = data.speed;
            dashForce = data.dashForce;
            dashiingTime = data.dashiingTime;
            baseHealth = data.baseHealth;
            currentHealth = data.currentHealth;
            damageMultiplayer = data.dmg;
        }
        PlayerData data2= SaveSystem.LoadShop();
        if(data2 != null )
        {
            dashRechargeTime= data2.dashRechargeTime;
            dashBought = data2.dashBought;
            damageMultiplayer *= data2.dmg;
            baseHealth += data2.baseHealth;//tu moze byc blad
        }
    }

    public void clearScore()
    {
        score = 0;
    }
}
