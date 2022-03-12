using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody rb;
    public Gamemanager Gamemanager;
    private Gamemanager gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = Gamemanager.GetComponent<Gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //make it not fall over when touching the ground after spawning
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
        }
        rb.isKinematic = true;
        
    }
}
