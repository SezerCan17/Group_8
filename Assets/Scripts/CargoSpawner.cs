using System.Collections.Generic;
using UnityEngine;

public class CargoSpawner : MonoBehaviour
{
    public CargoSO[] availableCargos; // Tüm kargo türleri
    public Transform[] spawnPoint;    // Spawn yerleri

    public GameObject sfx;          

    public LocationSO locationSO;    // Adres bilgileri için LocationSO

    [SerializeField] private int cargoSpawnNum = 1; // Spawn edilecek kargo sayısı

    public List<Vector3> spawnedPoints;

    public List<GameObject> cargoList;

    void Start()
    {
        SpawnRandomCargo();
    }

    public void CargoSpawnNum(int num)
    {
        cargoSpawnNum = num;
        SpawnRandomCargo();
    }

    public void SpawnRandomCargo()
    {
        for (int i = 0; i < cargoSpawnNum; i++)
        {
            
            int randomIndex = Random.Range(0, availableCargos.Length);
            CargoSO selectedCargo = availableCargos[randomIndex];
            Debug.Log("Buuuuuu:" + selectedCargo);

            
            GameObject spawnedCargo = Instantiate(selectedCargo.cargoPrefab, spawnPoint[i].position, Quaternion.identity);
            spawnedCargo.name = selectedCargo.cargoName;
            cargoList.Add(spawnedCargo);

            
            selectedCargo.deliveryDeadline = Random.Range(10, 18); 
            selectedCargo.cargoType = (CargoType)Random.Range(0, System.Enum.GetValues(typeof(CargoType)).Length); 
            selectedCargo.weight = Random.Range(1f, 50f); 

            
            Debug.Log($"Random Cargo Info: {selectedCargo.name} - Type: {selectedCargo.cargoType} - Weight: {selectedCargo.weight}kg - Deadline: {selectedCargo.deliveryDeadline} days");

            
            Package packageScript = spawnedCargo.GetComponent<Package>();
            if (packageScript != null)
            {
                packageScript.cargoSO = selectedCargo;
            }

            
            if (locationSO.predefinedCoordinates.TryGetValue(selectedCargo.locationType, out Vector3 targetPosition))
            {
                Debug.Log("Adres: " + targetPosition);
                
                
                GameObject sfxMailBox = Instantiate(sfx, targetPosition, Quaternion.identity);
                sfxMailBox.name = "SFX for " + selectedCargo.cargoName;

                spawnedPoints.Add(targetPosition);
            }
            else
            {
                Debug.LogWarning("Adres bulunamadı: " + selectedCargo.locationType);
            }
        }
    }
}
