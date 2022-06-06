using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowArrowBehavior : MonoBehaviour
{
    public float Speed = 4.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other && other.tag == "Enemy") {
            Destroy(this.gameObject);
        }
    }
}
