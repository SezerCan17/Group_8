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
        playerInput.Player.Drop.performed += PlayerDrop;
        playerInput.Player.Throw.performed += PlayerThrow;
    }

    private void PlayerThrow(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            PlayerController.Instance.HandleThrowPackage();
        }
    }

    private void PlayerDrop(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            PlayerController.Instance.HandleDropPackage();
        }
    }

    private void PlayerPickUp(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            PlayerController.Instance.HandlePickUpPackage();
        }
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        
        return inputVector;
    }
    
}
