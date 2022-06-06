using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().EnqueueDialogues(dialogue);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other && other.tag == "Camber")
        {
            FindObjectOfType<DialogueManager>().EnqueueDialogues(dialogue);
        }
    }
}