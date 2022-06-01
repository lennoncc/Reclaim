using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            // Debug.Log("BRUH");
        }
        
    }
}
