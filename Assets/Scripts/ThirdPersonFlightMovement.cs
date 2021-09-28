using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonFlightMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float flySpeed = 2f;
    public float walkSpeed = 2f;
    public float rotationSpeed = 5000f;
    private bool isFlying = false;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Swap"))
        {
            isFlying = !isFlying;

            if(isFlying)
            {
                GetComponent<Rigidbody>().useGravity = false;
            }
            else
            {
                GetComponent<Rigidbody>().useGravity = true;
            }
        }

        if (isFlying)
        {
            Fly();
        }
        else
        {
            Walk();
        }

    }

    private void Fly()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float rotateLeft = Input.GetAxisRaw("RotateLeft");
        float rotateRight = Input.GetAxisRaw("RotateRight");

        Vector3 rotation = new Vector3(-vertical * rotationSpeed * Time.deltaTime, horizontal * rotationSpeed * Time.deltaTime, (rotateLeft - rotateRight) * rotationSpeed * Time.deltaTime).normalized;

        transform.Rotate(rotation);

        controller.Move(transform.forward * flySpeed * Time.deltaTime);
    }

    private void Walk()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
        }
    }
}
