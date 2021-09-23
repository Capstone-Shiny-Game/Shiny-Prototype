using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonFlightMovement : MonoBehaviour
{
    public CharacterController controller;
   
    public float speed = 2f;
    public float rotationSpeed = 5000f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float rotateLeft = Input.GetAxisRaw("RotateLeft");
        float rotateRight = Input.GetAxisRaw("RotateRight");

        Vector3 rotation = new Vector3(-vertical * rotationSpeed * Time.deltaTime, horizontal * rotationSpeed * Time.deltaTime, (rotateLeft-rotateRight) * rotationSpeed * Time.deltaTime).normalized;

        transform.Rotate(rotation);

        controller.Move(transform.forward * speed * Time.deltaTime);
    }
}
