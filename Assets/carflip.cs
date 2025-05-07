using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFlip : MonoBehaviour
{
    public float jumpForce = 5f; // Upward force to lift the car
    public KeyCode flipKey = KeyCode.F; // Key to flip the car

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(flipKey))
        {
            FlipCar();
        }
    }

    void FlipCar()
    {
        // Reset rotation to upright (keep current Y rotation)
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        // Slightly lift the car before applying the jump force
        transform.position += Vector3.up * 0.5f; // Small lift to prevent sticking

        // Apply an upward force to free the car from the ground
        rb.velocity = Vector3.zero; // Reset velocity to avoid weird physics behavior
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
