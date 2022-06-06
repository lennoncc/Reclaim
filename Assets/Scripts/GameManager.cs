using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
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
    private float currentScore;
    private int scorePerNote = 50;
    private int scorePerGoodNote = 80;
    private int scorePerPerfectNote = 100;
    private float currentMultiplier;
    private int currentMultiplierIndex;
    private int multiplierTracker;
    [SerializeField]
    private int[] multiplierThresholds;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI scoreMultiText;
    [SerializeField]
    private TextMeshProUGUI multiText;
    [SerializeField]
    private TextMeshProUGUI accuracyText;
    [SerializeField]
    private Text starsText;
    private float numNotes;
    private float missedHits;
    private float okHits;
    private float goodHits;
    private float perfectHits;
    private float percentAccuracy;
    [SerializeField] private GameObject resultsScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject instructions;
    [SerializeField] private Text percentAccuracyText, missedText, okText, goodText, perfectText, finalScoreText;
    private float deathAnimationTimer;
    private bool stopTrack;
    private bool deathTrack;

    public static GameManager Instance
    {
        get => instance;
    }

    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplierIndex = 1;
        currentMultiplier = 1;
        multiplierTracker = 0;
        numNotes = 0;
        multiText.enabled = false;
        deathAnimationTimer = 0;
        stopTrack = false;
        deathTrack =  false;
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
                FindObjectOfType<SoundManager>().PlayMusicTrack(trackTitle);
                music = FindObjectOfType<SoundManager>()._trackPlaying.audioSource;
                instructions.SetActive(false);
                multiText.enabled = true;
            }
        }
        else
        {
            // The player dies.
            if (playerController.PlayerHealthBarController.CurrentValue == 0f)
            {
                if (!stopTrack)
                {
                    music.Stop();
                    stopTrack = true;
                }
                if (!deathTrack)
                {
                    FindObjectOfType<SoundManager>().PlayMusicTrack("Death");
                    music = FindObjectOfType<SoundManager>()._trackPlaying.audioSource;
                    deathTrack = true;
                }
                if (deathAnimationTimer < 7f)
                {
                    deathAnimationTimer += Time.deltaTime;
                }
            }

            // Show the results at the end of the level.
            // If the player died, wait for the death animation to finish before displaying results.
            if ((!music.isPlaying || deathAnimationTimer >= 7f) && !resultsScreen.activeInHierarchy && !gameOverScreen.activeInHierarchy)
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

            // The player lost the level.
            if ((playerController.PlayerHealthBarController.CurrentValue == 0f || playerController.NumStars == 0) && resultsScreen.activeInHierarchy)
            {
                if (Input.anyKeyDown)
                {
                    resultsScreen.SetActive(false);
                    gameOverScreen.SetActive(true);
                }
            }
            // The player beat the level.
            else if (resultsScreen.activeInHierarchy)
            {
                if (Input.anyKeyDown)
                {
                    continueButton.SetActive(true);
                }
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
        if (currentMultiplierIndex - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierTracker >= multiplierThresholds[currentMultiplierIndex - 1])
            {
                multiplierTracker = 0;
                currentMultiplierIndex++;
                currentMultiplier += 0.25f;
            }
        }
        numNotes++;
        percentAccuracy = (((okHits * 0.5f) + (goodHits * 0.8f) + perfectHits) / numNotes) * 100f;
        scoreMultiText.text = "Score Multiplier: x" + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        accuracyText.text = percentAccuracy.ToString("F1") + "%";
        
    }

    public void OkHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        okHits++;
        NoteHit();
        enemyController.Attack(0.5f);

    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        goodHits++;
        NoteHit();
        enemyController.Attack(0.25f);
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        perfectHits++;
        NoteHit();
        enemyController.Attack(0f);
    }
    public void NoteMissed()
    {
        // Reset multipliers if a note is missed.
        playerController.CurrentMultiplierIndex = 1;
        playerController.CurrentMultiplier = 1;
        playerController.MultiplierTracker = 0;
        currentMultiplierIndex = 1;
        currentMultiplier = 1;
        multiplierTracker = 0;
        scoreMultiText.text = "Score Multiplier: x" + currentMultiplier;
        missedHits++;
        numNotes++;
        percentAccuracy = (((okHits * 0.5f) + (goodHits * 0.8f) + perfectHits) / numNotes) * 100f;
        accuracyText.text = percentAccuracy.ToString("F1") + "%";
        enemyController.Attack(1f);
    }
}
