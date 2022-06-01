using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    // Quits game.
    public void QuitGame()
    {
        Debug.Log("Game Quit.");
        Application.Quit();
    }
}
