using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    public Rigidbody rb;
    public FixedJoystick joystick;

    //Movement Variables
    public float accel, maxSpeed, gravityForce;
    public Vector3 movementVector;
    public float dragOnGround, dragOnAir;
    public bool grounded, liveInput;

    private float verticalInput, horizontalInput;

    //Ground finding
    public LayerMask whatIsGround;
    public float groundRayLength = .75f;
    public Transform groundRayPoint;


    void Start() {

        rb.transform.parent = null;


    }

    void Update() {
        GetInputs();
        transform.position = rb.transform.position;
        if (liveInput)
            transform.LookAt(transform.position - movementVector);
    }


    void FixedUpdate() {
        grounded = true;
        rb.drag = dragOnGround;

        if (liveInput && rb.velocity.magnitude < maxSpeed) {
            rb.AddForce(movementVector * accel * 1000f);
        }
    }

    void GetInputs() {
        liveInput = false;
        verticalInput = -joystick.Vertical;
        horizontalInput = -joystick.Horizontal;

        if (verticalInput + horizontalInput != 0) {
            liveInput = true;
            movementVector = new Vector3(horizontalInput, 0f, verticalInput);
        }
    }

    //TODO
    // make jump drag thingy
    // raycast grounded
}
