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
    public GameObject hands;
    public GameObject gun;

    private Vector3 offset = new(0, 0, 0);
    //private Rigidbody2D rb;
    private GameObject basicProjectile;
    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
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

    void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position + offset;
        Vector2 direction = (mousePos - myPos).normalized;
        
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            animator.SetFloat("mouseX", direction.x);
            //animator.SetFloat("mouseY", direction.y);

            StartCoroutine( Shoot(direction));
        }
   
    }

    IEnumerator Shoot(Vector2 direction)
    {
        //animator.SetBool("isShooting", true);
        canShoot = false;
        offset = gun.transform.localPosition;
       
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject spell = Instantiate(projectile, gun.transform.position, Quaternion.Euler(0f, 0f, angle));


        if (meleAttack==true)
        {
            spell.GetComponent<Spell>().meleAttack(0.3f);
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
        }
        else
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;

        //spell.transform.right = direction; hmmm

        

        //yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length - 0.5f);
        canShoot = true;
        // animator.SetBool("isShooting", false);
        yield return new WaitForSeconds(0.5f);
    }

}
