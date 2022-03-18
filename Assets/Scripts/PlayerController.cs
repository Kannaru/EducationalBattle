using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 450;
    public float speed = 100;

    public Quaternion targetRotation;
    public CharacterController controller;

    public bool gotHit;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {        var gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    
        //Movement with the WASD/arrow keys
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (input != Vector3.zero && gm.gameActive) {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,
                targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        if (gm.gameActive) {
            Vector3 motion = input;
            motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? speed : speed;
            motion += Vector3.up * -20;
            controller.Move(motion * Time.deltaTime);
        }

        //Dashing with the LeftShift key
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = 200;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = 100;
        }
    }
}