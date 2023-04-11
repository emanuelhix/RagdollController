// Parker Hix
// 11 April 2023
// Limb Collision Script
// This script updates the public member "isGrounded" of the player controller when the ragdoll collides with the floor.
// Each limb of the ragdoll contains this script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerController plrController;

    private void Start()
    {
        plrController = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        plrController.isGrounded = true;
    }
}
