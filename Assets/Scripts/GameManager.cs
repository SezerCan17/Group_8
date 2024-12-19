using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int day=1;

    public UIManager uIManager;

    void Awake()
    {
        Waiting();
    }


    public void NextDay()
    {
        day++;
    }

    public void Restart()
    {
        day = 1;
    }

    public void EndDay()
    {
        Debug.Log("End of the day");
    }

    public void StartDay()
    {
        Time.timeScale = 1;
        Debug.Log("Start of the day");
    }

    public void Waiting()
    {
        Time.timeScale = 0;
        uIManager.Market();
        Debug.Log("Waiting for the next day");
    }


    public void MarketQuitButton()
    {
        Time.timeScale = 1;
        uIManager.market.SetActive(false);
    }




    


}
