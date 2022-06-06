using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public BowArrowBehavior projectile;
    public Transform bowPosition;

    public void Shoot(){ 
        Instantiate(projectile, bowPosition.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other && other.tag == "Enemy") {
            Destroy(this.gameObject);
        }
    }
}
