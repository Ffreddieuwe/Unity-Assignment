using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target;


    private void LateUpdate()
    {
        transform.LookAt(target.transform);
    }
}
