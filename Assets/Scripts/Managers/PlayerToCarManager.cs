using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerToCarManager : MonoBehaviour
{
    public GameObject player;
    public GameObject car;
    public CinemachineVirtualCamera cinemachineCamera;
    public Transform CharSpawnPoint;
    public float switchDistance = 2.0f;

    private bool isPlayerControlling = true;
    private PlayerController playerController;
    private CarController carController;

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player is null");
            return;
        }

        if (car == null)
        {
            Debug.LogError("Car is null");
            return;
        }

        if (cinemachineCamera == null)
        {
            Debug.LogError("Cinemachine camera is null");
            return;
        }

        playerController = player.GetComponent<PlayerController>();
        carController = car.GetComponent<CarController>();

        if (playerController == null)
            Debug.LogError("PlayerController is not attached to the player");

        if (carController == null)
            Debug.LogError("CarController is not attached to the car");

        // Ensure the player is active and the car control is inactive at the start
        player.SetActive(true);
        car.SetActive(true);

        // Set initial camera follow target to player
        cinemachineCamera.Follow = player.transform;

        // Deactivate car controller at start
        carController.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the player is near the CharSpawnPoint
            if (Vector3.Distance(player.transform.position, CharSpawnPoint.position) <= switchDistance)
            {
                DoTheTransition();
            }
            else if(!isPlayerControlling)
            {
                DoTheTransition();
            }
                
        }
    }

    private void DoTheTransition()
    {
        if (isPlayerControlling)
        {
            // Transition from player to car
            // Change camera follow target to car
            cinemachineCamera.Follow = car.transform;

            // Deactivate player controller and activate car controller
            player.SetActive(false);
            carController.enabled = true;

            isPlayerControlling = false;
        }
        else
        {
            // Transition from car to player
            player.transform.position = car.transform.position + car.transform.right * 2; // Teleport player next to car

            // Change camera follow target to player
            cinemachineCamera.Follow = player.transform;

            // Deactivate car controller and activate player controller
            carController.enabled = false;
            player.transform.position = CharSpawnPoint.position;
            player.SetActive(true);

            isPlayerControlling = true;
        }
    }
}
