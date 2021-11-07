using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementMenu : MonoBehaviour
{
    public float maxRotateSpeed, accelSpeed;
    public float rotateSpeed;

    public int direction = 1;
    public float timerTarget;
    public float currentTimer;

    void Update()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer > timerTarget)
        {
            currentTimer = 0;
            timerTarget = Random.Range(1, 20) * .1f + .5f;
            direction = direction * -1;
        }

        this.transform.Rotate(Vector3.forward * direction * RotateSpeed(true));
    }

    float RotateSpeed(bool accelMode)
    {
        if (accelMode == false)
        {
            rotateSpeed = 0;
        }
        if (rotateSpeed < maxRotateSpeed)
        {
            rotateSpeed += accelSpeed;
        }
        return rotateSpeed;

    }
}
