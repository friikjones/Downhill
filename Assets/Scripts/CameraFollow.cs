using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private GameObject target;
    [SerializeField] private float cameraSpeed;

    void Start()
    {
        offset = this.transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * cameraSpeed);
        // transform.Translate((target.transform.position+offset) - transform.position * Time.deltaTime);
        // transform.position = target.transform.position + offset;
    }
}
