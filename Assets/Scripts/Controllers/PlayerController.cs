using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    public CharacterController controller;

    public Transform playerBody;
    public Transform cameraBody;

    float xRotation = 0f;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        handleMouseInput();
        handleKeyboardInput();
    }

    public void handleMouseInput()
    {
        if(Input.GetMouseButton(1))
        {
            Debug.Log("Button");
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cameraBody.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        if(Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
        }
       
    }

    public void handleKeyboardInput()
    {
        float y = 0f;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        Vector3 move = transform.right * x + transform.forward * z + transform.up * y;

        controller.Move(move * speed * Time.deltaTime);
    }
}
