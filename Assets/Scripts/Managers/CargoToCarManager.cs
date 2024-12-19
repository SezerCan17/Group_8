using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoToCarManager : MonoBehaviour
{
    public Transform[] trunkLocations; // Array of locations where cargo will be placed in the car
    private List<Transform> availableLocations = new List<Transform>(); // List to keep track of available locations

    private void Awake()
    {
        InitializeAvailableLocations();
    }

    private void InitializeAvailableLocations()
    {
        // Initialize the list of available locations
        availableLocations.Clear();
        availableLocations.AddRange(trunkLocations);
    }

    private void OnDrawGizmos()
    {
        if (trunkLocations != null && trunkLocations.Length > 0)
        {
            Gizmos.color = Color.red;
            foreach (Transform location in trunkLocations)
            {
                Gizmos.DrawCube(location.position, new Vector3(0.5f, 0.5f, 0.5f));
            }
        }
    }

    public Transform GetNextTrunkLocation()
    {
        if (availableLocations.Count > 0)
        {
            Transform nextLocation = availableLocations[0];
            availableLocations.RemoveAt(0); // Remove the location from the available list
            return nextLocation;
        }
        else
        {
            Debug.LogWarning("All trunk locations are occupied!");
            return null;
        }
    }

    public void FreeTrunkLocation(Transform location)
    {
        if (!availableLocations.Contains(location))
        {
            availableLocations.Add(location); // Add the location back to the available list
        }
    }
}
