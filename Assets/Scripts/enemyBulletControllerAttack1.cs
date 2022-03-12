using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletControllerAttack1 : MonoBehaviour
{   
     public GameObject Attack;
    private AttackPlayer1 WhichAttack;
    
    public float movespeed = 10;
    private Rigidbody rb;
    private Rigidbody rb2;
    public Vector3 Movedirection;
    public Vector3 MovedirectionOnEnemy;
    PlayerController target;
    public GameObject target2;
    public int AimX;
    public bool attack1;
    public bool attack2;
    public bool attack3;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb2 = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<PlayerController>();
        target2 = GameObject.FindGameObjectWithTag("Enemy");
        WhichAttack =Attack.GetComponent<AttackPlayer1>();
        
        if (WhichAttack.attack1)
        { 
            Movedirection = (target.transform.position - transform.position).normalized * movespeed;
            rb.velocity = new Vector3(Movedirection.x + AimX, 0, Movedirection.z);
            Destroy(gameObject, 5f);
        }  if (WhichAttack.attack2)
        {
            transform.position = Vector3.forward;
            Destroy(gameObject, 5f);
        }

   
    }
    

    void Update()
    {
        
        if (attack3)
        {
            rb.velocity = new Vector3(MovedirectionOnEnemy.x, 0, MovedirectionOnEnemy.z);
            MovedirectionOnEnemy = (target2.transform.position - transform.position).normalized * movespeed;
            
         }
    }

    public void Attack1Active()
    {
        attack1 = true;
        attack2 = false;
        attack3 = false;
    }

    
    public void Attack2Active()
    {
        attack1 = false;
        attack2 = true;
        attack3 = false;
    }
    
    
    public void Attack3Active()
    {
        attack1 = false;
        attack2 = false;
        attack3 = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
