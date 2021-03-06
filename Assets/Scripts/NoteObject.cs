using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private bool canBePressed;
    [SerializeField]
    private string buttonToPress;
    [SerializeField]
    private GameObject missEffect, hitEffect, goodEffect, perfectEffect;
    private Vector3 effectPosition;
    [SerializeField]
    private PlayerController playerController;

    public PlayerController PlayerController
    {
        get => playerController;
        set => playerController = value;
    }

    void Start()
    {
        effectPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        Application.targetFrameRate = 300;
    }

    void Update()
    {
        if (Input.GetButtonDown(buttonToPress))
        {
            if (canBePressed)
            {
                Press();
            }
        }
    }


    public void Press()
    {
        if (canBePressed)
        {
            // Make the note disappear when hit.
            gameObject.SetActive(false);
            // Ok hit.
            if (Mathf.Abs(transform.position.y - 1f) > 0.30f)
            {
                GameManager.Instance.OkHit();
                playerController.NoteHit(5f);
                Instantiate(hitEffect, effectPosition, hitEffect.transform.rotation);
            }
            // Good hit.
            else if (Mathf.Abs(transform.position.y -1f) > 0.20f)
            {
                GameManager.Instance.GoodHit();
                playerController.NoteHit(10f);
                Instantiate(goodEffect, effectPosition, goodEffect.transform.rotation);
            }
            // Perfect hit.
            else
            {
                GameManager.Instance.PerfectHit();
                playerController.NoteHit(15f);
                Instantiate(perfectEffect, effectPosition, perfectEffect.transform.rotation);
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
            if (other.tag == "Activator")
            {
                canBePressed = false;
                // Note is missed if correct button is not pressed by the time note exits hit box.
                GameManager.Instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
