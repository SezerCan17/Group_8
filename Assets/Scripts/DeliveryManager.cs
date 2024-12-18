using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public CargoSpawner cargoSpawner;
    public Mailboxs mailboxs;
    public LocationSO locationSO;
    LocationType locationType;
    public float distanceThreshold = 0.5f;

    /// <summary>
    /// ScriptableObject'teki listeyi sözlüğe dönüştürür.
    /// </summary>

    public bool ControlDelivery(GameObject cargo, GameObject mailbox)
{
       Package cargoPackage = cargo.gameObject.GetComponent<Package>();
    // LocationSO null mu kontrol et
    if (locationSO != null)
    {
        LocationType locationType = cargoPackage.cargoSO.locationType;
        // predefinedCoordinates'dan locationType'a karşılık gelen hedef pozisyonu al
        if (locationSO.predefinedCoordinates.TryGetValue(locationType, out Vector3 targetPosition))
        {
            // Hedef pozisyonu ve cargo pozisyonunu yazdır
            Debug.Log($"mailbox position: {mailbox}, Target position: {targetPosition}");
            
            // Mesafeyi kontrol et
            float distance = Vector3.Distance(mailbox.transform.position, targetPosition);
            Debug.Log($"Distance: {distance}, mailbox Position: {cargo}");

            // Mesafe eşik değerine göre doğru teslimat kontrolü
            if (distance <= distanceThreshold)
            {
                Debug.Log("Doğru teslimat adresi!");
                return true;
            }
        }
        else
        {
            Debug.LogWarning("Posta kutusunun konumu sözlükte tanımlanmamış!");
        }
    }
    else
    {
        Debug.LogWarning("LocationSO null, geçerli bir LocationSO atanmalı!");
    }

    Debug.Log("Yanlış teslimat adresi!");
    return false;
}

}
