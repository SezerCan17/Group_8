using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoControlManager : MonoBehaviour
{
    public CustomerSatisfaction customerSatisfaction;
    public void CargoCheck(Package cargo)
    {
        switch (cargo.cargoSO.cargoType)
        {
            case CargoType.Clothing:
                Debug.Log("Kargo türü: Giyim");
                if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=50)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(10);

                }
                else
                {
                    customerSatisfaction.CalculateSatisfactionMinus(15);

                }
                break;

            case CargoType.Electronics:
                Debug.Log("Kargo türü: Elektronik");
                 if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=0)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(23);

                }
                
                break;

            case CargoType.Food:
                Debug.Log("Kargo türü: Yiyecek");
                 if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=50)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(8);

                }
                else
                {
                    customerSatisfaction.CalculateSatisfactionMinus(12);

                }
                break;

            case CargoType.Furniture:
                Debug.Log("Kargo türü: Mobilya");
                 if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=62)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(9);

                }
                else
                {
                    customerSatisfaction.CalculateSatisfactionMinus(13);

                }
                break;

            case CargoType.Documents:
                Debug.Log("Kargo türü: Belgeler");
                if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(8);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);

                }
                else if(cargo.cargoSO.durability<70 && cargo.cargoSO.durability>=40)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(8);

                }
                else
                {
                    customerSatisfaction.CalculateSatisfactionMinus(19);

                }break;

            case CargoType.Industrial:
                Debug.Log("Kargo türü: Endüstriyel");
                 if(cargo.cargoSO.durability==100)
                {
                    customerSatisfaction.CalculateSatisfactionPlus(13);
                }
                else if(cargo.cargoSO.durability<100 && cargo.cargoSO.durability >=80)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(5);

                }
                else if(cargo.cargoSO.durability<80 && cargo.cargoSO.durability>=65)
                {
                    customerSatisfaction.CalculateSatisfactionMinus(11);

                }
                else
                {
                    customerSatisfaction.CalculateSatisfactionMinus(17);

                }
                break;

            default:
                Debug.LogWarning("Tanımsız bir kargo türü!");
                break;
        }
    }
}
