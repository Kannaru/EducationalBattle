using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float RotationSpeed = 450;
    public float speed;
    public GameObject Gamemanager;
    private Gamemanager gm;
    

    public Quaternion targetRotation;
    public CharacterController controller;
    public PlayerShoot shooting;

    public float dashCooldown;
    public bool onGround = true;

    void Start()
    {
        gm = Gamemanager.GetComponent<Gamemanager>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement with the WASD/arrow keys
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,
                targetRotation.eulerAngles.y, RotationSpeed * Time.deltaTime);
        }

        Vector3 motion = input;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? speed : speed;
        motion += Vector3.up * -20;
        controller.Move(motion * Time.deltaTime);

        //Dashing with the LeftShift key
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 200;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 100;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            gm.health -= 1;
        }
    }
}