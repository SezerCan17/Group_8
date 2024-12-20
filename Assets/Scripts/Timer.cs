using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TMP_Text uiText; 
    public int minutes;
    

    public float elapsedTime = 0f; 
    private bool isTimerRunning = true; 

    void Update()
    {
        if (isTimerRunning)
        {
            
            elapsedTime += Time.deltaTime;

            
            uiText.text = FormatTime(elapsedTime);
        }
    }

   
    private string FormatTime(float time)
    {
        minutes = Mathf.FloorToInt(time / 60f)+10;
        int seconds = Mathf.FloorToInt(time % 60f); 
        return string.Format("{0:00}:{1:00}", minutes, seconds); 
    }

    
    public void StartTimer()
    {
        isTimerRunning = true;
    }

   
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    
    public void ResetTimer()
    {
        elapsedTime = 0f;
        uiText.text = FormatTime(elapsedTime);
    }

    
}
