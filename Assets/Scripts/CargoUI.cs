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
        cargoType.text = cargoPackage.cargoSO.cargoType.ToString();
        locationType.text = cargoPackage.cargoSO.locationType.ToString();
        deliveryDeadline.text = cargoPackage.cargoSO.deliveryDeadline.ToString();
        weight.text = cargoPackage.cargoSO.weight.ToString() + " kg"; 
        durability.text = cargoPackage.cargoSO.durability.ToString();
        navigationSystem.SetTarget(cargo);
    }

    public void CloseDetails()
    {
        details.SetActive(false);
    }

    
}
