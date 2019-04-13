// Description : Cam_Follow.cs : use on camera to follow the player character
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Height_Follow_Player : MonoBehaviour {
    
	public Transform 	target;

	
    void Update()
    {
        if (ingameGlobalManager.instance.b_InputIsActivated)
        {
            if (ingameGlobalManager.instance.saveAndLoadManager.b_IngameDataHasBeenLoaded
                && ingameGlobalManager.instance.b_AllowCharacterMovment
                && !ingameGlobalManager.instance.b_Ingame_Pause)
            {
                if (target != null)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, target.localPosition.y, transform.localPosition.z);
                }
            }
        }
    }
}
