using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public Vector3 hoverOffset = new Vector3(0, 2, -5); // Adjust hover position
    public float transitionSpeed = 5f; // Speed of movement

    private Vector3 targetPosition;
    private bool isHovering = false;

    void Start()
    {
        originalPosition = transform.position; // Store initial position
        targetPosition = originalPosition; // Set initial target
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isHovering = true;
            targetPosition = originalPosition + hoverOffset; // Move camera back
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isHovering = false;
            targetPosition = originalPosition; // Return to original position
        }

        // Smoothly move camera to target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
    }
}
