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
    //public float projectileForce;
    private Animator animator;
    public bool canShoot = true;
    public GameObject hands;
    public GameObject gun;
    public AudioSource shootSound;


    private const float minRechargeTime = 0.1f;
    private float projectileForce;
    private int projectileSerie;
    private float rechargeTime;
    private Vector3 offset = new(0, 0, 0);
    private Rigidbody2D rb;
    private GameObject basicProjectile;
    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        basicProjectile = projectile;
        projectileForce = 10;
        projectileSerie = 1;
        rechargeTime = 0.5f;
    }

    public void setProjectileForce(float _projectileForce)
    {
        projectileForce = _projectileForce;
    }
    public void setRechargeTime(float _rechargeTime)
    {
        rechargeTime= _rechargeTime;
    }
    public void setProjectileSerie(int _projectileSerie)
    {
        projectileSerie= _projectileSerie;
    }

    public float getProjectileForce()
    {
        return projectileForce;
    }
    public float getRechargeTime()
    {
        return rechargeTime;
    }
    public int getProjectileSerie()
    {
        return projectileSerie;
    }

    public void returnBasicGun()
    {
        projectileForce = 10;
        projectileSerie = 1;
        rechargeTime = 0.5f;
    }

    public void changeProjectile(GameObject newProjectile)
    {
        projectile = newProjectile;
    }

    public void returnBasicProjectile()
    {
        projectile = basicProjectile;
    }
    void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position + offset;
        Vector2 direction = (mousePos - myPos).normalized;
        
        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine( Shoot(direction));
        }   
    }
    IEnumerator Shoot(Vector2 direction)
    {
        //animator.SetBool("isShooting", true);
        canShoot = false;
        //offset = gun.transform.localPosition;       

        shootSound.Play();
        for (int i = 0; i < projectileSerie; i++)
        {
                float shift = UnityEngine.Random.Range(-0.03f * projectileSerie, 0.03f * projectileSerie);
            if(rb.velocity == Vector2.zero)
            {
                shift = 0;
            }
            Vector2 tempDirection = new Vector2(direction.x + shift, direction.y + shift);
            float angle = Mathf.Atan2(tempDirection.y, tempDirection.x) * Mathf.Rad2Deg;
            GameObject spell = Instantiate(projectile, gun.transform.position, Quaternion.Euler(0f, 0f, angle));
            spell.GetComponent<Rigidbody2D>().velocity = tempDirection * projectileForce;
            yield return new WaitForSeconds(minRechargeTime);
        }

        yield return new WaitForSeconds(rechargeTime);
        canShoot = true;
    }
}
