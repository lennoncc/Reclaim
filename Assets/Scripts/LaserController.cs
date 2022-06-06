using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public LaserBehavior laser;
    public Transform laserPosition;

    public void Fire(){ 
        Instantiate(laser, laserPosition.position, transform.rotation);
    }
}
