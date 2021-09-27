using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonFlightMovement : MonoBehaviour
{
    public CharacterController controller;    

    public float speed = 2f;
    public float walkSpeed = 500f;
    public float rotationSpeed = 5000f;
    private bool isFlying = false;
    private Quaternion startingRotation;

    void Start()
    {
        startingRotation = transform.rotation;
    }


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
                transform.rotation = startingRotation;
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

        controller.Move(transform.forward * speed * Time.deltaTime);
    }

    private void Walk()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(-horizontal, 0f, -vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction * walkSpeed * Time.deltaTime);
        }
    }
}
