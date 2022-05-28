using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float minDamage = 20;
    private float maxDamage = 50;
    private float attackMultplier = 1;
    private float[] attackTimes = {3, 6, 9, 12};
    private float nextAttackTime;
    private float timeSinceStart;
    private int i;
    [SerializeField]
    private HealthBarController HealthBarController;
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
    }

    private void ShowScrollingText(string message)
    {
        var scrollingText = Instantiate(this.scrollingText, textPosition, Quaternion.identity);
        scrollingText.GetComponent<TextMesh>().text = message;
    }

    private void Attack() {
        float damage = Mathf.Round(DamageEngine.GetDamage(minDamage, maxDamage, attackMultplier));
        ShowScrollingText(damage.ToString());
        float ratio = (HealthBarController.CurrentValue - damage) / HealthBarController.Capacity;
        if (ratio < 0f)
        {
            ratio = 0f;
        }
        HealthBarController.ChangeValue(ratio);
    }

    void Update()
    {
        if (hasStarted) {
            if (attacksFinished == false) {
                if (timeSinceStart >= nextAttackTime)
                {
                    Attack();
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
