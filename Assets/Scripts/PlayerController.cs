using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour
{
  
    public float RotationSpeed = 450;
    public float speed = 20;

    public Quaternion targetRotation;

    public CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));


        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,targetRotation.eulerAngles.y,RotationSpeed * Time.deltaTime);
        }

        Vector3 motion = input;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? 100f : 100f; 
        motion += Vector3.up * -20;
        controller.Move(motion * Time.deltaTime);


    }
}
