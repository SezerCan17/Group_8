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
    public Animator Anim;
    public string AnimState;
    private int state = ANIMSTATE_IDLE;

    bool isWalking;

    const int ANIMSTATE_IDLE = 0;
    const int ANIMSTATE_WALK = 1;
    const int ANIMSTATE_BOX_WALK = 2;
    const int ANIMSTATE_BOX_IDLE = 3;
    const int ANIMSTATE_THROW = 4;


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

        if (moveDirection.sqrMagnitude > 0 && PlayerController.Instance.isEmpty)
        {
            ChangeAnimationState("Walk", 1);
        }
        else if (moveDirection.sqrMagnitude == 0 && PlayerController.Instance.isEmpty)
        {
            ChangeAnimationState("Idle", 0);
        }
        else if (moveDirection.sqrMagnitude > 0 && !PlayerController.Instance.isEmpty)
        {
            ChangeAnimationState("Box Walk", 2);
        }
        else if (moveDirection.sqrMagnitude == 0 && !PlayerController.Instance.isEmpty)
        {
            ChangeAnimationState("Box Idle", 3);
        }
        else if (moveDirection.sqrMagnitude >= 0 && PlayerController.Instance.isEmpty && PlayerController.Instance.isThrew)
        {
            ChangeAnimationState("Throw", ANIMSTATE_THROW);
            PlayerController.Instance.isThrew = false;
        }
    }
    public void ChangeAnimationState(string newState, int newStateID)
    {
        if (state == newStateID) return;

        state = newStateID;
        AnimState = newState;
        Anim.CrossFade(AnimState, 0.3f);

        Debug.Log($"Animation changed to: {AnimState}");
    }
}
