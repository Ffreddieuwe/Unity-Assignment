using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry_Trigger : MonoBehaviour
{
    public Camera playerCam;
    public Camera excavatorCam;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();

        if (other == PlayerCollider)
        {
            playerCam.enabled = false;
            excavatorCam.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();

        if (other == PlayerCollider)
        {
            playerCam.enabled = false;
            excavatorCam.enabled = true;
        }
    }
}
