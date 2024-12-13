using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public LocationSO[] locations;  // Birden fazla LocationSO referansı tutacak dizi

    private void Start()
    {
        // Tüm konumlar için koordinatları ayarla
        foreach (var location in locations)
        {
           
            Debug.Log(location.locationName + " Koordinatları: " + location.coordinates);
        }
    }
}
