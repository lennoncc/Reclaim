using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        // Debug.Log("Starting dialogue with " + dialogue.name);

        // Display name in UI.
        nameText.text = dialogue.name;

        // Clear previous dialogue.
        sentences.Clear();

        // Add serialized sentences into queue.
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        // Check if there are more sentences in queue.
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        // Get next sentence in queue.
        string sentence = sentences.Dequeue();

        // Stops all previous coroutines to account for if user 'continues' before end of animation of current sentence.
        StopAllCoroutines();
        // Call Coroutine to display dialogue in UI.
        StartCoroutine(TypeSentence(sentence));
        // Debug.Log(sentence);
    }

    // Coroutine to loop through each character in sentence. Used to add typed text effect.
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            // Add character to sentence one by one.
            dialogueText.text += letter;
            // Waits 2 frame to give animation effect.
            yield return null;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of dialogue.");
    }
}
