using UnityEngine;

public class CargoSpawner : MonoBehaviour
{
    public CargoSO[] availableCargos; // Tüm kargo türleri
    public Transform[] spawnPoint; // Spawn yerleri

    [SerializeField] private int CargoSpawnNum = 1;

    void Start()
    {
        SpawnRandomCargo();
    }

    public void SpawnRandomCargo()
    {
        for (int i = 0; i < CargoSpawnNum; i++)
        {
            // Rastgele bir kargo seç
            int randomIndex = Random.Range(0, availableCargos.Length);
            CargoSO selectedCargo = availableCargos[randomIndex];

            // Kargo prefab'ını sahnede oluştur
            GameObject spawnedCargo = Instantiate(selectedCargo.cargoPrefab, spawnPoint[i].position, Quaternion.identity);
            spawnedCargo.name = selectedCargo.cargoName;

            // Package script'ini al ve CargoSO'yu atayın
            Package packageScript = spawnedCargo.GetComponent<Package>();
            if (packageScript != null)
            {
                packageScript.cargoSO = selectedCargo;  // Package'a CargoSO'yu ata
            }

            // Log olarak bilgileri yazdır
            Debug.Log("Spawned Cargo: " + selectedCargo.name + ", Type: " + selectedCargo.cargoType + ", Delivery Deadline: " + selectedCargo.deliveryDeadline);
        }
    }
}
