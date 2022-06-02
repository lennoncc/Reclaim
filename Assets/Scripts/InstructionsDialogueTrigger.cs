using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsDialogueTrigger : MonoBehaviour
{
    // public Dialogue[] dialogue;

    void Awake()
    {
        Debug.Log("starting");
        GameObject.Find("Instructions").GetComponent<Renderer>().enabled = true;
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        // FindObjectOfType<DialogueManager>().EnqueueDialogues(dialogue);
    }
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone == true)
        {
            GameObject.Find("Instructions").GetComponent<Renderer>().enabled = false;
        }
    }
}
