using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class Timer : MonoBehaviour
{
    public TMP_Text uiText; 
    

    private float elapsedTime = 0f; 
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
        int minutes = Mathf.FloorToInt(time / 60f);
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
