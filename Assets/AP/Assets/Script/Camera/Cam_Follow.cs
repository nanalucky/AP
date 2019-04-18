// Description : Cam_Follow.cs : use on camera to follow the player character
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Follow : MonoBehaviour {
    
	public Transform 	target;


    private void followCamera()
    {
        if (target != null)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }

    private void OnPreCull()
    {
        followCamera();
    }


    private void FixedUpdate()
    {
        followCamera();
    }

    private void Update()
    {
        followCamera();
    }

    void LateUpdate()
    {
        followCamera();
    }
}
