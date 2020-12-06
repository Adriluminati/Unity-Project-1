using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private bool ground;

    public float speed = 8f;
    public float jumpForce = 8f;

    // Start is called before the first frame update
    void Start()
    {
        ground = false;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(HorizontalMovement * speed, rb.velocity.y);

        //Jump
        if (Input.GetKey(KeyCode.Space) && ground)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //JumpMovement
        if (HorizontalMovement > 0 && !ground)
        {
            anim.SetBool("Jump", true);
            sr.flipX = false;
        }

        else if (HorizontalMovement < 0 && !ground)
        {
            anim.SetBool("Jump", true);
            sr.flipX = true;
        }

        else if (HorizontalMovement == 0 && !ground)
        {
            anim.SetBool("Jump", true);
        }

        else
        {
            anim.SetBool("Jump", false);
        }

        // HorizontalMovement
        if (HorizontalMovement > 0 && ground)
        {
            anim.SetBool("Walk", true);
            sr.flipX = false;
        }

        else if (HorizontalMovement < 0 && ground)
        {
            anim.SetBool("Walk", true);
            sr.flipX = true;
        }

        else
            anim.SetBool("Walk", false);
    }

    //ColliderDetection
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            ground = false;
        }
    }
}
