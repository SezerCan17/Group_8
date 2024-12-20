using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CargoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text cargoType;
    [SerializeField] private TMP_Text locationType;
    [SerializeField] private TMP_Text deliveryDeadline;
    [SerializeField] private TMP_Text weight;
    [SerializeField] private TMP_Text durability;

    [SerializeField] private GameObject details;

    public NavigationSystem navigationSystem;

    

    public void CargoDetails(Package cargo)
    {
        details.SetActive(true);

        Package cargoPackage = cargo.gameObject.GetComponent<Package>();
        cargoType.text = " Cargo Type: " + cargoPackage.cargoSO.cargoType.ToString();
        locationType.text = " Location: " + cargoPackage.cargoSO.locationType.ToString();
        deliveryDeadline.text = " Deadline: " + cargoPackage.cargoSO.deliveryDeadline.ToString() + ":00";
        weight.text = " Weight: " + cargoPackage.cargoSO.weight.ToString() + " kg"; 
        durability.text = " Durability: " + cargoPackage.cargoSO.durability.ToString();
        navigationSystem.SetTarget(cargo);
    }

    public void CloseDetails()
    {
        details.SetActive(false);
    }

    
}
