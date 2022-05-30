using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // [SerializeField]
    // private AudioSource music;
    private AudioSource music;
    [SerializeField]
    private string trackTitle;
    private bool startPlaying;
    [SerializeField]
    private NoteController noteController;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private EnemyController enemyController;
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
    private Text scoreMultiText;
    [SerializeField]
    private Text multiText;
    [SerializeField]
    private Text accuracyText;
    [SerializeField]
    private Text starsText;
    private float numNotes;
    private float missedHits;
    private float okHits;
    private float goodHits;
    private float perfectHits;
    private float percentAccuracy;
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
        numNotes = 0;
    }

    void Update()
    {
        multiText.text = "Multiplier: x" + playerController.CurrentMultiplier;
        if (!startPlaying)
        {
            // Start the level.
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                noteController.HasStarted = true;
                enemyController.HasStarted = true;
                // music.Play();
                FindObjectOfType<SoundManager>().PlayMusicTrack(trackTitle);
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
                starsText.text = playerController.NumStars.ToString();

                // Show percentage as a float to 1 decimal place.
                percentAccuracyText.text = percentAccuracy.ToString("F1") + "%";
                float finalScore = currentScore + (10000 * playerController.NumStars);
                finalScoreText.text = finalScore.ToString();
            }
        }
    }

    public void NoteHit()
    {
        // Update the player's attack/defense multiplier.
        if (playerController.CurrentMultiplierIndex - 1 < playerController.MultiplierThresholds.Length)
        {
            playerController.MultiplierTracker++;
            if (playerController.MultiplierTracker >= playerController.MultiplierThresholds[playerController.CurrentMultiplierIndex - 1])
            {
                playerController.MultiplierTracker = 0;
                playerController.CurrentMultiplierIndex++;
                playerController.CurrentMultiplier += 0.25f;
            }
        }
        // Update the score multiplier.
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierTracker >= multiplierThresholds[currentMultiplier - 1])
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        numNotes++;
        percentAccuracy = (((okHits * 0.5f) + (goodHits * 0.8f) + perfectHits) / numNotes) * 100f;
        Debug.Log(percentAccuracy);
        scoreMultiText.text = "Score Multiplier: x" + currentMultiplier;
        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        accuracyText.text = percentAccuracy.ToString("F1") + "%";
        
    }

    public void OkHit()
    {
        currentScore += scorePerNote + currentScore;
        okHits++;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote + currentScore;
        goodHits++;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote + currentScore;
        perfectHits++;
        NoteHit();
    }
    public void NoteMissed()
    {
        // Reset multipliers if a note is missed.
        playerController.CurrentMultiplierIndex = 1;
        playerController.CurrentMultiplier = 1;
        playerController.MultiplierTracker = 0;
        currentMultiplier = 1;
        multiplierTracker = 0;
        scoreMultiText.text = "Score Multiplier: x" + currentMultiplier;
        missedHits++;
        numNotes++;
        percentAccuracy = (((okHits * 0.5f) + (goodHits * 0.8f) + perfectHits) / numNotes) * 100f;
        accuracyText.text = percentAccuracy.ToString("F1") + "%";
    }
}
