using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private GameObject valueSurface;
    private float capacity;
    private float currentValue;
 
    public float Capacity
    {
        get => capacity;
        set => capacity = value;
    }

    public float CurrentValue
    {
        get => currentValue;
        set => currentValue = value;
    }

    void Start()
    {
        capacity = 100f;
        currentValue = 100f;
    }

    public void ChangeValue(float ratio)
    {
        SetLocalScaleX(this.valueSurface, ratio);
        currentValue = capacity * ratio;
    }
    
    void Update()
    {

    }

    static private void SetLocalScaleX(GameObject go, float value)
    {
        var localScale = go.transform.localScale;
        localScale.x = value;
        go.transform.localScale = localScale;        
    }
}