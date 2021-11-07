using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkOverTime : MonoBehaviour
{
    public float timeOn, timeOff;
    private bool state;
    private float currentTime;

    public Text target1, target2;

    void FixedUpdate()
    {
        EnableStuff();
        currentTime += Time.deltaTime;
        if (state)
        {

            if (currentTime > timeOn)
            {
                state = !state;
                currentTime = 0;
            }
        }
        else
        {
            if (currentTime > timeOff)
            {
                state = !state;
                currentTime = 0;
            }
        }
    }
    void EnableStuff()
    {
        if (state)
        {
            target1.enabled = true;
            target2.enabled = true;
        }
        else
        {
            target1.enabled = false;
            target2.enabled = false;
        }
    }
}
