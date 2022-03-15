using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletControllerAttack1 : MonoBehaviour
{   
     public GameObject attack;
    private AttackPlayer1 _whichAttack;
    
    public float moveSpeed = 10;
    private Rigidbody _rb;
    public Vector3 moveDirection;
    public Vector3 moveDirectionOnEnemy;
    PlayerController _target;
    public GameObject target2;
    public int aimX;
    public bool attack1;
    public bool attack2;
    public bool attack3;


    void Start()
    {

        _rb = GetComponent<Rigidbody>();
        _target = GameObject.FindObjectOfType<PlayerController>();
        target2 = GameObject.FindGameObjectWithTag("Enemy");
        _whichAttack =attack.GetComponent<AttackPlayer1>();
        
        if (_whichAttack.attack1)
        { 
            moveDirection = (_target.transform.position - transform.position).normalized * moveSpeed;
            _rb.velocity = new Vector3(moveDirection.x + aimX, 0, moveDirection.z);
            Destroy(gameObject, 5f);
        }  if (_whichAttack.attack2)
        {
            transform.position = Vector3.forward;
            Destroy(gameObject, 5f);
        }
    }
    

    void Update()
    {
        
        if (attack3)
        {
            _rb.velocity = new Vector3(moveDirectionOnEnemy.x, 0, moveDirectionOnEnemy.z);
            moveDirectionOnEnemy = (target2.transform.position - transform.position).normalized * moveSpeed;
            
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
