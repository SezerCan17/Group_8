using UnityEngine;

public enum CargoType
{
    Electronics,
    Food,
    Clothing,
    Furniture,
    Documents,
    Industrial
}


[CreateAssetMenu(fileName = "NewCargo", menuName = "Cargo")]
public class CargoSO : ScriptableObject
{
    public string cargoName;
    public CargoType cargoType; 
    public float weight;
    public LocationType locationType;
    public int deliveryDeadline; 
     public GameObject cargoPrefab;

     public int durability = 100;
}
