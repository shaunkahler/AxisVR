using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class WheelDebugger2 : MonoBehaviour
{
    public Rigidbody rb;
    public WheelCollider[] wheels;
    public bool enableDebugDraw = true;

   
    void FixedUpdate()
    {
        if (rb == null || wheels.Length == 0) return;

        // Log Rigidbody velocity and force
        Vector3 force = rb.velocity * rb.mass;
        Debug.Log($"Velocity: {rb.velocity.magnitude:F2} m/s | Force: {force.magnitude:F2} N");

        foreach (var wheel in wheels)
        {
            WheelHit hit;
            if (wheel.GetGroundHit(out hit))
            {
                // Log suspension and slip values
                Debug.Log($"[Wheel: {wheel.name}] " +
                    $"Spring Force: {hit.force:F2} N | " +
                    $"Forward Slip: {hit.forwardSlip:F3} | " +
                    $"Side Slip: {hit.sidewaysSlip:F3} | " +
                    $"Grounded: {wheel.isGrounded}");

                if (enableDebugDraw)
                {
                    // Draw force applied to the wheel
                    Debug.DrawRay(hit.point, hit.normal * hit.force * 0.0005f, Color.red);

                    // Draw slip direction
                    Debug.DrawRay(hit.point, rb.velocity.normalized * 0.2f, Color.blue);
                }
            }
        }
    }

    void Start()
    {
        Debug.Log("✅ WheelDebugger is running!");
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (wheels.Length == 0) wheels = GetComponentsInChildren<WheelCollider>();
    }
}
