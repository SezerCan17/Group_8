using UnityEngine;
using UnityEngine.Events;

public class DeliverySystem : MonoBehaviour
{
    public UnityEvent OnSuccessfulDelivery; // Ba�ar�l� teslimat olay�
    public UnityEvent OnFailedDelivery;     // Ba�ar�s�z teslimat olay�

    public float deliveryTimeLimit = 10f;  // Teslimat i�in s�re limiti
    public float elapsedTime = 0f;         // Ge�en s�re
    public bool isCargoDamaged = false;    // Kargo durumu

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Teslimat s�resi biterse ba�ar�s�zl�k kontrol�
        if (elapsedTime >= deliveryTimeLimit)
        {
            TriggerFailedDelivery();
        }
    }

    public void CompleteDelivery()
    {
        if (!isCargoDamaged && elapsedTime < deliveryTimeLimit)
        {
            OnSuccessfulDelivery?.Invoke(); // Teslimat ba�ar�l�
        }
        else
        {
            TriggerFailedDelivery(); // Teslimat ba�ar�s�z
        }
    }

    private void TriggerFailedDelivery()
    {
        OnFailedDelivery?.Invoke(); // Ba�ar�s�z teslimat olay�
    }
}
