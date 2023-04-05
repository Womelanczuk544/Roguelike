using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public float projectileForce;
    private Animator animator;
    private bool canShoot = true;
    private Vector3 offset = new(0.233999997f, -0.224000007f, 0);

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator AfterShooting()
    {
        yield return new WaitForSeconds(0.7f);

       /* animator.SetBool("isShooting", false);*/
        canShoot = true;
        
    }

    void Update() {

        animator.SetBool("isShooting", false);
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine( Shoot());
        }
   
    }

    IEnumerator Shoot()
    {
        animator.SetBool("isShooting", true);
        canShoot = false;

        yield return new WaitForSeconds(0.4f);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position + offset;
        Vector2 direction = (mousePos - myPos).normalized;
        GameObject spell = Instantiate(projectile, transform.position + offset, Quaternion.identity);

        spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;

        spell.transform.right = direction;

        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }


}
