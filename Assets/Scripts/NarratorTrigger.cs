using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorTrigger : MonoBehaviour
{

    [SerializeField]
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        FindObjectOfType<DialogueController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone == true)
        {
            FindObjectOfType<SceneSwitchTrigger>().LoadScene(nextScene);
        }
    }
}
