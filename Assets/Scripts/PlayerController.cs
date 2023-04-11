// Parker Hix
// 11 April 2023
// Ragdoll Character Controller 
// Concept and some code taken from: https://www.youtube.com/playlist?list=PL9gnJgSxuivEf8D6upAd5aNj6H4OFWt4m)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;
    public float sprintMultiplier;
    public Rigidbody characterHip;
    public bool isGrounded;

    private Vector3 calcSprintForce(float speed, float sprintMultiplier, float strafeSpeed, Transform hipTransform)
    {
        Vector3 force = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            // when the player is holding shift, allow them to run
            if (Input.GetKey(KeyCode.LeftShift))
            {
                force = hipTransform.forward * speed * sprintMultiplier;
            } else
            {
                force = hipTransform.forward * speed;
            }
        } 

        if (Input.GetKey(KeyCode.A))
        {
            force = -hipTransform.right * strafeSpeed;
        } 
        
        if (Input.GetKey(KeyCode.S))
        {
            force = -hipTransform.forward * speed;
        } 
        
        if (Input.GetKey(KeyCode.D))
        {
            force = hipTransform.right * strafeSpeed;
        }

        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                force = new Vector3(0, jumpForce, 0);
                isGrounded = false;
            }
        }
        return force;
    }

    private void Start()
    {
        characterHip = this.GetComponent<Rigidbody>();   
    }

    private void FixedUpdate()
    {
        Vector3 sprintForce = calcSprintForce(speed, sprintMultiplier, strafeSpeed, characterHip.transform);
        characterHip.AddForce(sprintForce);
    }
}
