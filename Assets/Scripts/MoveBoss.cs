using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
    public int Speed = 20;

    public int alsospeed = 20;

    public int changeAttackNumber;
    public int whichAttack;
    public GameObject attackPattern;
    private AttackPlayer1 Control;
    // Start is called before the first frame update
    void Start()
    {
        Control = attackPattern.GetComponent<AttackPlayer1>();
        
        
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
        Vector3 movement = new Vector3(Speed, 0, 0);
        transform.Translate(movement * 15 * Time.deltaTime);
        if (transform.position.x < -200)
        {
            
            MoveRight();
        }

        else if (transform.position.x > 200)
        {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        changeAttackNumber = Random.Range(1, 3);
        Speed = 20;
    }

    void MoveLeft()
    {
        changeAttackNumber = Random.Range(1, 3);
        Speed = -20;
    }

    void ChangeAttack()
    {
        if (changeAttackNumber == 1)
        {
            whichAttack = Random.Range(0,4);
            changeAttackNumber = 2;
        }

        if (whichAttack == 1)
        {
            Debug.Log("attack1");
            Control.attack1 = true;
            Control.attack2 = false;
            Control.attack3 = false;
        }
        else if (whichAttack == 2)
        {
            Debug.Log("attack2");

            Control.attack1 = false;
            Control.attack2 = true;
            Control.attack3 = false;
        }
        else if (whichAttack == 3)
        {
            Debug.Log("attack3");

            Control.attack1 = false;
            Control.attack2 = false;
            Control.attack3 = true;
        }
    }
}
