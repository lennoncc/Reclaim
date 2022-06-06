using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(FindObjectOfType<DialogueManager>().dialogues.Count > 0)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
        
    }
}
