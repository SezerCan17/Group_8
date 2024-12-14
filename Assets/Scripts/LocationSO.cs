using System.Collections.Generic;
using UnityEngine;

public enum LocationType
{
    TrainStation,
    PowerPlant,
    Apartments,
    LemonadeShop,
    IndustrialBuildings,
    TennisCourt,
    Church,
    Warehouse,
    Museum,
    SausageStand,
    GasStation,
    CoffeeShop,
    Bank,
    IceCreamShop,
    Hotel,
    Pizzeria,
    BurgerShop,
    FireStation,
    Hospital,
    ParkingLot,
    PoliceStation
}

[CreateAssetMenu(fileName = "NewLocation", menuName = "Location")]
public class LocationSO : ScriptableObject
{
    public LocationType locationName;
    public Vector3 coordinates;

    private static readonly Dictionary<LocationType, Vector3> predefinedCoordinates = new Dictionary<LocationType, Vector3>
    {
        { LocationType.TrainStation, new Vector3(0, 0, 0) },
        { LocationType.PowerPlant, new Vector3(-20, 0, 30) },
        { LocationType.Apartments, new Vector3(5, 0, 10) },
        { LocationType.LemonadeShop, new Vector3(12, 0, -8) },
        { LocationType.IndustrialBuildings, new Vector3(-18, 0, 25) },
        { LocationType.TennisCourt, new Vector3(20, 0, -12) },
        { LocationType.Church, new Vector3(-5, 0, -10) },
        { LocationType.Warehouse, new Vector3(0, 0, 0) },
        { LocationType.Museum, new Vector3(25, 0, 18) },
        { LocationType.SausageStand, new Vector3(15, 0, 5) },
        { LocationType.GasStation, new Vector3(-10, 0, -5) },
        { LocationType.CoffeeShop, new Vector3(8, 0, 3) },
        { LocationType.Bank, new Vector3(30, 0, -20) },
        { LocationType.IceCreamShop, new Vector3(-15, 0, -25) },
        { LocationType.Hotel, new Vector3(22, 0, 15) },
        { LocationType.Pizzeria, new Vector3(-8, 0, 12) },
        { LocationType.BurgerShop, new Vector3(14, 0, 7) },
        { LocationType.FireStation, new Vector3(0, 0, -10) },
        { LocationType.Hospital, new Vector3(-12, 0, 20) },
        { LocationType.ParkingLot, new Vector3(6, 0, -18) },
        { LocationType.PoliceStation, new Vector3(-20, 0, -22) }
    };

    private void OnValidate()
    {
        // Eğer sözlükte tanımlı bir koordinat varsa otomatik olarak ata
        if (predefinedCoordinates.TryGetValue(locationName, out Vector3 newCoordinates))
        {
            coordinates = newCoordinates;
        }
        else
        {
            Debug.LogWarning($"Coordinates for {locationName} are not defined!");
        }

        
    }
}


