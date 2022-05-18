using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField]
    // The beats per minute of the song.
    private float BPM = 120f;
    // The speed at wihch the notes fall.
    private float speed = 60f;
    private bool hasStarted;

    public bool HasStarted
    {
        get => hasStarted;
        set => hasStarted = value;
    }

    void Start()
    {
        BPM = BPM / speed;
    }

    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, BPM * Time.deltaTime, 0f);
        }
    }
}
