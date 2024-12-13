using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Package currentPackage;
    private Package lastTouchedPackage;
    public static PlayerController Instance;

    public CargoDurability cargoDurability;
    

    public CargoUI cargoUI;

    public bool isEmpty = true;
    public bool isThrew = false;

    public bool isDetails = false;

    

    private void Awake()
    {
        Instance = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Package package = collision.gameObject.GetComponent<Package>();

        if (package != null && !package.isPickedUp)
        {
            lastTouchedPackage = package;
            Debug.Log("Touched package: " + package.name);
        }
    }

    public void HandlePickUpPackage()
    {
        CheckDistance();
        if (isEmpty && lastTouchedPackage != null && !lastTouchedPackage.isPickedUp)
        {
            currentPackage = lastTouchedPackage;
            currentPackage.isPickedUp = true;
            currentPackage.GetComponent<Rigidbody>().useGravity = false;
            currentPackage.GetComponent<Collider>().enabled = false;
            currentPackage.transform.SetParent(this.transform);
            currentPackage.transform.localPosition = new Vector3(0, 1.5f, 1f);
            isEmpty = false;
            

            Debug.Log("Picked up package: " + currentPackage.name);

            Debug.Log("Package Weight: " + currentPackage.cargoSO.weight);
            Debug.Log("Package Type: " + currentPackage.cargoSO.cargoName);
            Debug.Log("Package Size: " + currentPackage.cargoSO.weight);


        }
        else
            Debug.Log("Distance is so big");
    }

    public void HandleDropPackage()
    {
        if (currentPackage != null)
        {
            currentPackage.isPickedUp = false;
            currentPackage.transform.SetParent(null);
            currentPackage.GetComponent<Rigidbody>().useGravity = true;
            currentPackage.GetComponent<Collider>().enabled = true;
            currentPackage = null;
            isEmpty = true;
            cargoUI.CloseDetails();

            Debug.Log("Dropped package.");
        }
    }

    public void OpenCargoDetails()
    {
        isDetails = true;
        cargoUI.CargoDetails(currentPackage);
    }

    public void CloseCargoDetails()
    {
        isDetails = false;
        cargoUI.CloseDetails();
    }
    void CheckDistance()
    {
        Vector3 playerLoc = this.GetComponent<Transform>().position;
        Vector3 packageLoc = lastTouchedPackage.GetComponent<Transform>().position;

        if (Vector3.Distance(playerLoc, packageLoc) > 3f)
        {
            lastTouchedPackage = null;
        }
    }
    public void HandleThrowPackage()
    {
        if (currentPackage != null)
        {
            isThrew = true;
            currentPackage.isPickedUp = false;
            currentPackage.transform.SetParent(null);

            Vector3 throwDirection = transform.forward;
            float throwForce = 25f;
            currentPackage.GetComponent<Rigidbody>().AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
            currentPackage.GetComponent<Rigidbody>().useGravity = true;
            currentPackage.GetComponent<Collider>().enabled = true;
            cargoUI.CloseDetails();
            cargoDurability.CalculateDurability(currentPackage);

            currentPackage = null;
            isEmpty = true;
            Debug.Log("Threw package.");
        }
    }
}
