using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    private Dictionary<CargoSO, float> deliveryTimes = new Dictionary<CargoSO, float>();

    public void AddCargo(CargoSO cargo)
    {
        deliveryTimes[cargo] = cargo.deliveryDeadline;
    }

    private void Update()
    {
        List<CargoSO> completedCargos = new List<CargoSO>();

        foreach (var cargo in deliveryTimes)
        {
            deliveryTimes[cargo.Key] -= Time.deltaTime;
            if (deliveryTimes[cargo.Key] <= 0)
            {
                Debug.LogWarning($"{cargo.Key.cargoName} teslim süresi doldu!");
                completedCargos.Add(cargo.Key);
            }
        }

        foreach (var cargo in completedCargos)
        {
            deliveryTimes.Remove(cargo);
        }
    }
}
