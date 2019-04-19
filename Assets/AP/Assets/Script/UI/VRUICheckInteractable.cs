// Description : infoUI : This script is used to display a UI box that contains infos on screen 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VRUICheckInteractable: MonoBehaviour {

    private bool b_Interactable = false;

    private void Start()
    {
    }


    void LateUpdate()
    {
        checkInteractable();
    }

    private void checkInteractable()
    {
        b_Interactable = false;
        Button[] btns = gameObject.GetComponentsInChildren<Button>();
        if (btns.Length > 0)
        {
            foreach (Button btn in btns)
            {
                if (btn.gameObject.transform.parent.gameObject.name == "Canvas_PlayerInfos")  // Rule out btn_check, btn_interact, btn_puzzle...
                    continue;

                b_Interactable = true;
                break;
            }
        }
    }

    public bool bInteractable()
    {
        return b_Interactable;
    }

    static public bool IsInteractable()
    {
        GameObject grpCanvas = GameObject.Find("Grp_Canvas");
        if (grpCanvas)
        {
            VRUICheckInteractable check = grpCanvas.GetComponent<VRUICheckInteractable>() as VRUICheckInteractable;
            if (check)
                return check.bInteractable();
        }
        return true;
    }

}
