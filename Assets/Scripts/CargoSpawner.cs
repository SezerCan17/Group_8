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
            // Rastgele bir kargo seç
            int randomIndex = Random.Range(0, availableCargos.Length);
            CargoSO selectedCargo = availableCargos[randomIndex];
            Debug.Log("Buuuuuu:" + selectedCargo);

            // Kargo prefab'ını sahnede oluştur
            GameObject spawnedCargo = Instantiate(selectedCargo.cargoPrefab, spawnPoint[i].position, Quaternion.identity);
            spawnedCargo.name = selectedCargo.cargoName;
            cargoList.Add(spawnedCargo);

            // Rastgele deliveryDeadline, cargoType, weight atama
            selectedCargo.deliveryDeadline = Random.Range(1, 10); // Örneğin 1-10 arası teslimat süresi
            selectedCargo.cargoType = (CargoType)Random.Range(0, System.Enum.GetValues(typeof(CargoType)).Length); // CargoType enum'undan rastgele seçim
            selectedCargo.weight = Random.Range(1f, 50f); // Örneğin 1kg ile 50kg arasında rastgele ağırlık

            // Debug ile rastgele atanan değerleri yazdır
            Debug.Log($"Random Cargo Info: {selectedCargo.name} - Type: {selectedCargo.cargoType} - Weight: {selectedCargo.weight}kg - Deadline: {selectedCargo.deliveryDeadline} days");

            // Package bileşenine kargo SO'yu atama
            Package packageScript = spawnedCargo.GetComponent<Package>();
            if (packageScript != null)
            {
                packageScript.cargoSO = selectedCargo;
            }

            // Hedef pozisyonu belirleme
            if (locationSO.predefinedCoordinates.TryGetValue(selectedCargo.locationType, out Vector3 targetPosition))
            {
                Debug.Log("Adres: " + targetPosition);
                
                // Adrese bağlı SFX oluşturma
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
