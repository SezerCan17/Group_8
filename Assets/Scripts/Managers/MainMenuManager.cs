using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Get the build index of the current scene and increment it to get the next scene
        int nextSceneIndex = currentScene.buildIndex + 1;

        // Check if the next scene index is within the valid range
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene found in the build settings.");
        }
    }


    public void ExitGame()
    {
        // Exits the application
        Application.Quit();

        // For editor testing, stop playing the scene in the Unity editor
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
