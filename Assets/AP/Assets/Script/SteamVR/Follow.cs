// Description : Cam_Follow.cs : use on camera to follow the player character
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    
	public Transform 	target;

    void Update()
    {
        if(target != null){
            transform.position = target.position;
        }
    }
}
