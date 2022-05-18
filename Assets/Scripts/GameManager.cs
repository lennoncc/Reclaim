using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource music;
    private bool startPlaying;
    [SerializeField]
    private NoteController noteController;
    private static GameManager instance;
    private int currentScore;
    private int scorePerNote = 100;
    private int currentMultiplier;
    private int multiplierTracker;
    [SerializeField]
    private int[] multiplierThresholds;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text multiText;

    public static GameManager Instance
    {
        get => instance;
    }
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        multiplierTracker = 0;
        currentMultiplier = 1;
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                noteController.HasStarted = true;
                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierTracker >= multiplierThresholds[currentMultiplier - 1])
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text = "Multiplier: x" + currentMultiplier;
        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        // Reset multiplier if a note is missed.
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
    }
}
