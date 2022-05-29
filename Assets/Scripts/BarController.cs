using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
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

    }

    // Update value of a bar through X scale.
    public void ChangeValueX(float ratio)
    {
        SetLocalScaleX(this.valueSurface, ratio);
        currentValue = capacity * ratio;
    }
    
    // Update value of a bar through Y scale.
    public void ChangeValueY(float ratio)
    {
        SetLocalScaleY(this.valueSurface, ratio);
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
    
    static private void SetLocalScaleY(GameObject go, float value)
    {
        var localScale = go.transform.localScale;
        localScale.y = value;
        go.transform.localScale = localScale;        
    }
}