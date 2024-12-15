using System;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public LocationSO locationData;

    bool flag=false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cargo")
        {
          if(flag == true  )
          {
            //if(gameObject.transform.position == other.)

          } 
        }
    }
}
