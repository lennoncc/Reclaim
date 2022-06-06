using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamberMovement : MonoBehaviour
{
    public float speed = 750;
    // Realistic when gravity scale under rigidbody2D is 9.8
    public float jumpForce = 35;
    Vector2 move;
    Rigidbody2D rb;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("IsSideScrolling", true);
    }

    void Update()
    {
        animator.SetBool("IsSideScrolling", true);
        // "move" detects the direction of movement Camber is moving to, provided from GetAxisRaw()
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Mobile support for movement. Tap right to go right and tap left to go left.
        if (Input.GetMouseButton(0)) {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float difference = touchPos.x - rb.transform.position.x;
            Debug.Log(difference);
            if (difference > 1) 
            {
                move.x = 1;
            }

            if (difference < 1) 
            {
                move.x = -1;
            }
            
        }

        // Flip the sprite left or right if needed dependent on horizontal movement
        if (move.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (move.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        
        // Animation link
        animator.SetFloat("Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
    }

    void FixedUpdate()
    {
        // Move in horizontal direction; velocity is smoothed out via speed and Time.deltaTime
        rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);

        // Jump function with gravity effect
        if (Mathf.Abs(rb.velocity.y) < 0.001f && (Input.GetButtonDown("Jump") || move.y > 0))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
