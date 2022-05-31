using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    // Makes serialize field textbox bigger. 3 min lines, 10 max lines.
    [TextArea(3,10)]
    public string[] sentences;
}
