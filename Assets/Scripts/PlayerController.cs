using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private bool attacking;
    [SerializeField]
    private GameObject attackBar;
    private float attackMultiplier;
    [SerializeField]
    private int[] attackMultiplierThresholds;
    [SerializeField]
    private BarController gaugeController;
    private float minDamage = 10f;
    private float maxDamage = 25f;
    [SerializeField]
    private BarController thresholdController;
    [SerializeField]
    private GameObject scrollingText;
    private Vector3 textPosition;

    void Start()
    {
        textPosition = new Vector3(6.8f, 5f, 0f);
        attacking = false;
        attackBar.SetActive(false);
        attackMultiplier = 1f;
        gaugeController.Capacity = 100f;
        gaugeController.ChangeValueY(0f);
        thresholdController.Capacity = 100f;
        thresholdController.ChangeValueX(1f);
    }

    private void ShowScrollingText(string message)
    {
        var scrollingText = Instantiate(this.scrollingText, textPosition, Quaternion.identity);
        scrollingText.GetComponent<TextMesh>().text = message;
    }

    public void NoteHit(float gaugeIncrease) 
    {
        float ratio = (gaugeController.CurrentValue + gaugeIncrease) / gaugeController.Capacity;
        if (ratio > 1f)
        {
            ratio = 1f;
        }
        gaugeController.ChangeValueY(ratio);
    }

    public void Attack()
    {
        float damage = Mathf.Round(DamageEngine.GetDamage(minDamage, maxDamage, attackMultiplier));
        ShowScrollingText(damage.ToString());
        float ratio = (thresholdController.CurrentValue - damage) / thresholdController.Capacity;
        if (ratio < 0f)
        {
            ratio = 0f;
        }
        thresholdController.ChangeValueX(ratio);
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
            attackMultiplier = 1f;
        }
        // Attack if gauge is full.
        if (gaugeController.CurrentValue == 100f)
        {
            Attack();
            gaugeController.ChangeValueY(0f);
        }
    }
}
