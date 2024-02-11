using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(CharacterController))]

[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour {

public float speed = 6.0f;
public float gravity = -9.8f;
public float jumpHeight = 3.0f;

private CharacterController charController;

private float ySpeed;

void Start() {

    charController = GetComponent<CharacterController>();

}



    void Update() {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        if (charController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = Mathf.Sqrt(2 * jumpHeight * -gravity);
            }
        }
        movement.y = ySpeed;
        ySpeed += gravity * Time.deltaTime;



        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }

}
