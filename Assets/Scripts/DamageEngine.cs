using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEngine : MonoBehaviour
{
    public static float GetDamage(float minDamage, float maxDamage, float attackMultiplier) {
        return (Random.Range(minDamage, maxDamage) * attackMultiplier);
    }
}
