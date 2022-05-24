using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Switch to playing scene.
    public void PlayGame()
    {
    
    }

    // Quits game.
    public void QuitGame()
    {
        Debug.Log("Game Quit.");
        Application.Quit();
    }
}
