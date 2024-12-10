using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    PlayerInput playerInput;
    bool isPlayerEnter;
    GameObject package;
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        playerInput.Player.PickUp.performed += PlayerTake;
        playerInput.Player.Drop.performed += PlayerPutDown;
    }

    private void PlayerPutDown(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            PlayerMovement.Instance.HandlePlayerPutDown();
        }
    }

    private void PlayerTake(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && isPlayerEnter)
        {
            //GameObject targetObject = raycastManager.PerformFanRaycast();
            
            PlayerMovement.Instance.HandlePlayerTake(package.gameObject);
        }
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        
        return inputVector;
    }
    
}
