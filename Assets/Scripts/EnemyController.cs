using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //make it not fall over when touching the ground after spawning
    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        
    }
}
