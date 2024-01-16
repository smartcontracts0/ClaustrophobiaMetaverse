using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    // Variables
    public Transform player; // Reference to the player in the scene
    public float mouseSensitivity = 2f;
    public float moveSpeed = 5f; // Adjust the speed as needed
    float cameraVerticalRotation = 0f;
    //bool lockedCursor = true;

    private bool isMovementEnabled = true;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovementEnabled)
        {
            // Collect Mouse Input
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Rotate the camera around its local X axis
            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

            // Rotate around the y-axis
            player.Rotate(Vector3.up * inputX);

            // Collect Keyboard Input for Movement
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Calculate movement direction
            Vector3 moveDirection = (player.forward * vertical + player.right * horizontal).normalized;

            // Apply movement to the player's position
            player.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    public void DisableMovement()
    {
        // Disable player movement
        moveSpeed = 0f;
    }

    public void EnableMovement()
    {
        // Enable player movement
        moveSpeed = 5f;
    }
}
