using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowArrowController : MonoBehaviour
{
    public BowArrowBehavior arrow;
    public Transform bowPosition;

    public void Shoot(){ 
        Instantiate(arrow, bowPosition.position, transform.rotation);
    }
}
