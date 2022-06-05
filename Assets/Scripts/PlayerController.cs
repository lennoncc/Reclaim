using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private bool attacking;
    [SerializeField]
    private GameObject attackBar;
    private float currentMultiplier;
    private int currentMultiplierIndex;
    private int multiplierTracker;
    [SerializeField]
    private int[] multiplierThresholds;
    [SerializeField]
    private BarController gaugeController;
    private float minDamage = 10f;
    private float maxDamage = 25f;
    [SerializeField]
    private BarController thresholdController;
    [SerializeField]
    private GameObject attackScrollingText;
    [SerializeField]
    private GameObject healScrollingText;
    private Vector3 attackTextPosition;
    private Vector3 healTextPosition;
    [SerializeField]
    private GameObject star1;
    [SerializeField]
    private GameObject star2;
    [SerializeField]
    private GameObject star3;
    [SerializeField]
    private BarController playerHealthBarController;
    [SerializeField]
    private int numStars;
    
    public float CurrentMultiplier
    {
        get => currentMultiplier;
        set => currentMultiplier = value;
    }

    public int CurrentMultiplierIndex
    {
        get => currentMultiplierIndex;
        set => currentMultiplierIndex = value;
    }
    
    public int MultiplierTracker
    {
        get => multiplierTracker;
        set => multiplierTracker = value;
    }

    public int[] MultiplierThresholds
    {
        get => multiplierThresholds;
        set => multiplierThresholds = value;
    }

    public int NumStars
    {
        get => numStars;
        set => numStars = value;
    }
    
    public BarController PlayerHealthBarController
    {
        get => playerHealthBarController;
        set => playerHealthBarController = value;
    }

    public bool Attacking
    {
        get => attacking;
        set => attacking = value;
    }

    void Start()
    {
        attackTextPosition = new Vector3(6.8f, 5f, 0f);
        healTextPosition = new Vector3(1.5f, 5f, 0f);
        attacking = true;
        attackBar.SetActive(true);
        currentMultiplier = 1f;
        currentMultiplierIndex = 1;
        multiplierTracker = 0;
        gaugeController.Capacity = 100f;
        gaugeController.ChangeValueY(0f);
        thresholdController.Capacity = 100f;
        thresholdController.ChangeValueX(1f);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        numStars = 0;
        GameObject.Find("Camber").GetComponent<Animator>().SetBool("IsCharging", true);
    }

    private void ShowScrollingText(string message, Vector3 textPosition, GameObject inScrollingText)
    {
        var scrollingText = Instantiate(inScrollingText, textPosition, Quaternion.identity);
        scrollingText.GetComponent<TextMesh>().text = message;
    }

    // Increase the attack gauge depending on the accuracy of note hits.
    public void NoteHit(float gaugeIncrease) 
    {
        float ratio = (gaugeController.CurrentValue + gaugeIncrease) / gaugeController.Capacity;
        if (ratio > 1f)
        {
            ratio = 1f;
        }
        gaugeController.ChangeValueY(ratio);
        FindObjectOfType<SoundManager>().PlaySoundEffect("Click1");
    }

    public void Heal()
    {
        // TODO: Add player heal animation
        GameObject.Find("Camber").GetComponent<Animator>().SetBool("IsHealing", true);

        float health = 5f * currentMultiplier;
        ShowScrollingText(health.ToString(), healTextPosition, healScrollingText);
        float ratio = (playerHealthBarController.CurrentValue + health) / playerHealthBarController.Capacity;
        if (ratio > 1f)
        {
            ratio = 1f;
        }
        playerHealthBarController.ChangeValueX(ratio);
    }

    public void Attack()
    {
        // TODO: Add player attack animation
        GameObject.Find("Camber").GetComponent<Animator>().SetBool("IsShooting", true);
        GameObject.Find("Camber").GetComponent<Animator>().SetBool("HasShield", false);

        Debug.Log("attacking");
        float damage = Mathf.Round(DamageEngine.GetDamage(minDamage, maxDamage, currentMultiplier));
        ShowScrollingText(damage.ToString(), attackTextPosition, attackScrollingText);
        float ratio = (thresholdController.CurrentValue - damage) / thresholdController.Capacity;
        if (ratio < 0f)
        {
            ratio = 0f;
        }
        thresholdController.ChangeValueX(ratio);
        EarnStars();
    }

    private void EarnStars()
    {
        if (thresholdController.CurrentValue <= 0)
        {
            numStars = 3;
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (thresholdController.CurrentValue <= 40)
        {
            numStars = 2;
            star1.SetActive(true);
            star2.SetActive(true);
        } 
        else if (thresholdController.CurrentValue <= 75)
        {
            numStars = 1;
            star1.SetActive(true);
        }
    }

    void Update()
    {
        // End the level if the player dies.
        if (playerHealthBarController.CurrentValue == 0f)
        {
            // TODO: death animation, end the level, level failed pop up screen
            GameObject.Find("Camber").GetComponent<Animator>().SetBool("IsDead", true);

        }
        // Toggle between attack and defense mode.
        if (Input.GetButtonDown("Jump"))
        {
            // Attacking
            if (attacking == false)
            {
                GameObject.Find("Camber").GetComponent<Animator>().SetBool("HasShield", false);
                attacking = true;
                attackBar.SetActive(true);
            }
            // Defend
            else 
            {
                attacking = false;
                attackBar.SetActive(false);
                GameObject.Find("Camber").GetComponent<Animator>().SetBool("HasShield", true);
            }
            gaugeController.ChangeValueY(0f);
            currentMultiplierIndex = 1;
            currentMultiplier = 1;
            multiplierTracker = 0;
        }
        // Attack/Defend if gauge is full.
        if (gaugeController.CurrentValue == 100f)
        {
            if (attacking)
            {
                GameObject.Find("Camber").GetComponent<Animator>().SetBool("IsCharging", false);
                Attack();
                gaugeController.ChangeValueY(0f);
            }
            else 
            {
                if (playerHealthBarController.CurrentValue != 100f)
                {
                    Heal();
                    gaugeController.ChangeValueY(0f);
                }
            }
        }
        if (gaugeController.CurrentValue > 0f)
        {
            if(attacking)
            {
                GameObject.Find("Camber").GetComponent<Animator>().SetBool("IsCharging", true);
            }
            else 
            {
                GameObject.Find("Camber").GetComponent<Animator>().SetBool("IsHealing", false);
            }
        }
    }
}
