//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

[RequireComponent( typeof( Interactable ) )]
public class VR_Interact_Event: MonoBehaviour
{

    public SpriteRenderer _renderer;
    public Material matHover;
    public Material matNormal;

    public GameObject objRef;

    private UIVariousFunctions canvas;										// Access gameobject canvas_PlayerInfos


    //-------------------------------------------------
    void Start()
	{
        canvas = ingameGlobalManager.instance.canvasPlayerInfos;
    }


	//-------------------------------------------------
	// Called when a Hand starts hovering over this object
	//-------------------------------------------------
	private void OnHandHoverBegin( Hand hand )
	{
        _renderer.material = matHover;
    }


    //-------------------------------------------------
    // Called when a Hand stops hovering over this object
    //-------------------------------------------------
    private void OnHandHoverEnd( Hand hand )
	{
        _renderer.material = matNormal;
    }


    //-------------------------------------------------
    // Called every Update() while a Hand is hovering over this object
    //-------------------------------------------------
    private void HandHoverUpdate( Hand hand )
	{
        if (hand.uiInteractAction != null && hand.uiInteractAction.GetStateDown(hand.handType))
        {
            Debug.Log("Hand clicked");

            for (var i = 0; i < canvas.objrefList.Count; i++)
            {
                if (objRef == canvas.gameobjectList[i])
                {
                    InputModule.instance.Submit(canvas.objrefList[i]);
                    break;
                }
            }
        }
    }

    public void SetupButton(GameObject newRef)
    {
        objRef = newRef;
        gameObject.GetComponent<Follow>().target = objRef.transform;
    }

}

