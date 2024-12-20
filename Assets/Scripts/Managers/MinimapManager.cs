using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public GameObject quadPrefab;
    public Transform[] deliveryLocations;
    public int[] daysToShowLocations;

    private int currentDay = 0; // Track the current day

    void Start()
    {
        ShowLocationsForCurrentDay();
    }

    // Call this method to move to the next day and update the locations
    public void NextDay()
    {
        currentDay++;
        if (currentDay < daysToShowLocations.Length)
        {
            ShowLocationsForCurrentDay();
        }
        else
        {
            Debug.Log("No more days to show locations.");
        }
    }

    // Instantiate quads at delivery locations based on the current day
    private void ShowLocationsForCurrentDay()
    {
        ClearPreviousQuads(); // Clear any previous quads

        int locationsToShow = daysToShowLocations[currentDay];

        for (int i = 0; i < locationsToShow && i < deliveryLocations.Length; i++)
        {
            // Instantiate the quad with a rotation of 90 degrees on the X-axis
            Instantiate(quadPrefab,
                        new Vector3(deliveryLocations[i].position.x, quadPrefab.transform.position.y, deliveryLocations[i].position.z),
                        Quaternion.Euler(90, 0, 0));
        }
    }

    // Clear previously instantiated quads
    private void ClearPreviousQuads()
    {
        GameObject[] quads = GameObject.FindGameObjectsWithTag("Quad");
        foreach (GameObject quad in quads)
        {
            Destroy(quad);
        }
    }
}
