using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Parallax : MonoBehaviour
{
    public float parallaxMagnitude;
    public Camera cam;

    private float spriteLength;
    private float spriteLeft;
        
    void Start()
    {
        this.spriteLeft = this.transform.position.x;
        this.spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float distToSpriteEnd = (this.cam.transform.position.x * this.parallaxMagnitude);
        float distAlongSprite = (this.cam.transform.position.x * (1 - this.parallaxMagnitude));

        this.transform.position = new Vector3(this.spriteLeft + distToSpriteEnd, this.transform.position.y, this.transform.position.z);

        if (distAlongSprite >= this.spriteLeft + this.spriteLength)
        {
            this.spriteLeft += this.spriteLength;
        } 
        else if (distAlongSprite < this.spriteLeft - this.spriteLength)
        {
            this.spriteLeft -= this.spriteLength;
        }
    }
}