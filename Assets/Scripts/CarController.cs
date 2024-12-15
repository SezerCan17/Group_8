using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarController : MonoBehaviour
{
    public Transform frontLeftWheel, frontRightWheel;
    public Transform rearLeftWheel, rearRightWheel;

    public WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    public float maxSteerAngle = 45f;
    public float motorForce = 1500f;
    public float brakeForce = 3000f;
    public float decelerationForce = 100f;
    public float reverseForce = 1000f;
    public float stopThreshold = 1f;
    public float flipThresholdAngle = 45f;
    public float steeringSmoothTime = 0.5f; // Duration to smooth the steering

    private float currentSteerAngle;
    private float currentAcceleration;
    private float currentBrakeForce;
    private bool isCheckingFlip = false;
    private float flipCheckTime = 4f;

    private Rigidbody carRigidbody;
    private Renderer carRenderer;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        carRenderer = GetComponent<Renderer>();

        // Adjust center of mass
        carRigidbody.centerOfMass = new Vector3(0, -0.5f, 0);

        // Increase the mass of the car
        carRigidbody.mass = 1500f;

        // Ensure wheel colliders are correctly aligned
        AlignWheelColliders();

        // Set up WheelColliders
        SetupWheelColliders();
    }

    private void Update()
    {
        // Ground check
        if (Physics.Raycast(transform.position, -Vector3.up, 1.5f))
        {
            HandleInput();
            ApplyMovement();
            UpdateWheelPoses();
            CheckFlip();
        }
        else
        {
            // Apply additional stability measures if needed
        }
    }

    private void HandleInput()
    {
        // Reset inputs
        currentAcceleration = 0f;
        currentBrakeForce = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            currentAcceleration = motorForce;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentAcceleration = -reverseForce;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            currentBrakeForce = brakeForce;
        }

        // Smoothly steer the car
        float targetSteerAngle = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            targetSteerAngle = -maxSteerAngle;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetSteerAngle = maxSteerAngle;
        }

        DOTween.To(() => currentSteerAngle, x => currentSteerAngle = x, targetSteerAngle, steeringSmoothTime);

        Debug.Log($"Acceleration: {currentAcceleration}, Brake: {currentBrakeForce}, Steer: {currentSteerAngle}");
    }

    public void CheckFlip()
    {
        if (Vector3.Angle(Vector3.up, transform.up) > flipThresholdAngle)
        {
            if (!isCheckingFlip)
            {
                isCheckingFlip = true;
                Invoke("CheckIfStillFlipped", flipCheckTime);
            }
        }
        else
        {
            isCheckingFlip = false;
            CancelInvoke("CheckIfStillFlipped");
        }
    }

    public void CheckIfStillFlipped()
    {
        if (isCheckingFlip)
        {
            StartRespawnProcess();
        }
    }

    public void StartRespawnProcess()
    {
        carRenderer.enabled = false;
        Invoke("Respawn", 2f);
    }

    private void Respawn()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        transform.rotation = Quaternion.identity;
        carRigidbody.velocity = Vector3.zero;
        carRigidbody.angularVelocity = Vector3.zero;

        carRenderer.enabled = true;
        isCheckingFlip = false;
    }

    private void ApplyMovement()
    {
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;

        if (currentAcceleration == 0f && currentBrakeForce == 0f)
        {
            rearLeftWheelCollider.brakeTorque = decelerationForce;
            rearRightWheelCollider.brakeTorque = decelerationForce;
        }
        else
        {
            rearLeftWheelCollider.brakeTorque = currentBrakeForce;
            rearRightWheelCollider.brakeTorque = currentBrakeForce;
        }
        rearLeftWheelCollider.motorTorque = currentAcceleration;
        rearRightWheelCollider.motorTorque = currentAcceleration;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftWheelCollider, frontLeftWheel);
        UpdateWheelPose(frontRightWheelCollider, frontRightWheel);
        UpdateWheelPose(rearLeftWheelCollider, rearLeftWheel);
        UpdateWheelPose(rearRightWheelCollider, rearRightWheel);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion quat;
        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat;
    }

    private void AlignWheelColliders()
    {
        Vector3 frontLeftWheelPosition = frontLeftWheel.localPosition;
        Vector3 frontRightWheelPosition = frontRightWheel.localPosition;
        Vector3 rearLeftWheelPosition = rearLeftWheel.localPosition;
        Vector3 rearRightWheelPosition = rearRightWheel.localPosition;

        frontLeftWheelCollider.transform.localPosition = frontLeftWheelPosition;
        frontRightWheelCollider.transform.localPosition = frontRightWheelPosition;
        rearLeftWheelCollider.transform.localPosition = rearLeftWheelPosition;
        rearRightWheelCollider.transform.localPosition = rearRightWheelPosition;
    }

    private void SetupWheelColliders()
    {
        WheelCollider[] wheelColliders = { frontLeftWheelCollider, frontRightWheelCollider, rearLeftWheelCollider, rearRightWheelCollider };
        foreach (var wheel in wheelColliders)
        {
            JointSpring suspensionSpring = wheel.suspensionSpring;
            suspensionSpring.spring = 35000f;
            suspensionSpring.damper = 4500f;
            wheel.suspensionSpring = suspensionSpring;

            WheelFrictionCurve forwardFriction = wheel.forwardFriction;
            forwardFriction.extremumSlip = 0.4f;
            forwardFriction.extremumValue = 1f;
            forwardFriction.asymptoteSlip = 0.8f;
            forwardFriction.asymptoteValue = 0.5f;
            forwardFriction.stiffness = 1f;
            wheel.forwardFriction = forwardFriction;

            WheelFrictionCurve sidewaysFriction = wheel.sidewaysFriction;
            sidewaysFriction.extremumSlip = 0.2f;
            sidewaysFriction.extremumValue = 1f;
            sidewaysFriction.asymptoteSlip = 0.5f;
            sidewaysFriction.asymptoteValue = 0.75f;
            sidewaysFriction.stiffness = 1f;
            wheel.sidewaysFriction = sidewaysFriction;
        }
    }
}
