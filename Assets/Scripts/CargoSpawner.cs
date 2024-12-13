using UnityEngine;

public class CargoSpawner : MonoBehaviour
{
    public CargoSO[] availableCargos; // Tüm kargo türleri
    public Transform[] spawnPoint; // Spawn yeri

    [SerializeField] private int CargoSpawnNum=1;

    void Start()
    {
        SpawnRandomCargo();
    }

    public void SpawnRandomCargo()
    {
        for(int i = 0; i<CargoSpawnNum;i++)
        {
            // Rastgele bir kargo seç
        int randomIndex = Random.Range(0, availableCargos.Length);
        CargoSO selectedCargo = availableCargos[randomIndex];
       
        

        // Prefab'i sahnede oluştur
        GameObject spawnedCargo = Instantiate(selectedCargo.cargoPrefab, spawnPoint[i].position, Quaternion.identity);
        spawnedCargo.name = selectedCargo.cargoName; // Kargo adını objeye ver

        Debug.Log(selectedCargo.name + "" + selectedCargo.cargoType + "" + selectedCargo.deliveryDeadline + "" );


        }
        
    }
}
