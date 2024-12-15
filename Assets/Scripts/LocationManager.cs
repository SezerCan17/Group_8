using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public static Dictionary<LocationType, Vector3> locationPositions = new Dictionary<LocationType, Vector3>();

    void Awake()
    {
        
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
