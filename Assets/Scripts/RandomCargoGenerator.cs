using UnityEngine;

public class RandomCargoGenerator : MonoBehaviour
{
    public LocationSO[] locations; 
    public string[] cargoNames = { "Laptop", "Pizza", "Jeans", "Chair", "Passport" }; 
    public float minWeight = 1f;
    public float maxWeight = 50f;
    public int minDeliveryTime = 30; 
    public int maxDeliveryTime = 300; 

    public CargoSO GenerateRandomCargo()
    {
        CargoSO cargo = ScriptableObject.CreateInstance<CargoSO>();
        cargo.cargoName = cargoNames[Random.Range(0, cargoNames.Length)];
        cargo.cargoType = (CargoType)Random.Range(0, System.Enum.GetValues(typeof(CargoType)).Length);
        cargo.weight = Random.Range(minWeight, maxWeight);
        //cargo.destination = locations[Random.Range(0, locations.Length)];
        cargo.deliveryDeadline = Random.Range(minDeliveryTime, maxDeliveryTime);

        return cargo;
    }
}
