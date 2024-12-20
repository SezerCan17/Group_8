using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int day=1;

    public UIManager uIManager;
    public CoinManager coinManager;
    public CargoSpawner cargoSpawner;
    public EconomyController economyController;
    public CustomerSatisfaction customerSatisfaction;
    public SecurityandHealthManager securityandHealthManager;

    public GameObject car1;
    public GameObject car2;
    public GameObject navigation;

    void Awake()
    {
        Waiting();
    }

    private void Start()
    {
        SoundManager.PlayGameTheme(GameAssets.SoundType.theme);
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

    public void GameOver()
    {
        Debug.Log("Game Over");
        uIManager.GameOver();
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
        CargoSpawnNum();
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

    public void GameOverMenuQuitButton()
    {
        coinManager.coin = 0;
        economyController.economy = 100;
        customerSatisfaction.satisfaction = 100;
        customerSatisfaction.govermentSatisfaction = 100;
        securityandHealthManager.securityandhealth = 100;
        uIManager.CoinUIText(coinManager.coin);
        Restart();
        uIManager.gameOverPanel.SetActive(false);
        
    }




    


}
