using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 10.0f;
    public float animationSpeedV = 1.5f;
    public float animationSpeedH = 1.5f;

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
        Rotate(h);
    }

    void Rotate(float horizontal)
    {
        Rigidbody body = this.GetComponent<Rigidbody>();

        if (horizontal != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, horizontal * sensitivityX * 3, 0f);
            body.MoveRotation(body.rotation * deltaRotation);
        }
    }

    void Movement(float vertical, bool sprinting)
    {
        if (vertical > 0)
        {
            animationSpeedV = 1.5f;
        }
        else if (vertical < 0)
        {
            animationSpeedV = -1.5f;
        }

        anim.SetBool(hash.sprintBool, sprinting);
        {
            anim.SetFloat(hash.speedFloatV, animationSpeedV, speedDampTime, Time.deltaTime);
        }
       
        if (vertical != 0)
        {
            anim.SetFloat(hash.speedFloatV, animationSpeedV, speedDampTime, Time.deltaTime);
        }
        else
        {
            anim.SetFloat(hash.speedFloatV, 0);
        }
    }
}
