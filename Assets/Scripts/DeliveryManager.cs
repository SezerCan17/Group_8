using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public CargoSpawner cargoSpawner;
    public Mailboxs mailboxs;

    public float distanceThreshold = 0.5f;


    
   public bool ControlDelivery(GameObject mailbox)
   {
    Debug.Log(cargoSpawner.spawnPoint.Length + " Tane kargo var bra" );
      for (int j = 0; j < cargoSpawner.spawnPoint.Length; j++)
        {
           Vector3 adjustedPosition = new Vector3(
            mailbox.transform.position.x ,
            mailbox.transform.position.y,
            mailbox.transform.position.z
        );
            // İki pozisyon arasındaki mesafeyi hesapla
            float distance = Vector3.Distance(cargoSpawner.spawnPoint[j].position, adjustedPosition);

            if (distance <= distanceThreshold)
            {
                Debug.Log("Doğru adres");
                // Doğru adres için ek işlem yapabilirsiniz
                break;
                
            }
        }

        //Debug.Log("Yanlış adres");
        return true;

   }
}
