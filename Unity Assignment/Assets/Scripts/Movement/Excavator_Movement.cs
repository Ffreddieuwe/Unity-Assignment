using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excavator_Movement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.5f;
    public float verticalSpeed = 1.5f;
    public float horizontalSpeed = 1.5f;

    private Animator anim;
    private HashIDs hash;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

        anim.SetLayerWeight(1, 1f);
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        bool sprint = Input.GetButton("Sprint");
        Movement(v, sprint);

        float turn = Input.GetAxis("Turn");
        Rotate(turn);
    }

    void Rotate(float mouseXInput)
    {
        Rigidbody body = this.GetComponent<Rigidbody>();


        if (mouseXInput > 0)
        {
            anim.SetFloat(hash.left_wheel_speed, 1.5f, speedDampTime, Time.deltaTime);
            anim.SetFloat(hash.right_wheel_speed, -1.5f, speedDampTime, Time.deltaTime);
            Quaternion deltaRotation = Quaternion.Euler(0f, (mouseXInput * sensitivityX) / 10, 0f);
            body.MoveRotation(body.rotation * deltaRotation);
        }
        else if (mouseXInput < 0)
        {
            horizontalSpeed = -1.5f;
            anim.SetFloat(hash.left_wheel_speed, horizontalSpeed, speedDampTime, Time.deltaTime);
            anim.SetFloat(hash.right_wheel_speed, horizontalSpeed, speedDampTime, Time.deltaTime);
            Quaternion deltaRotation = Quaternion.Euler(0f, (mouseXInput * sensitivityX) / 100, 0f);
            body.MoveRotation(body.rotation * deltaRotation);
        }
    }


    void Movement(float vertical, bool sprinting)
    {
        if (vertical > 0)
        {
            verticalSpeed = 1.5f;
        }
        else if (vertical < 0)
        {
            verticalSpeed = -1.5f;
        }


        if (vertical != 0)
        {
            anim.SetFloat(hash.left_wheel_speed, verticalSpeed, speedDampTime, Time.deltaTime);
            anim.SetFloat(hash.right_wheel_speed, verticalSpeed, speedDampTime, Time.deltaTime);
        }
    }
}
