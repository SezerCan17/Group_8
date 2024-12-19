using System.Collections.Generic;
using UnityEngine;

public class CargoBranch : MonoBehaviour
{
    public RandomCargoGenerator cargoGenerator;
    public int cargoCount = 5; 
    private List<CargoSO> cargoList = new List<CargoSO>();

    private void Start()
    {
        GenerateCargos();
        DisplayCargos();
    }

    private void GenerateCargos()
    {
        for (int i = 0; i < cargoCount; i++)
        {
            cargoList.Add(cargoGenerator.GenerateRandomCargo());
        }
    }

    private void DisplayCargos()
    {
        foreach (var cargo in cargoList)
        {
            Debug.Log($"Kargo: {cargo.cargoName}, Tür: {cargo.cargoType},  Ağırlık: {cargo.weight}, Süre: {cargo.deliveryDeadline}s");
        }
    }
}
