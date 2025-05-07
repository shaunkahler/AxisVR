using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTorqueDebugger : MonoBehaviour
{
    public WheelCollider[] wheels;  // Assign all 4 wheels in the Inspector
    public Rigidbody carRigidbody;  // Assign the car’s Rigidbody

    public float maxTorque = 1000000f; // Set to your current torque value
    public float maxRPM = 5000f; // Limit RPM to realistic values

    void FixedUpdate()
    {
        float totalForce = 0f;
        float avgRPM = 0f;
        float avgSlip = 0f;
        
        foreach (WheelCollider wheel in wheels)
        {
            // Get current RPM and slip
            float wheelRPM = wheel.rpm;
            WheelHit hit;
            wheel.GetGroundHit(out hit);

            // Calculate and apply torque
            if (wheelRPM < maxRPM) // Prevent infinite wheel spin
                wheel.motorTorque = maxTorque;
            else
                wheel.motorTorque = 0; // Cut torque if RPM is too high (simulates real engine)

            // Calculate forces
            float slip = hit.forwardSlip;
            totalForce += wheel.motorTorque;
            avgRPM += wheelRPM;
            avgSlip += slip;

            // Debug output for each wheel
            Debug.Log($"[Wheel: {wheel.name}] Torque: {wheel.motorTorque}, RPM: {wheelRPM}, Slip: {slip}");
        }

        // Get average values for logs
        avgRPM /= wheels.Length;
        avgSlip /= wheels.Length;

        // Debug the total applied force and speed
        Debug.Log($"Car Speed: {carRigidbody.velocity.magnitude} m/s, Total Torque: {totalForce}, Avg RPM: {avgRPM}, Avg Slip: {avgSlip}");

        // Check for issues:
        if (avgRPM > maxRPM * 0.9f)
            Debug.LogWarning("⚠️ WARNING: Wheels are spinning too fast, possibly losing traction!");

        if (avgSlip > 0.1f)
            Debug.LogWarning("⚠️ WARNING: Excessive wheel slip detected! Increase friction or lower torque.");

        if (carRigidbody.velocity.magnitude < 5f && totalForce > 500000f)
            Debug.LogError("🚨 ERROR: High torque applied but low speed! Possible high drag, wrong gear ratios, or excessive slip.");
    }
}
