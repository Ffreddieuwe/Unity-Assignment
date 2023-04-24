using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excavator_Movement : MonoBehaviour
{
    Rigidbody excavator;
    public float moveSpeed = 0.1f;

    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.5f;
    public float verticalSpeed = 1.5f;
    public float horizontalSpeed = 1.5f;

    public bool armUp = false;
    public bool armLeft = false;
    public bool armRight = false;

    private Animator anim;
    private HashIDs hash;

    private void Awake()
    {
        excavator = this.GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

        anim.SetLayerWeight(1, 1f);
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        bool sprint = Input.GetButton("Sprint");
        Movement(v, sprint);

        bool arm_v = Input.GetButton("Arm Vertical");
        bool arm_l = Input.GetButton("Arm Left");
        bool arm_r = Input.GetButton("Arm Right");
        ArmControl(arm_v, arm_l, arm_r);

        float h = Input.GetAxis("Horizontal");
        Rotate(h);

        Vector3 movement = new Vector3(v, 0, 0);
        movement *= moveSpeed;
        movement = transform.TransformDirection(movement);
        excavator.AddForce(movement, ForceMode.VelocityChange);
    }

    void Rotate(float horizontal)
    {
        Rigidbody body = this.GetComponent<Rigidbody>();

        if (horizontal > 0)
        {
            anim.SetFloat(hash.left_wheel_speed, 1.5f, speedDampTime, Time.deltaTime);
            anim.SetFloat(hash.right_wheel_speed, -1.5f, speedDampTime, Time.deltaTime);
            Quaternion deltaRotation = Quaternion.Euler(0f, (horizontal * sensitivityX), 0f);
            body.MoveRotation(body.rotation * deltaRotation);
        }
        else if (horizontal < 0)
        {
            horizontalSpeed = -1.5f;
            anim.SetFloat(hash.left_wheel_speed, horizontalSpeed, speedDampTime, Time.deltaTime);
            anim.SetFloat(hash.right_wheel_speed, horizontalSpeed, speedDampTime, Time.deltaTime);
            Quaternion deltaRotation = Quaternion.Euler(0f, (horizontal * sensitivityX), 0f);
            body.MoveRotation(body.rotation * deltaRotation);
        }
    }

    void ArmControl(bool arm_up, bool arm_left, bool arm_right)
    {

        if (arm_up)
        {
            armUp = !armUp;
        }
        anim.SetBool(hash.arm_up, armUp);

        if (arm_left)
        {
            armRight = false;
            armLeft = true;
        }
        else if (arm_right)
        {
            armRight = true;
            armLeft = false;
        }

        anim.SetBool(hash.arm_left, armLeft);
        anim.SetBool(hash.arm_right, armRight);
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
