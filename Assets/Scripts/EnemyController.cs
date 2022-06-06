using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float minDamage = 5;
    private float maxDamage = 5;
    private float[] attackTimes = new float[10]; 

    private float nextAttackTime;
    private float timeSinceStart;
    private int i;
    [SerializeField] 
    private string attackFile;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private GameObject scrollingText;
    private Vector3 textPosition;
    private bool attacking;
    private bool attacksFinished;
    private bool hasStarted;
    public Animator animator;
    [SerializeField] private GameObject laser;

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
        Object level = Resources.Load<TextAsset>(attackFile);
        string data = level.ToString();
        string[] lines = data.Split('\n');
        foreach (string line in lines)
        {
            float num = float.Parse(line);
            attackTimes[i] = num;
            i++;
        }
        i = 0;
        nextAttackTime = attackTimes[0];
        textPosition = new Vector3(2f, 2f, 0f);
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
            GameObject.Find("AttackIndicator").GetComponent<SpriteRenderer>().enabled = true;
            laser.GetComponent<SpriteRenderer>().enabled = true;

            float damage = Mathf.Round(DamageEngine.GetDamage(minDamage, maxDamage, attackMultiplier));
            if (damage != 0)
            {
                ShowScrollingText(damage.ToString());
            }
            float ratio = (playerController.PlayerHealthBarController.CurrentValue - damage) / playerController.PlayerHealthBarController.Capacity;
            if (ratio < 0f)
            {
                ratio = 0f;
            }
            GameObject.Find("AttackIndicator").GetComponent<SpriteRenderer>().enabled = true;
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
                        GameObject.Find("AttackIndicator").GetComponent<SpriteRenderer>().enabled = false;
                        laser.GetComponent<SpriteRenderer>().enabled = false;
                    }
                } 
                if (timeSinceStart >= nextAttackTime && attacking == true)
                {
                    // TODO: stop enemy attack animation
                    attacking = false;
                    animator.SetBool("IsAttacking", false);
                    GameObject.Find("AttackIndicator").GetComponent<SpriteRenderer>().enabled = false;
                    laser.GetComponent<SpriteRenderer>().enabled = false;
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
                        GameObject.Find("AttackIndicator").GetComponent<SpriteRenderer>().enabled = false;
                        laser.GetComponent<SpriteRenderer>().enabled = false;
                    }
                } 
            }
            timeSinceStart += Time.deltaTime;
            animator.SetBool("IsAttacking", false);
        }
    }
}
