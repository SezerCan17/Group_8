using System;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    //public LocationSO locationData;
    public DeliveryManager deliveryManager;

    private void OnTriggerEnter(Collider other) {
  if (other.gameObject.tag == "cargo")
      {
        bool flag = deliveryManager.ControlDelivery(gameObject);

        if (flag)
        {
          other.gameObject.SetActive(false);

        }

        
      }
}

    

}


