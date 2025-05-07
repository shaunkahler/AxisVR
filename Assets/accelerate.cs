using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel, frontRightWheel;  // Steering wheels
    public WheelCollider rearLeftWheel, rearRightWheel;    // Drive wheels

    public float maxSteerAngle = 30f;
    public float motorTorque = 1500f;

    private float steerInput;
    private float accelerationInput;

    void Update()
    {
        steerInput = Input.GetAxis("Horizontal");
        accelerationInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Apply Steering (Front Wheels)
        float steerAngle = maxSteerAngle * steerInput;
        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;

        // Apply Acceleration (Rear Wheels)
        rearLeftWheel.motorTorque = accelerationInput * motorTorque;
        rearRightWheel.motorTorque = accelerationInput * motorTorque;
    }
}
