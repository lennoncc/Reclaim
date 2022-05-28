using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    [SerializeField] private float scrollingTextTime = 1.5f;
    [SerializeField] private Vector3 offset = new Vector3(-1.0f, 1.0f, 0.0f);

    void Start()
    {
        this.transform.position = this.transform.position + this.offset;
        Destroy(this.gameObject, this.scrollingTextTime);
    }
}
