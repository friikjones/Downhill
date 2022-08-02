using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private GameObject target;
    [SerializeField] private float cameraSpeed, cameraRotateSpeed, cameraRotateAmount;
    [SerializeField] private Quaternion initAngle;

    void Start()
    {
        offset = this.transform.position;
        initAngle = this.transform.rotation;
    }

    void Update()
    {
        //TODO add rotation to offset
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * cameraSpeed);
        // transform.Translate((target.transform.position+offset) - transform.position * Time.deltaTime);
        // transform.position = target.transform.position + offset;


        float cameraRotateTarget = 0;
        if (target.GetComponent<PlayerControllerScript>().horizontalInput > 0.1f)
        {
            cameraRotateTarget = -cameraRotateAmount;
        }
        else if (target.GetComponent<PlayerControllerScript>().horizontalInput < -0.1f)
        {
            cameraRotateTarget = cameraRotateAmount;
        }
        Quaternion rotationTarget = Quaternion.Euler(new Vector3(0, cameraRotateTarget, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget * initAngle, Time.deltaTime * cameraRotateSpeed);
        // Vector3.Lerp(initAngle, initAngle + rotationTarget, Time.deltaTime)));
    }
}
