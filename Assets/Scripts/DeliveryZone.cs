using System;
using System.Numerics;
using UnityEngine;


public class DeliveryZone : MonoBehaviour
{
    //public LocationSO locationData;
    public DeliveryManager deliveryManager;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "cargo")
        {
            // Pozisyonu değiştirme (cargo'nun yeni pozisyonu)
            UnityEngine.Vector3 cargoP = new UnityEngine.Vector3(other.transform.position.x - 13.7f, 
                                         other.transform.position.y, 
                                         other.transform.position.z - 28.15f);
            
            // Cargo'nun yeni pozisyonunu ControlDelivery fonksiyonuna gönderme
            bool flag = deliveryManager.ControlDelivery(other.gameObject,gameObject); // Yeni pozisyonu geçiyoruz

            if (flag)
            {
                // Teslimat doğruysa cargo'yu devre dışı bırakıyoruz
                other.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Yanlış adres");
            }
        }
    }
}
