using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    private float mouseX;
    private float mouseY;
    private float mouseZ;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);
        transform.LookAt(target.transform);

        mouseX = Input.GetAxis("Mouse X") / 200;
        mouseY = Input.GetAxis("Mouse Y") / 200;
        mouseZ = Input.GetAxis("Scroll Wheel");

        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.Euler(0, mouseX, 0) * offset;
        }

        float angleBetween = Vector3.Angle(Vector3.up, transform.forward);

        if (((angleBetween > 100) && (mouseY < 0)) || ((angleBetween < 150) && (mouseY > 0)))
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 LocalRight = target.transform.worldToLocalMatrix.MultiplyVector(transform.right);
                offset = Quaternion.AngleAxis(mouseY, LocalRight) * offset;
            }
        }

        float dist = Vector3.Distance(target.transform.position, transform.position);

        if (dist < 7)
        {
            if (mouseZ < 0)
            {
                offset = Vector3.Scale(offset, new Vector3(1.05f, 1.05f, 1.05f));
            }
        }

        if (dist > 0.8)
        {
            if (mouseZ > 0)
            {
                offset = Vector3.Scale(offset, new Vector3(0.95f, 0.95f, 0.96f));
            }
        }





    }
}