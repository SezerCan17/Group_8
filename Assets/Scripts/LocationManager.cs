using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public static Dictionary<LocationType, Vector3> locationPositions = new Dictionary<LocationType, Vector3>();

    void Awake()
    {
        // Pozisyonları burada tanımlayın
        locationPositions[LocationType.TrainStation] = new Vector3(10, 0, 20);
        locationPositions[LocationType.PowerPlant] = new Vector3(-15, 0, 30);
        locationPositions[LocationType.Apartments] = new Vector3(5, 0, 40);
        locationPositions[LocationType.LemonadeShop] = new Vector3(-25, 0, 10);
        // Diğer pozisyonları ekleyin...
    }

    public static Vector3 GetLocationPosition(LocationType locationType)
    {
        if (locationPositions.TryGetValue(locationType, out Vector3 position))
        {
            return position;
        }

        Debug.LogWarning("Pozisyon bulunamadı: " + locationType);
        return Vector3.zero; // Hata durumunda varsayılan pozisyon döndür
    }
}
