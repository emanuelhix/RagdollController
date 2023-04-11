// Parker H
// 11 April 2023
// This script creates a ragdoll effect by pressing r. The effect is disabled by jumping.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRagdoll : MonoBehaviour
{
    public bool isRagdolled;
    public ConfigurableJoint joint;
    public float platformStandIntensityMin = 15; // closer to zero means skeleton will be looser
    public float platformStandIntensityMax = 750; // closer to infinity means skeleton will be stiffer

    private void Start()
    {
       joint = this.GetComponent<ConfigurableJoint>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (!isRagdolled)
            {
                isRagdolled = true;
                joint.angularYZDrive = new JointDrive()
                {
                    maximumForce = 3.402823e+38F,
                    positionDamper = 0,
                    positionSpring = platformStandIntensityMin,
                };
                joint.angularXDrive = new JointDrive()
                {
                    maximumForce = 3.402823e+38F,
                    positionDamper = 0,
                    positionSpring = platformStandIntensityMin,
                };
            }
        }

        if (Input.GetAxis("Jump") > 0)
        {
            if (isRagdolled)
            {
                isRagdolled = false;
                joint.angularYZDrive = new JointDrive()
                {
                    maximumForce = 3.402823e+38F,
                    positionDamper = 0,
                    positionSpring = platformStandIntensityMax,
                };
                joint.angularXDrive = new JointDrive()
                {
                    maximumForce = 3.402823e+38F,
                    positionDamper = 0,
                    positionSpring = platformStandIntensityMax,
                };
            }
        }
    }
}
