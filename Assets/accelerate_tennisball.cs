using UnityEngine;

public class BallController : MonoBehaviour
{
    public float acceleration = 20f; // Feel free to adjust this for more responsive movement
    public float maxSpeed = 10f; // Adjust as needed to control the max speed

    private Rigidbody rb; // To store the Rigidbody component
    private Transform cameraTransform; // To reference the camera's transform

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform; // Assuming the main camera is the correct one to use
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the direction vector based on the camera's orientation, ignoring its vertical tilt
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0; // This ensures the movement is horizontal
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 direction = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        // Apply the force based on the calculated direction
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(direction * acceleration, ForceMode.Acceleration);
        }
    }
}
