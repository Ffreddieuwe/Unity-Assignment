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

    private void Awake()
    {
        forwardsState = Animator.StringToHash("BaseLayer.Forwards");
        backwardsState = Animator.StringToHash("Backwards");
        leftState = Animator.StringToHash("Left");
        rightState = Animator.StringToHash("Right");

        sprintBool = Animator.StringToHash("Sprinting");

        speedFloatH = Animator.StringToHash("SpeedH");
        speedFloatV = Animator.StringToHash("SpeedV");
    }
}
