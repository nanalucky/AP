// Description : Cam_Follow.cs : use on camera to follow the player character
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AP_Cam_Follow : MonoBehaviour {
    
	public Transform 	target;
	public float 		rotationDamping = 15;


    private void followVRCamera()
    {
        if (ingameGlobalManager.instance.isSteamVR())
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }

    private void OnPreCull()
    {
        followVRCamera();
    }


    private void FixedUpdate()
    {
        followVRCamera();
    }

    private void Update()
    {
        followVRCamera();
    }

    void LateUpdate()
    {
        if(target != null){

            if (ingameGlobalManager.instance.isSteamVR())
            {
                followVRCamera();
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * rotationDamping);
                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * rotationDamping);
            }

        }
      
    }
}
