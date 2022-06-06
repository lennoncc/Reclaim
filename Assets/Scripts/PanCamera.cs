using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    public GameObject controlCamera;

    public int howFar;
    [SerializeField]
    public float speed;
    public Vector3 desiredPos;
    public Vector3 currentPos;

    void Start()
    {
        this.controlCamera = GameObject.Find("Main Camera");
        this.controlCamera.GetComponent<CameraObjectFollow>().enabled = false;
        desiredPos = new Vector3(this.controlCamera.transform.position.x + howFar, this.controlCamera.transform.position.y, this.controlCamera.transform.position.z);
    }

    void FixedUpdate()
    {
        if(this.controlCamera.transform.position != desiredPos)
        {
            var from = new Vector3(this.controlCamera.transform.position.x, this.controlCamera.transform.position.y, this.controlCamera.transform.position.z);
            this.controlCamera.transform.position = Vector3.Lerp(from, desiredPos, speed);
        }
        
    }
}
