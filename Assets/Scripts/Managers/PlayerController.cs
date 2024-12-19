using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Package currentPackage;
    public static PlayerController Instance;

    public CargoDurability cargoDurability;
    public CargoUI cargoUI;

    public bool isEmpty = true;
    public bool isThrew = false;
    public bool isDetails = false;

    public CargoToCarManager cargoToCarManager;
    public float trunkInteractionDistance = 3.0f; // Distance within which the player can place cargo in the trunk
    public float interactionRadius = 3.0f; // Radius within which the player can interact with packages

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Example key for picking up a package
        {
            HandlePickUpPackage();
        }
        if (Input.GetKeyDown(KeyCode.Q)) // Example key for dropping a package
        {
            HandleDropPackage();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    private List<Package> GetPackagesInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRadius);
        List<Package> packagesInRange = new List<Package>();

        foreach (var hitCollider in hitColliders)
        {
            Package package = hitCollider.GetComponent<Package>();
            if (package != null && !package.isPickedUp)
            {
                packagesInRange.Add(package);
            }
        }
        return packagesInRange;
    }

    public void HandlePickUpPackage()
    {
        if (isEmpty)
        {
            List<Package> packagesInRange = GetPackagesInRange();
            if (packagesInRange.Count > 0)
            {
                int randomIndex = Random.Range(0, packagesInRange.Count);
                currentPackage = packagesInRange[randomIndex];
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
            {
                Debug.Log("No packages detected within interaction radius.");
            }
        }
    }

    public void HandleDropPackage()
    {
        if (currentPackage != null)
        {
            // Check if player is near the car's trunk
            if (cargoToCarManager != null && Vector3.Distance(transform.position, cargoToCarManager.trunkLocations[0].position) <= trunkInteractionDistance)
            {
                // Get the next available trunk location
                Transform nextTrunkLocation = cargoToCarManager.GetNextTrunkLocation();
                if (nextTrunkLocation != null)
                {
                    // Place the cargo in the car's trunk at the next available location
                    currentPackage.isPickedUp = false;
                    currentPackage.transform.SetParent(nextTrunkLocation);
                    currentPackage.transform.localPosition = Vector3.zero;
                    Rigidbody packageRigidbody = currentPackage.GetComponent<Rigidbody>();
                    packageRigidbody.isKinematic = true;
                    packageRigidbody.useGravity = false;
                    currentPackage.GetComponent<Collider>().enabled = true;
                    currentPackage = null;
                    isEmpty = true;
                    cargoUI.CloseDetails();

                    Debug.Log("Placed package in the car's trunk at location: " + nextTrunkLocation.name);
                }
                else
                {
                    Debug.Log("No available trunk locations to place the package.");
                }
            }
            else
            {
                // Drop the cargo on the ground
                currentPackage.isPickedUp = false;
                currentPackage.transform.SetParent(null);
                Rigidbody packageRigidbody = currentPackage.GetComponent<Rigidbody>();
                packageRigidbody.isKinematic = false;
                packageRigidbody.useGravity = true;
                currentPackage.GetComponent<Collider>().enabled = true;
                currentPackage = null;
                isEmpty = true;
                cargoUI.CloseDetails();

                Debug.Log("Dropped package.");
            }
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
            currentPackage.GetComponent<Rigidbody>().isKinematic = false;
            currentPackage.GetComponent<Rigidbody>().useGravity = true;
            currentPackage.GetComponent<Collider>().enabled = true;
            cargoUI.CloseDetails();
            cargoDurability.CalculateDurability(currentPackage);

            currentPackage = null;
            isEmpty = true;
            Debug.Log("Threw package.");
        }
    }

    public void RemovePackageFromTrunk(Package package)
    {
        if (package.transform.parent != null)
        {
            Transform trunkLocation = package.transform.parent;
            package.transform.SetParent(null);
            cargoToCarManager.FreeTrunkLocation(trunkLocation);

            Rigidbody packageRigidbody = package.GetComponent<Rigidbody>();
            packageRigidbody.isKinematic = false;
            packageRigidbody.useGravity = true;
            package.GetComponent<Collider>().enabled = true;

            Debug.Log("Removed package from trunk location: " + trunkLocation.name);
        }
    }
}
