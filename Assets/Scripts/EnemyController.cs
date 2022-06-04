using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float minDamage = 10;
    private float maxDamage = 11;
    private float[] attackTimes = {10f, 18.5f ,31f, 40f, 64f, 95f}; /* temp */
    private float nextAttackTime;
    private float timeSinceStart;
    private int i;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private GameObject scrollingText;
    private Vector3 textPosition;
    private bool attacking;
    private bool attacksFinished;
    private bool hasStarted;
    public Animator animator;

    public bool HasStarted
    {
        get => hasStarted;
        set => hasStarted = value;
    }

    void Start()
    {
        attacking = false;
        timeSinceStart = 0;
        i = 0;
        nextAttackTime = attackTimes[0];
        textPosition = new Vector3(3.5f, 5f, 0f);
        attacksFinished = false;
        playerController.PlayerHealthBarController.Capacity = 100f;
        playerController.PlayerHealthBarController.ChangeValueX(1f);
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void ShowScrollingText(string message)
    {
        var scrollingText = Instantiate(this.scrollingText, textPosition, Quaternion.identity);
        scrollingText.GetComponent<TextMesh>().text = message;
    }

    // Attack the player.
    public void Attack(float attackMultiplier) {
        if (attacking) {
            // Full damage if player is in attack mode while enemy is attacking.
            if (playerController.Attacking)
            {
                attackMultiplier = 1f;
            }
            // TODO: Add enemy attack animation
            animator.SetBool("IsAttacking", true);

            float damage = Mathf.Round(DamageEngine.GetDamage(minDamage, maxDamage, attackMultiplier));
            ShowScrollingText(damage.ToString());
            float ratio = (playerController.PlayerHealthBarController.CurrentValue - damage) / playerController.PlayerHealthBarController.Capacity;
            if (ratio < 0f)
            {
                ratio = 0f;
            }
            playerController.PlayerHealthBarController.ChangeValueX(ratio);
        }
    }

    void Update()
    {
        if (hasStarted) {
            if (attacksFinished == false) {
                // Time for next attack.
                if (timeSinceStart >= nextAttackTime && attacking == false)
                {
                    attacking = true;
                    animator.SetBool("IsAttacking", true);
                    // Get the next attack time if there is one.
                    if (i + 1 < attackTimes.Length)
                    {
                        i++;
                        nextAttackTime = attackTimes[i];
                    }
                    else
                    {
                        attacksFinished = true;
                        animator.SetBool("IsAttacking", false);
                    }
                } 
                if (timeSinceStart >= nextAttackTime && attacking == true)
                {
                    // TODO: stop enemy attack animation
                    attacking = false;
                    animator.SetBool("IsAttacking", false);
                    // Get the next attack time if there is one.
                    if (i + 1 < attackTimes.Length)
                    {
                        i++;
                        nextAttackTime = attackTimes[i];
                    }
                    else
                    {
                        attacksFinished = true;
                        animator.SetBool("IsAttacking", false);
                    }
                } 
            }
            timeSinceStart += Time.deltaTime;
            animator.SetBool("IsAttacking", false);
        }
    }
}
