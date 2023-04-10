using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 movementDirection;
    private SpriteRenderer spriteRenderer;
    private bool isDashing = false;
    private bool canDash = true;

    public float speed = 1f;
    public float dashForce = 1f;
    public float dashiingTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = -(int)transform.position.y;
        movementDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("isRunning", true);

            if (movementDirection.x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));
            }
            else if (movementDirection.x > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
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
        if (!isDashing)
        {
            rb.velocity = movementDirection.normalized * speed;
        }
    }

}
