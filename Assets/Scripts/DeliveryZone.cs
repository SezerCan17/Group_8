using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public LocationSO locationData;

    private void OnTriggerEnter(Collider other)
    {
        //PlayerCargoHandler player = other.GetComponent<PlayerCargoHandler>();
        //if (player != null)
        //{
          //  player.DeliverCargo(locationData);
        //}
    }
}
