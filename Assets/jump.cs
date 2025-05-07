using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_jump : MonoBehaviour

{
    public float jumpforce = 10f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpforce);
                
            }
        
    }
    
}
