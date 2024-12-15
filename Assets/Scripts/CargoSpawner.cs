using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CargoSpawner : MonoBehaviour
{
    public CargoSO[] availableCargos; // Tüm kargo türleri
    public Transform[] spawnPoint;   // Spawn yerleri

    public GameObject sfx;          

    public LocationSO locationSO;   // Adres bilgileri için LocationSO

    [SerializeField] private int cargoSpawnNum = 1; // Spawn edilecek kargo sayısı

    public List<Vector3> spawnedPoints;

    void Start()
    {
        SpawnRandomCargo();
    }

    public void SpawnRandomCargo()
    {
        for (int i = 0; i < cargoSpawnNum; i++)
        {
            // Rastgele bir kargo seç
            int randomIndex = Random.Range(0, availableCargos.Length);
            CargoSO selectedCargo = availableCargos[randomIndex];
            Debug.Log("Buuuuuu:" +selectedCargo);

            // Kargo prefab'ını sahnede oluştur
            GameObject spawnedCargo = Instantiate(selectedCargo.cargoPrefab, spawnPoint[i].position, Quaternion.identity);
            spawnedCargo.name = selectedCargo.cargoName;

            
            Package packageScript = spawnedCargo.GetComponent<Package>();
            if (packageScript != null)
            {
                packageScript.cargoSO = selectedCargo;
            }

            
            Debug.Log("Spawned Cargo: " + selectedCargo.name + ", Type: " + selectedCargo.cargoType + ", Delivery Deadline: " + selectedCargo.deliveryDeadline + ", Position: " + selectedCargo.locationType);

            
            if (locationSO.predefinedCoordinates.TryGetValue(selectedCargo.locationType, out Vector3 targetPosition))
            {
                Debug.Log("Adressss: " + targetPosition);
                
                GameObject sfxMailBox = Instantiate(sfx, new Vector3(targetPosition.x+13.7f, targetPosition.y+11.5f, targetPosition.z+28.15f), Quaternion.identity);
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
