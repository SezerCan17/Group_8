using System;
using System.Numerics;
using UnityEngine;


public class DeliveryZone : MonoBehaviour
{
    
    public DeliveryManager deliveryManager;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "cargo")
        {
            
            UnityEngine.Vector3 cargoP = new UnityEngine.Vector3(other.transform.position.x - 13.7f, 
                                         other.transform.position.y, 
                                         other.transform.position.z - 28.15f);
            
            
            bool flag = deliveryManager.ControlDelivery(other.gameObject,gameObject); 

            if (flag)
            {
                
                other.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Yanlış adres");
            }
        }
    }
}
