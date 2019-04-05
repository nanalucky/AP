// Description : ingameGlobalManger.cs : Manage the gameobject ingameGlobalManager in scene view. 
// Only one instance of this object can be created in scene. This object brings together elements used by many scripts. 
// Many scripts refer to the information contained in this script.
// From any script you can access this script with : ingameGlobalManager.instance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class ingameSteamVR: MonoBehaviour {

    private DateTime current;

    void Awake()
    {
        current = DateTime.Now;
    }

    void LateUpdate()
    {
        if ((DateTime.Now - current).TotalSeconds > 10)
        {
            ingameGlobalManager.instance.gameObject.GetComponent<ingameSteamVR>().enabled = false;
            ingameGlobalManager.instance.gameObject.GetComponent<SaveAndLoadManager>().EraseAndReplaceSaveSlot(0);
        }
    }

}
