using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    private bool isPaused = false;

    // Toggle the pause state of the game
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // Pause the game
    void PauseGame()
    {
        Time.timeScale = 0; // Stop time
        isPaused = true;
        // Add any additional pause logic here (e.g., show pause menu)
        Debug.Log("Game Paused");
    }

    // Resume the game
    void ResumeGame()
    {
        Time.timeScale = 1; // Resume time
        isPaused = false;
        // Add any additional resume logic here (e.g., hide pause menu)
        Debug.Log("Game Resumed");
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
