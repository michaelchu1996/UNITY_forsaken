using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public Animator animator;
    Rigidbody2D body;
    private bool facingRight = true;
    float horizontal;
    float vertical;
    float diagLimiter = 0.7f;
    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {


        horizontal = Input.GetAxisRaw("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical");

        animator.SetBool("moving", false);


        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("moving", true);
            animator.SetBool("forward", false);
            animator.SetBool("X_dir", false);

            if (!facingRight)
            {
                Flip();
            }
            facingRight = true;


        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("moving", true);
            animator.SetBool("forward", true);
            animator.SetBool("X_dir", false);
            if (!facingRight)
            {
                Flip();
            }
            facingRight = true;


        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(facingRight)
            {
                Flip();
            }
            facingRight = false;
            animator.SetBool("moving", true);
            animator.SetBool("X_dir", true);
            animator.SetBool("forward", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!facingRight)
            {
                Flip();
            }
            facingRight = true;

            animator.SetBool("moving", true);
            animator.SetBool("X_dir", true);
            animator.SetBool("forward", false);
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetTrigger("swingTrigger");
        }


    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= diagLimiter;
            vertical *= diagLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
