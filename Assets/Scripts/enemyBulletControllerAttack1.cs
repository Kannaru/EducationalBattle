using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletControllerAttack1 : MonoBehaviour
{
    public GameObject attack;
    private AttackPlayer1 _whichAttack;

    public bool phase2 = false;
    public bool phase3 = false;

    public float moveSpeed = 400;
    private Rigidbody _rb;
    public Vector3 moveDirection;
    public Vector3 moveDirectionOnEnemy;
    public GameObject alttarget;
    public PlayerController _target;
    public GameObject target2;
    public int aimX;
    public bool attack1;
    public bool attack2;
    public bool attack3;

    public bool gothit;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        alttarget = GameObject.FindGameObjectWithTag("Player");
        _target = FindObjectOfType<PlayerController>();
        target2 = GameObject.FindGameObjectWithTag("Enemy");
        _whichAttack = attack.GetComponent<AttackPlayer1>();

        moveDirection = (_target.transform.position - transform.position).normalized * moveSpeed;
        _rb.velocity = new Vector3(moveDirection.x, 0, moveDirection.z);
        Destroy(gameObject, 2f);

        if (_whichAttack.attack2) {
            transform.position = Vector3.forward;
            Destroy(gameObject, 5f);
        }
    }


    void Update()
    {
        Gamemanager gm = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
        if (gm.bosshealth < 10 && phase2 == false) {
            moveSpeed = 500;
            phase2 = true;
        }

        if (gm.bosshealth < 5 && phase3 == false) {
            moveSpeed = 550;
            phase3 = true;
        }

        if (attack3) {
            moveDirectionOnEnemy = (target2.transform.position - transform.position).normalized * moveSpeed;
            _rb.velocity = new Vector3(moveDirectionOnEnemy.x, 0, moveDirectionOnEnemy.z);
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
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player") && !gothit) {
            gothit = true;
            Gamemanager gm = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
            if (gm.health > 0) {
                gm.health -= 1;
                gm.score -= 1000;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && gothit) {
            Destroy(gameObject);
            gothit = false;
        }
    }
}