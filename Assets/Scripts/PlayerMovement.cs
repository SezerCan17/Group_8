using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputHandler InputHandler;
    [SerializeField] float moveSpeed = 5f;

    Rigidbody playerRigidbody;

    bool isWalking;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        HandlePlayerMovement();
    }
    void HandlePlayerMovement()
    {
        Vector2 inputVector = InputHandler.GetMovementVector();

        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        isWalking = moveDirection != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }
}
