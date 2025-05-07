using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStability : MonoBehaviour // ✅ Must inherit from MonoBehaviour
{
    private Rigidbody rb; // ✅ Declare a Rigidbody variable

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // ✅ Correct usage inside a method
        rb.centerOfMass = new Vector3(0, -0.00f, 0); // ✅ Lower center of mass
    }
}
