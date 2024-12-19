using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    public UIManager uIManager;
    public int economy=100;
    public void EconomyCalculatePlus(int n)
    {
        economy += n;

        if(economy > 100)
        {
            economy = 100;
        }
        uIManager.EconomyBar(economy);
    }

    public void EconomyCalculateMinus(int n)
    {
        economy -= n;
        uIManager.EconomyBar(economy);
    }
}
