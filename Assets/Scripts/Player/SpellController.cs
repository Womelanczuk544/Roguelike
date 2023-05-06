using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpellController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public float projectileForce;
    private Animator animator;
    public bool canShoot = true;
    public bool meleAttack;

    //private Vector3 offset = new(0.233999997f, -0.224000007f, 0);
    private Vector3 offset = new(0, 0, 0);
    private Rigidbody2D rb;
    private GameObject basicProjectile;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        basicProjectile = projectile;
        meleAttack = true;
    }
    public void changeProjectile(GameObject newProjectile)
    {
        projectile = newProjectile;
    }

    public void returnBasicProjectile()
    {
        projectile = basicProjectile;
        meleAttack = true;
    }
    public void changeAttackType(bool type)
    {
        meleAttack = type;
    }
/*    IEnumerator AfterShooting()
    {
        yield return new WaitForSeconds(0.7f);

        animator.SetBool("isShooting", false);
        canShoot = true;
        
    }*/

    void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position + offset;
        Vector2 direction = (mousePos - myPos).normalized;
        
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            animator.SetFloat("mouseX", direction.x);
            animator.SetFloat("mouseY", direction.y);
            StartCoroutine( Shoot(direction));
        }
   
    }

    IEnumerator Shoot(Vector2 direction)
    {
        animator.SetBool("isShooting", true);
        canShoot = false;

        yield return new WaitForSeconds(0.5f);

       
        GameObject spell = Instantiate(projectile, transform.position + offset, Quaternion.identity);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        spell.GetComponent<Rigidbody2D>().rotation = angle;

        if (meleAttack==true)
        {
            spell.GetComponent<Spell>().meleAttack(0.5f);
            spell.GetComponent<Rigidbody2D>().velocity = direction * 0.3f;
        }
        else
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;

        //spell.transform.right = direction; hmmm

        

        yield return new WaitForSeconds(0.45f);
        canShoot = true;
        animator.SetBool("isShooting", false);
    }

}
