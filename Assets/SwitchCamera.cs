using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    void Start()
    {
        // Ensure only Camera 1 is active at the start
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
    }

    void Update()
    {
        // Switch to Camera 2 when the "2" key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
        }

        // Switch back to Camera 1 when the "1" key is pressed (optional)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
        }
    }
}
