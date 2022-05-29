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

    void Start()
    {
        attacking = false;
        attackBar.SetActive(false);
        attackMultiplier = 0f;
    }


    void Update()
    {
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
            attackMultiplier = 0;
        }
        
    }
}
