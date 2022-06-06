using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameDialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;

    [SerializeField]
    public string nextScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other && other.tag == "Camber")
        {
            FindObjectOfType<DialogueManager>().EnqueueDialogues(dialogue);
            other.GetComponent<CamberMovement>().animator.SetFloat("Velocity", 0);
            other.GetComponent<CamberMovement>().enabled = false;
            FindObjectOfType<PanCamera>().enabled = true;
            FindObjectOfType<DialogueController>().enabled = true;
        }
        
    }
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone == true)
        {
            FindObjectOfType<SceneSwitchTrigger>().LoadScene(nextScene);
        }
    }
}
