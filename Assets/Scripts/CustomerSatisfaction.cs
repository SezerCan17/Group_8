using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSatisfaction : MonoBehaviour
{

    public UIManager uIManager;
    public int satisfaction = 100;
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


}
