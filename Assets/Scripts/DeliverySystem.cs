using UnityEngine;
using UnityEngine.Events;

public class DeliverySystem : MonoBehaviour
{
    public UnityEvent OnSuccessfulDelivery; // Baþarýlý teslimat olayý
    public UnityEvent OnFailedDelivery;     // Baþarýsýz teslimat olayý

    public float deliveryTimeLimit = 10f;  // Teslimat için süre limiti
    public float elapsedTime = 0f;         // Geçen süre
    public bool isCargoDamaged = false;    // Kargo durumu

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Teslimat süresi biterse baþarýsýzlýk kontrolü
        if (elapsedTime >= deliveryTimeLimit)
        {
            TriggerFailedDelivery();
        }
    }

    public void CompleteDelivery()
    {
        if (!isCargoDamaged && elapsedTime < deliveryTimeLimit)
        {
            OnSuccessfulDelivery?.Invoke(); // Teslimat baþarýlý
        }
        else
        {
            TriggerFailedDelivery(); // Teslimat baþarýsýz
        }
    }

    private void TriggerFailedDelivery()
    {
        OnFailedDelivery?.Invoke(); // Baþarýsýz teslimat olayý
    }
}
