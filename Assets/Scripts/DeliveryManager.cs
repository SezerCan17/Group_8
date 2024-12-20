using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public CargoSpawner cargoSpawner;

    public Timer timer;
    public Mailboxs mailboxs;
    public LocationSO locationSO;
    LocationType locationType;
    public float distanceThreshold = 0.5f;
    public CargoControlManager cargoControlManager;
    public GameManager gameManager;

    

    public bool ControlDelivery(GameObject cargo, GameObject mailbox)
{
       Package cargoPackage = cargo.gameObject.GetComponent<Package>();
    
    if (locationSO != null)
    {
        LocationType locationType = cargoPackage.cargoSO.locationType;
        
        if (locationSO.predefinedCoordinates.TryGetValue(locationType, out Vector3 targetPosition))
        {
           
            Debug.Log($"mailbox position: {mailbox}, Target position: {targetPosition}");
            
            
            float distance = Vector3.Distance(mailbox.transform.position, targetPosition);
            Debug.Log($"Distance: {distance}, mailbox Position: {cargo}");

            
            if (distance <= distanceThreshold)
            {
                Debug.Log("Doğru teslimat adresi!");
                
                cargoControlManager.CargoCheck(cargoPackage,timer.minutes);
                cargoSpawner.cargoList.Remove(cargo);
                Debug.Log("Kalan kargo sayısı: " + cargoSpawner.cargoList.Count);
                
                if(cargoSpawner.cargoList.Count == 0)
                {
                    gameManager.EndDay();
                    Debug.Log("Tüm kargolar teslim edildi!");
                    
                }
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
