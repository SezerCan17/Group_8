using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    PlayerInput playerInput;
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        playerInput.Player.PickUp.performed += PlayerPickUp;
        playerInput.Player.Throw.performed += PlayerThrow;
        playerInput.Player.Details.performed += PlayerDetails;
    }

    private void PlayerThrow(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            PlayerController.Instance.HandleThrowPackage();
        }
    }

    private void PlayerPickUp(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton()&& PlayerController.Instance.isEmpty)
        {
            PlayerController.Instance.HandlePickUpPackage();
        }
        else if (context.ReadValueAsButton() && !PlayerController.Instance.isEmpty)
        {
            PlayerController.Instance.HandleDropPackage();
        }
    }

    private void PlayerDetails(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton()&& !PlayerController.Instance.isDetails &&  !PlayerController.Instance.isEmpty)
        {
            PlayerController.Instance.OpenCargoDetails();
        }
        else if (context.ReadValueAsButton() && PlayerController.Instance.isDetails &&  !PlayerController.Instance.isEmpty)
        {
            PlayerController.Instance.CloseCargoDetails();
        }
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        
        return inputVector;
    }
    
}
