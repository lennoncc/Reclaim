using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hero.Command;

public class HeroController : MonoBehaviour
{
    private IHeroCommand fire1;
    private IHeroCommand fire2;
    private IHeroCommand right;
    private IHeroCommand left;
    private IHeroCommand space;
    private bool isStateJump;

    // Start is called before the first frame update
    void Start()
    {
        this.right = ScriptableObject.CreateInstance<MoveHeroRight>();
        this.left = ScriptableObject.CreateInstance<MoveHeroLeft>();
        this.space = ScriptableObject.CreateInstance<JumpHero>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0.01)
        {
            this.right.Execute(this.gameObject);
        }
        if(Input.GetAxis("Horizontal") < -0.01)
        {
            this.left.Execute(this.gameObject);
        }
        if(Input.GetKeyDown("space") && !isStateJump) 
        {
            this.isStateJump = true;
            this.space.Execute(this.gameObject);
        }

        var animator = this.gameObject.GetComponent<Animator>();
        animator.SetFloat("Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.tag == "Ground")
        {
            this.isStateJump = false;
        }
    }
}