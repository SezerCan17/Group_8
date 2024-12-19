using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoControlManager : MonoBehaviour
{
    public CustomerSatisfaction customerSatisfaction;
    public CoinManager coinManager;
    public bool onTime;

    public CargoLocationControlManager cargoLocationControlManager;
    public void CargoCheck(Package cargo, float time)
    {
        switch (cargo.cargoSO.cargoType)
        {
            case CargoType.Clothing:
                Debug.Log("Kargo türü: Giyim");
                if(cargo.cargoSO.durability==100)
                {
                    
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                    coinManager.CoinCalculatePlus(100);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    
                    customerSatisfaction.CalculateSatisfactionMinus(5);
                    coinManager.CoinCalculatePlus(100);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=50)
                {
                    
                    customerSatisfaction.CalculateSatisfactionMinus(10);
                    coinManager.CoinCalculatePlus(100);

                }
                else
                {
                   
                    customerSatisfaction.CalculateSatisfactionMinus(15);
                    coinManager.CoinCalculatePlus(100);

                }

                if((int)time <= cargo.cargoSO.deliveryDeadline)
                {
                    onTime = true;
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                    

                }
                else{
                    onTime = false;
                    customerSatisfaction.CalculateSatisfactionMinus(10);
                    cargoLocationControlManager.HandleLocation(cargo.cargoSO.locationType,onTime);
                }
                break;

            case CargoType.Electronics:
                Debug.Log("Kargo türü: Elektronik");
                 if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                    coinManager.CoinCalculatePlus(100);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);
                    coinManager.CoinCalculatePlus(100);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=0)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(23);
                    coinManager.CoinCalculatePlus(100);

                }
                 if((int)time <= cargo.cargoSO.deliveryDeadline)
                {
                    onTime = true;
                    customerSatisfaction.CalculateSatisfactionPlus(13);
                    
                    

                }
                else{
                    onTime = false;
                    customerSatisfaction.CalculateSatisfactionMinus(35);
                    cargoLocationControlManager.HandleLocation(cargo.cargoSO.locationType,onTime);
                    

                }
                
                break;

            case CargoType.Food:
                Debug.Log("Kargo türü: Yiyecek");
                 if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                    coinManager.CoinCalculatePlus(100);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);
                    coinManager.CoinCalculatePlus(100);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=50)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(8);
                    coinManager.CoinCalculatePlus(100);

                }
                else
                {
                    customerSatisfaction.CalculateSatisfactionMinus(12);
                    coinManager.CoinCalculatePlus(100);

                }
                 if((int)time <= cargo.cargoSO.deliveryDeadline)
                {
                    onTime = true;
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                    

                }
                else{
                    onTime = false;
                    customerSatisfaction.CalculateSatisfactionMinus(10);
                    cargoLocationControlManager.HandleLocation(cargo.cargoSO.locationType,onTime);
                    

                }
                break;

            case CargoType.Furniture:
                Debug.Log("Kargo türü: Mobilya");
                 if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                    coinManager.CoinCalculatePlus(100);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);
                    coinManager.CoinCalculatePlus(100);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=62)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(9);
                    coinManager.CoinCalculatePlus(100);

                }
                else
                {
                    customerSatisfaction.CalculateSatisfactionMinus(13);
                    coinManager.CoinCalculatePlus(100);

                }
                 if((int)time <= cargo.cargoSO.deliveryDeadline)
                {
                    onTime = true;
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                    

                }
                else{
                    onTime = false;
                    customerSatisfaction.CalculateSatisfactionMinus(10);
                    cargoLocationControlManager.HandleLocation(cargo.cargoSO.locationType,onTime);
                    

                }
                break;

            case CargoType.Documents:
                Debug.Log("Kargo türü: Belgeler");
                if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                    coinManager.CoinCalculatePlus(100);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);
                    coinManager.CoinCalculatePlus(100);

                }
                else if(cargo.cargoSO.durability<70 && cargo.cargoSO.durability>=40)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(8);
                    coinManager.CoinCalculatePlus(100);

                }
                else
                {
                    customerSatisfaction.CalculateSatisfactionMinus(19);
                    coinManager.CoinCalculatePlus(100);

                }
                 if((int)time <= cargo.cargoSO.deliveryDeadline)
                {
                    onTime = true;
                    customerSatisfaction.CalculateSatisfactionPlus(8);

                }
                else{
                    onTime = false;
                    customerSatisfaction.CalculateSatisfactionMinus(10);
                    cargoLocationControlManager.HandleLocation(cargo.cargoSO.locationType,onTime);

                }break;

            case CargoType.Industrial:
                Debug.Log("Kargo türü: Endüstriyel");
                 if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(13);
                    coinManager.CoinCalculatePlus(100);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);
                    coinManager.CoinCalculatePlus(100);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=65)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(11);
                    coinManager.CoinCalculatePlus(100);

                }
                else
                {
                    customerSatisfaction.CalculateSatisfactionMinus(17);
                    coinManager.CoinCalculatePlus(100);

                }
                 if((int)time <= cargo.cargoSO.deliveryDeadline)
                {
                    onTime = true;
                    customerSatisfaction.CalculateSatisfactionPlus(8);

                }
                else{
                    onTime = false;
                    customerSatisfaction.CalculateSatisfactionMinus(28);
                    cargoLocationControlManager.HandleLocation(cargo.cargoSO.locationType,onTime);

                }
                break;

            default:
                Debug.LogWarning("Tanımsız bir kargo türü!");
                break;
        }
    }

    
}
