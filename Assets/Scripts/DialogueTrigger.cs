using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<PanCamera>().enabled = true;
        FindObjectOfType<DialogueManager>().EnqueueDialogues(dialogue);
        // FindObjectOfType<PanCamera>().enabled = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other && other.tag == "Camber")
        {
            // Debug.Log(other.tag);
            FindObjectOfType<DialogueManager>().EnqueueDialogues(dialogue);
            // other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.GetComponent<CamberMovement>().animator.SetFloat("Velocity", 0);
            other.GetComponent<CamberMovement>().enabled = false;
            FindObjectOfType<PanCamera>().enabled = true;

            // GameObject.Find("Camber").GetComponent<CamberMovement>().enabled = false;
        }
        
    }
}
