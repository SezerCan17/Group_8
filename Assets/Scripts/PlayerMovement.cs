using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }
    [SerializeField] InputHandler InputHandler;
    [SerializeField] float moveSpeed = 5f;

    Rigidbody playerRigidbody;

    private Transform carryPoint;

    bool isWalking;

    private void Awake()
    {
        Instance = this;

        playerRigidbody = GetComponent<Rigidbody>();
        carryPoint = GetComponent<Transform>();
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
