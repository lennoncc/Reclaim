using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private bool canBePressed;
    [SerializeField]
    private string buttonToPress;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown(buttonToPress))
        {
            if (canBePressed)
            {
                // Make the note disappear when hit.
                gameObject.SetActive(false);
                GameManager.Instance.NoteHit();
            }
        }
    }

    // Button can be pressed once arrow hit box collides with hit zone hit box.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Ensures that note cannot be missed if it was already hit.
        if (this.isActiveAndEnabled)
        {
            Debug.Log("miss");
            if (other.tag == "Activator")
            {
                canBePressed = false;
                // Note is missed if correct button is not pressed by the time note exits hit box.
                GameManager.Instance.NoteMissed();
            }
        }
    }
}
