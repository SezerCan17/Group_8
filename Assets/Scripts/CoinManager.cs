using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public UIManager uIManager;
    public int coin=0;
    public void CoinCalculatePlus(int n)
    {
        coin += n;
        uIManager.CoinUIText(coin);

    }
    public void CoinCalculateMinus(int n)
    {
        coin -= n;

        if(coin <= 0)
        {
            coin=0;
        }
        uIManager.CoinUIText(coin);
    }
}
