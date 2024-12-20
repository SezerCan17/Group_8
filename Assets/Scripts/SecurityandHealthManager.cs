using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityandHealthManager : MonoBehaviour
{
    public UIManager uIManager;
    public int securityandhealth = 100;
    public GameManager gameManager;

    void Update()
    {
        if(securityandhealth <= 0)
        {
            gameManager.GameOver();
            Debug.Log("Game Over");
        }
    }
    public void CalculateSecurityandHealthMinus(int n)
    {
        securityandhealth -= n;
        uIManager.SecurityandHealthBar(securityandhealth);  
    }

    public void CalculateSecurityandHealthPlus(int n)
    {
        securityandhealth += n;
        if(securityandhealth >= 100)
        {
            securityandhealth = 100;
        }
        uIManager.SecurityandHealthBar(securityandhealth);
    }
}
