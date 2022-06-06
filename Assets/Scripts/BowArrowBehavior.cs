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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }
}
