using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveBoss : MonoBehaviour
{
    public int speed = 20;

    public int alsoSpeed = 20;

    public int changeAttackNumber;
    public int whichAttack;
    public GameObject attackPattern;

    private AttackPlayer1 _control;

    // Start is called before the first frame update
    public void Start()
    {
        _control = attackPattern.GetComponent<AttackPlayer1>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement of attack 1 going from left to right constantly attacking you with 5 bullets  
        UpdateMovement();
        ChangeAttack();
    }


    private void UpdateMovement()
    {
        Vector3 movement = new Vector3(speed, 0, 0);
        transform.Translate(movement * 15 * Time.deltaTime);


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
        speed = 20;
    }

    void MoveLeft()
    {
        changeAttackNumber = Random.Range(1, 3);
        speed = -20;
    }

    void ChangeAttack()
    {
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