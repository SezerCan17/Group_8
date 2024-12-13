using UnityEngine;

public enum CargoType
{
    Electronics,
    Food,
    Clothing,
    Furniture,
    Documents
}


[CreateAssetMenu(fileName = "NewCargo", menuName = "Cargo")]
public class CargoSO : ScriptableObject
{
    public string cargoName;
    public CargoType cargoType; 
    public float weight;
    public LocationSO destination;
    public float deliveryDeadline; 
     public GameObject cargoPrefab;
}
