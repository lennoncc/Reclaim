using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite defaultImage;
    [SerializeField]
    private Sprite pressedImage;
    [SerializeField]
    private string buttonToPress;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown(buttonToPress))
        {
            spriteRenderer.sprite = pressedImage;
        }

        if (Input.GetButtonUp(buttonToPress))
        {
            spriteRenderer.sprite = defaultImage;
        }
        
    }

    public void Press(string color)
    {
        var notes = GameObject.FindGameObjectsWithTag("Note");
        foreach (var clone in notes)
        {
            if (clone.name == "Falling"+color+"(Clone)")
            {
                clone.GetComponent<NoteObject>().Press();
            }
        }
    }
}
