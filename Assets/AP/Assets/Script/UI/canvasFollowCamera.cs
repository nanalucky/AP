// Description : infoUI : This script is used to display a UI box that contains infos on screen 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasFollowCamera: MonoBehaviour {

    private Camera cameraFollow;
    private Matrix4x4 canvasCamMatrix;

	void Awake(){
        cameraFollow = gameObject.GetComponent<Canvas>().worldCamera;
        canvasCamMatrix = cameraFollow.worldToCameraMatrix * gameObject.transform.localToWorldMatrix;
	}

    void Update()
    {
        gameObject.transform.FromMatrix(cameraFollow.cameraToWorldMatrix * canvasCamMatrix);
    }

}
