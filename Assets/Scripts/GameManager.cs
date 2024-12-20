using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int day=1;

    public UIManager uIManager;
    public CoinManager coinManager;
    public CargoSpawner cargoSpawner;

    public GameObject car1;
    public GameObject car2;
    public GameObject navigation;

    void Awake()
    {
        Waiting();
    }


    public void NextDay()
    {
        day++;
        uIManager.DayPrint();
    }

    public void Restart()
    {
        day = 1;
    }

    public void EndDay()
    {
        Debug.Log("End of the day");
        NextDay();
        Waiting();
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

    public void CargoSpawnNum()
    {
        int num = day*2;
        cargoSpawner.CargoSpawnNum(num);

    }


    public void MarketQuitButton()
    {
        Time.timeScale = 1;
        uIManager.market.SetActive(false);
    }

    public void car1Button()
    {
        car1.SetActive(true);
        if(coinManager.coin>=5000)
        {
            coinManager.CoinCalculateMinus(5000);

        }
        

    }

    public void car2Button()
    {
        car2.SetActive(true);
        if(coinManager.coin>=10000)
        {
           coinManager.CoinCalculateMinus(10000);
        }
    }

    public void navigationButton()
    {
        
        navigation.SetActive(true);

        if(coinManager.coin>=7500)
        {
            coinManager.CoinCalculateMinus(7500);
        }

    }




    


}
