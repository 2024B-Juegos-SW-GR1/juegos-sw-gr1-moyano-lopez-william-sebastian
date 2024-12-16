using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private Animator anim;
    public float horizontal;
    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        anim.SetBool("running", horizontal != 0.0f);
        
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }
}
