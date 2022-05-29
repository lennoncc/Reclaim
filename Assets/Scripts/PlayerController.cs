using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private bool attacking;
    [SerializeField]
    private GameObject attackBar;
    private float multiplier;
    [SerializeField]
    private int[] multiplierThresholds;
    [SerializeField]
    private BarController gaugeController;
    private float minDamage = 10f;
    private float maxDamage = 25f;
    [SerializeField]
    private BarController thresholdController;
    [SerializeField]
    private GameObject scrollingText;
    private Vector3 textPosition;
    [SerializeField]
    private GameObject star1;
    [SerializeField]
    private GameObject star2;
    [SerializeField]
    private GameObject star3;
    [SerializeField]
    private BarController playerHealthBarController;

    void Start()
    {
        textPosition = new Vector3(6.8f, 5f, 0f);
        attacking = false;
        attackBar.SetActive(false);
        multiplier = 1f;
        gaugeController.Capacity = 100f;
        gaugeController.ChangeValueY(0f);
        thresholdController.Capacity = 100f;
        thresholdController.ChangeValueX(1f);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    private void ShowScrollingText(string message)
    {
        var scrollingText = Instantiate(this.scrollingText, textPosition, Quaternion.identity);
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
        float health = 5f * multiplier;
        ShowScrollingText(health.ToString());
        float ratio = (playerHealthBarController.CurrentValue + health) / playerHealthBarController.Capacity;
        if (ratio > 1f)
        {
            ratio = 1f;
        }
        playerHealthBarController.ChangeValueX(ratio);
    }

    public void Attack()
    {
        float damage = Mathf.Round(DamageEngine.GetDamage(minDamage, maxDamage, multiplier));
        ShowScrollingText(damage.ToString());
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
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (thresholdController.CurrentValue <= 40)
        {
            star1.SetActive(true);
            star2.SetActive(true);

        } 
        else if (thresholdController.CurrentValue <= 75)
        {
            star1.SetActive(true);
        }
    }

    void Update()
    {
        // Toggle between attack and defense mode.
        if (Input.GetButtonDown("Jump"))
        {
            if (attacking == false)
            {
                attacking = true;
                attackBar.SetActive(true);
            }
            else 
            {
                attacking = false;
                attackBar.SetActive(false);
            }
            gaugeController.ChangeValueY(0f);
            multiplier = 1f;
        }
        // Attack/Defend if gauge is full.
        if (gaugeController.CurrentValue == 100f)
        {
            if (attacking)
            {
                Attack();
                gaugeController.ChangeValueY(0f);
            }
            else 
            {
                Heal();
                gaugeController.ChangeValueY(0f);
            }
        }
    }
}
