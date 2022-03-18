using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveBoss : MonoBehaviour
{
    private int _speed = 20;

    public int changeAttackNumber;
    public int whichAttack;
    public GameObject attackPattern;

    private AttackPlayer _control;
    
    private void Start()
    {
        _control = attackPattern.GetComponent<AttackPlayer>();
    }
    
    private void Update()
    {
        //Movement of attack 1 going from left to right constantly attacking you with 5 bullets  
        UpdateMovement();
        ChangeAttack();
    }


    private void UpdateMovement()
    {
        Vector3 movement = new Vector3(_speed, 0, 0);
        transform.Translate(movement * 15 * Time.deltaTime);

        //change direction when hitting the edge of the arena  
        if (transform.position.x < -200) {
            MoveRight();
        }

        else if (transform.position.x > 200) {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        changeAttackNumber = Random.Range(1, 3);
        _speed = 20;
    }

    void MoveLeft()
    {
        changeAttackNumber = Random.Range(1, 3);
        _speed = -20;
    }

    void ChangeAttack()
    {
        //if changeAttackNumber = 1 a new random other attack will happen
        //33% chance to change attack
        if (changeAttackNumber == 1) {
            whichAttack = Random.Range(0, 4);
            changeAttackNumber = 2;
        }

        if (whichAttack == 1) {
            _control.attack1 = true;
            _control.attack2 = false;
            _control.attack3 = false;
        }
        else if (whichAttack == 2) {
            _control.attack1 = false;
            _control.attack2 = true;
            _control.attack3 = false;
        }
        else if (whichAttack == 3) {
            _control.attack1 = false;
            _control.attack2 = false;
            _control.attack3 = true;
        }
    }
}