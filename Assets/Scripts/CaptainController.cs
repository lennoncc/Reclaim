using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Captain.Command;

public class CaptainController : MonoBehaviour
{
    private ICaptainCommand fire1;
    private ICaptainCommand fire2;
    private ICaptainCommand right;
    private ICaptainCommand left;
    // Part of my implementation for Stage 4 included an extra binding for
    // forcing the pirate to fast fall
    private ICaptainCommand down;

    [SerializeField]
    private UnityEngine.UI.Text booty;
    private int mushrooms;
    private int skulls;
    private int gems;

    // Start is called before the first frame update
    void Start()
    {
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        // this.booty.text = "Booty";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.fire1.Execute(this.gameObject);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            this.fire2.Execute(this.gameObject);
        }
        if(Input.GetAxis("Horizontal") > 0.01)
        {
            Debug.Log("right");
            this.right.Execute(this.gameObject);
        }
        if(Input.GetAxis("Horizontal") < -0.01)
        {
            Debug.Log("left");
            this.left.Execute(this.gameObject);
        }
        if(Input.GetAxis("Vertical") < -0.01) 
        {
            this.down.Execute(this.gameObject);
        }

        var animator = this.gameObject.GetComponent<Animator>();
        animator.SetFloat("Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
        // this.booty.text = "x" + (this.mushrooms * 1 + this.gems * 3 + this.skulls * 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        // if (collision.gameObject.tag == "Mushroom")
        // {
        //     Destroy(collision.gameObject);
        //     this.mushrooms++;
        // }
        // else if (collision.gameObject.tag == "Skull")
        // {
        //     Destroy(collision.gameObject);
        //     this.skulls++;
        // }
        // else if(collision.gameObject.tag == "Gem")
        // {
        //     Destroy(collision.gameObject);
        //     this.gems++;
        // }
    }
}