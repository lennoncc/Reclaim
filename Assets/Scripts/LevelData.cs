using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public GameObject[] arrowType;
    public float[] arrowPressTime;

    public static LevelData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<LevelData>(jsonString);
    }
}
