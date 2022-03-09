using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float RotationSpeed = 450;
    public float speed;

    public Quaternion targetRotation;
    public CharacterController controller;
    public PlayerShoot shooting;
    
    public float dashCooldown;
    public bool onGround = true;
    
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            speed = 200;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 100;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            jump();
        }

        void jump()
        {
            gameObject.transform.Translate(0,50,0);
            
            onGround = false;
        }
    }
    
    //WIP jump
    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}