﻿// Description : infoUI : This script is used to display a UI box that contains infos on screen 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Valve.VR.Extras;

public class VRTeleportPlayer: MonoBehaviour {

    private bool bLastInteractable;

    void Start()
    {
        bLastInteractable = VRUICheckInteractable.IsInteractable();
        teleportPlayer();
    }

    private void LateUpdate()
    {
        if (bLastInteractable != VRUICheckInteractable.IsInteractable())
        {
            bLastInteractable = VRUICheckInteractable.IsInteractable();
            teleportPlayer();
        }
    }

    private void teleportPlayer()
    {
        GameObject gbVRCamera = GameObject.Find("VRCamera");
        GameObject gbCamera = GameObject.Find("Camera");
        GameObject gbMainCamera = GameObject.Find("Main Camera");
        Camera comVRCamra = gbVRCamera.GetComponent<Camera>() as Camera;
        Camera comCamera = gbCamera.GetComponent<Camera>() as Camera;
        Camera comMainCamera = gbMainCamera.GetComponent<Camera>() as Camera;

        if (VRUICheckInteractable.IsInteractable())
        {
            Player.instance.transform.position = gbCamera.transform.position;
            Player.instance.transform.rotation = gbCamera.transform.rotation;
            foreach (Hand _hand in Player.instance.hands)
            {
                SteamVR_LaserPointer laserPointer = _hand.GetComponent<SteamVR_LaserPointer>() as SteamVR_LaserPointer;
                if (laserPointer != null)
                    laserPointer.enabled = true;
            }

            comVRCamra.CopyFrom(comCamera);
            comCamera.enabled = false;
            comMainCamera.enabled = true;
        }
        else
        {
            Player.instance.transform.position = Character.instance.transform.position;
            Player.instance.transform.rotation = Character.instance.transform.rotation;
            foreach (Hand _hand in Player.instance.hands)
            {
                SteamVR_LaserPointer laserPointer = _hand.GetComponent<SteamVR_LaserPointer>() as SteamVR_LaserPointer;
                if (laserPointer != null)
                    laserPointer.enabled = false;
            }

            comVRCamra.CopyFrom(comMainCamera);
            comCamera.enabled = true;
            comMainCamera.enabled = false;
        }
    }
}
