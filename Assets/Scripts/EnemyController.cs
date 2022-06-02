using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float minDamage = 2;
    private float maxDamage = 3;
    private float attackMultiplier = 1;
    private float[] attackTimes = {10f, 18.5f ,31f, 40f, 64f, 95f}; /* temp */
    private float nextAttackTime;
    private float timeSinceStart;
    private int i;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private GameObject scrollingText;
    private Vector3 textPosition;
    private bool attacksFinished;
    private bool hasStarted;

    public bool HasStarted
    {
        get => hasStarted;
        set => hasStarted = value;
    }

    void Start()
    {
        timeSinceStart = 0;
        i = 0;
        nextAttackTime = attackTimes[i];
        textPosition = new Vector3(2.5f, 5f, 0f);
        attacksFinished = false;
        playerController.PlayerHealthBarController.Capacity = 100f;
        playerController.PlayerHealthBarController.ChangeValueX(1f);
    }

    private void ShowScrollingText(string message)
    {
        var scrollingText = Instantiate(this.scrollingText, textPosition, Quaternion.identity);
        scrollingText.GetComponent<TextMesh>().text = message;
    }

    // Attack the player.
    private void Attack() {
        // TODO: Add enemy attack animation
        float damage = Mathf.Round(DamageEngine.GetDamage(minDamage, maxDamage, attackMultiplier));
        // Reduce damage if player is defending.
        if (!playerController.Attacking)
        {
            // TODO: Add player defence animation.
            damage = Mathf.Round(damage * (1/playerController.CurrentMultiplier));
        }
        ShowScrollingText(damage.ToString());
        float ratio = (playerController.PlayerHealthBarController.CurrentValue - damage) / playerController.PlayerHealthBarController.Capacity;
        if (ratio < 0f)
        {
            ratio = 0f;
        }
        playerController.PlayerHealthBarController.ChangeValueX(ratio);
    }

    void Update()
    {
        if (hasStarted) {
            if (attacksFinished == false) {
                // Time for next attack.
                if (timeSinceStart >= nextAttackTime)
                {
                    Attack();
                    // Get the next attack time if there is one.
                    if (i + 1 < attackTimes.Length)
                    {
                        i++;
                        nextAttackTime = attackTimes[i];
                    }
                    else
                    {
                        attacksFinished = true;
                    }
                }
                timeSinceStart += Time.deltaTime;
            }
        }
    }
}
