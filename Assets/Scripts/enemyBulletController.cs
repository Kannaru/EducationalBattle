using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletController : MonoBehaviour
{
    public float movespeed = 10;

    private Rigidbody rb;

    PlayerController target;

    public Vector3 Movedirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<PlayerController>();
        Movedirection = (target.transform.position - transform.position).normalized * movespeed;
        rb.velocity = new Vector3(Movedirection.x + 500, Movedirection.y, Movedirection.z);
        Destroy(gameObject, 3f);
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals(target))
        {
            
            Destroy(gameObject);
        }
    }
}
