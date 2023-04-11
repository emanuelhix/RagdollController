using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float MIN_ANGLE_Y = -35;
    public float MAX_ANGLE_Y = 60;

    public float rotationSpeed = 1;
    public Transform cameraAnchor;
    float mouseX;
    float mouseY;
    public float lowerTorsoOffset;
    public ConfigurableJoint hipJoint;
    public ConfigurableJoint lowerTorsoJoint;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        mouseX += -Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, MIN_ANGLE_Y, MAX_ANGLE_Y);
        updateCamera(mouseX, mouseY);
        updateCharacter(mouseX, mouseY);
    }

    private void updateCamera(float mouseX, float mouseY)
    {
        // rotate the cam anchor, which in turns rotates the camera
        Quaternion cameraAnchorRotation = Quaternion.Euler(mouseY, -mouseX, 0);
        cameraAnchor.rotation = cameraAnchorRotation;
    }

    private void updateCharacter(float mouseX, float mouseY)
    {
        hipJoint.targetRotation = Quaternion.Euler(0, mouseX, 0);
        lowerTorsoJoint.targetRotation = Quaternion.Euler(-mouseY + lowerTorsoOffset, 0, 0);
    }
}