using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamberMovement : MonoBehaviour
{
    public float speed = 750;
    public float jumpForce = 35; // Realistic when gravity scale under rigidbody2D is 9.8
    Vector2 move;
    Rigidbody2D rb;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("IsSideScrolling", true);
    }

    // Update is called once per frame
    void Update()
    {
        // "move" detects the direction of movement Camber is moving to, provided from GetAxisRaw()
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Flip the sprite left or right if needed dependent on horizontal movement
        if (move.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (move.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        // if (Input.GetButtonDown("Fire1"))
        // {
        //     FindObjectOfType<SoundManager>().PlayMusicTrack("Act1");
        // }

        // if (Input.GetButtonDown("Fire2"))
        // {
        //     FindObjectOfType<SoundManager>().PlayMusicTrack("Act2");
        // }
        // Animation link
        // var animator = this.gameObject.GetComponent<Animator>();
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
