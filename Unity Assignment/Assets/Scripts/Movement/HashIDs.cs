using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int forwardsState;
    public int backwardsState;
    public int leftState;
    public int rightState;

    public int sprintBool;

    public int speedFloatH;
    public int speedFloatV;

    public int left_wheel_speed;
    public int right_wheel_speed;
    public int arm_up;
    public int arm_left;
    public int arm_right;
    public int is_spinning;

    private void Awake()
    {
        forwardsState = Animator.StringToHash("BaseLayer.Forwards");
        backwardsState = Animator.StringToHash("Backwards");
        leftState = Animator.StringToHash("Left");
        rightState = Animator.StringToHash("Right");

        sprintBool = Animator.StringToHash("Sprinting");

        speedFloatH = Animator.StringToHash("SpeedH");
        speedFloatV = Animator.StringToHash("SpeedV");


        left_wheel_speed = Animator.StringToHash("Left_Wheel_Speed");
        right_wheel_speed = Animator.StringToHash("Right_Wheel_Speed");
        is_spinning = Animator.StringToHash("Is_Spinning");
        arm_left = Animator.StringToHash("Arm_Left");
        arm_right = Animator.StringToHash("Arm_Right");
        arm_up = Animator.StringToHash("Arm_Up");
    }
}
