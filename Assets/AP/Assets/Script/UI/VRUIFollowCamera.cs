// Description : infoUI : This script is used to display a UI box that contains infos on screen 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VRUIFollowCamera: MonoBehaviour {

    private float distance = 15.0f;

    private Matrix4x4 matInCam = new Matrix4x4();
    private Camera cameraFollow;

    private void calculateMatInCam()
    {
        cameraFollow = GameObject.Find("VRCamera").GetComponent<Camera>() as Camera;
        Vector3 pos = new Vector3(0.0f, 0.0f, -distance);
        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        matInCam.SetTRS(pos, rot, gameObject.transform.localScale);
    }

    private void Start()
    {
        calculateMatInCam();
    }


    private void OnEnable()
    {
        calculateMatInCam();
    }

    void Update()
    {
        if (cameraFollow == null)
            calculateMatInCam();

        Matrix4x4 matInWorld = cameraFollow.cameraToWorldMatrix * matInCam;
        transform.FromMatrix(matInWorld);
    }

}
