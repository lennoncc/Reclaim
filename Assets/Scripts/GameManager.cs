using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // [SerializeField]
    // private AudioSource music;
    private AudioSource music;
    private bool startPlaying;
    [SerializeField]
    private NoteController noteController;
    private static GameManager instance;
    private int currentScore;
    private int scorePerNote = 50;
    private int scorePerGoodNote = 80;
    private int scorePerPerfectNote = 100;
    private int currentMultiplier;
    private int multiplierTracker;
    [SerializeField]
    private int[] multiplierThresholds;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text multiText;
    private float totalNotes = 10;  /*temporary value*/
    private float missedHits;
    private float okHits;
    private float goodHits;
    private float perfectHits;
    [SerializeField]
    private GameObject resultsScreen;
    [SerializeField]
    private Text percentAccuracyText, missedText, okText, goodText, perfectText, finalScoreText;

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
            // Start the level.
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                noteController.HasStarted = true;
                // music.Play();
                FindObjectOfType<SoundManager>().PlayMusicTrack("Prologue");
                music = FindObjectOfType<SoundManager>()._trackPlaying.audioSource;
            }
        }
        else
        {
            // Show the results at the end of the level.
            if (!music.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                missedText.text = missedHits.ToString();
                okText.text = okHits.ToString();
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();

                float percentAccuracy = (((okHits * 0.5f) + (goodHits * 0.8f) + perfectHits) / totalNotes) * 100f;
                // Show percentage as a float to 1 decimal place.
                percentAccuracyText.text = percentAccuracy.ToString("F1") + "%";
                finalScoreText.text = currentScore.ToString();

                /*TODO: Get Stars value, Add Stars value to finalScoreText*/
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

    public void OkHit()
    {
        currentScore += scorePerNote + currentScore;
        NoteHit();
        okHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote + currentScore;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote + currentScore;
        NoteHit();
        perfectHits++;
    }
    public void NoteMissed()
    {
        // Reset multiplier if a note is missed.
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
        missedHits++;
    }
}
