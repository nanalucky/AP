// Description : infoUI : This script is used to display a UI box that contains infos on screen 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasFollowCamera: MonoBehaviour {

    public float distance = 20.0f;
    private Camera cameraFollow;
    private Matrix4x4 canvasCamMatrix = new Matrix4x4();

	void Awake(){
        cameraFollow = gameObject.GetComponent<Canvas>().worldCamera;
        Matrix4x4 matCanvas = new Matrix4x4();
        Vector3 posCanvas = cameraFollow.transform.position + cameraFollow.transform.forward.normalized * distance;
        matCanvas.SetTRS(posCanvas, gameObject.transform.rotation, gameObject.transform.localScale);
        canvasCamMatrix = cameraFollow.worldToCameraMatrix * matCanvas;
    }

    void Update()
    {
        gameObject.transform.FromMatrix(cameraFollow.cameraToWorldMatrix * canvasCamMatrix);
    }

}
