using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class max_velocity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = 5000f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
