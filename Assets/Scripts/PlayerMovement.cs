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
    private GameObject carriedObject;

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
    public void HandlePlayerTake(GameObject targetObject)
    {
        if (carriedObject == null && targetObject != null)
        {
            targetObject.GetComponent<Rigidbody>().useGravity = false;
            carriedObject = targetObject;
            carriedObject.transform.SetParent(carryPoint);
            carriedObject.transform.localPosition = new Vector3(carryPoint.localPosition.x/3, carryPoint.localPosition.y/4, carryPoint.localPosition.z/4);
            //carriedObject.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Object picked up: " + carriedObject.name);
        }
    }
    public void HandlePlayerPutDown()
    {
        if (carriedObject != null)
        {
            carriedObject.transform.SetParent(null);
            //carriedObject.GetComponent<Rigidbody>().isKinematic = false;
            carriedObject.GetComponent<Rigidbody>().useGravity = true;
            carriedObject = null;
            Debug.Log("Object dropped!");
        }
    }
}
