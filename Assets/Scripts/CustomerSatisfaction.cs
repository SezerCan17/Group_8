using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSatisfaction : MonoBehaviour
{

    public UIManager uIManager;
    public int satisfaction = 100;
    public int govermentSatisfaction = 100;
    public GameManager gameManager;


    void Update()
    {
        if(satisfaction<=0)
        {
            gameManager.GameOver();
            Debug.Log("Game Over");
        }
        if(govermentSatisfaction<=0)
        {
            gameManager.GameOver();
            Debug.Log("Game Over");
        }
    }
    public void CalculateSatisfactionPlus(int n)
    {
        satisfaction+=n;
        if(satisfaction >= 100)
        {
            satisfaction=100;
        }
        uIManager.SatisfactionBar(satisfaction);
    }

    public void CalculateSatisfactionMinus(int n)
    {
        satisfaction-=n;
        if(satisfaction<=0)
        {
            satisfaction=0;
        }
        uIManager.SatisfactionBar(satisfaction);
    }

    public void CalculateGovermentSatisfactionMinus(int n)
    {
        govermentSatisfaction-=n;
        if(govermentSatisfaction<=0)
        {
            govermentSatisfaction=0;
        }
        uIManager.GovermentSatisfactionBar(govermentSatisfaction);
    }

    public void CalculateGovermentSatisfactionPlus(int n)
    {
        govermentSatisfaction+=n;
        if(govermentSatisfaction >= 100)
        {
            govermentSatisfaction=100;
        }
        uIManager.GovermentSatisfactionBar(govermentSatisfaction);
    }



}
