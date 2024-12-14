using UnityEngine;

public class RandomCargoGenerator : MonoBehaviour
{
    public LocationSO[] locations; // Mevcut tüm lokasyonlar
    public string[] cargoNames = { "Laptop", "Pizza", "Jeans", "Chair", "Passport" }; // Rastgele isimler
    public float minWeight = 1f;
    public float maxWeight = 50f;
    public float minDeliveryTime = 30f; // Minimum teslimat süresi (saniye)
    public float maxDeliveryTime = 300f; // Maksimum teslimat süresi (saniye)

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
