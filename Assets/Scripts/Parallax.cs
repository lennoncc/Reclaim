using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    
    private float length;
    private float startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start ()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() 
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
