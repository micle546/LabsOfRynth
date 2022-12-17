using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEditor;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public static PlayerMotor instance { get; private set; }

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool crouching = false;
    private bool sprinting = false;
    private bool lerpCrouch = false;

    public float baseSpeed = 5f;
    public float speedUpgrade = 0f;
    public float speedBoost = 0f;
    public float sprintSpeedMod = 2f;
    public float crouchSpeedMod = -3f;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float crouchTimer = 1;
    



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }

        speed = (baseSpeed + Convert.ToSingle(sprinting) 
            * sprintSpeedMod + Convert.ToSingle(crouching)
            * crouchSpeedMod
            + speedBoost
            + speedUpgrade);

    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity*Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y); //show gravity downward force
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    public void Sprint()
    {
        sprinting = !sprinting;
    }
}
