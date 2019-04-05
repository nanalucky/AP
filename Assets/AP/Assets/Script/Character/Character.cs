// Description : Character. Global Manager for the player character
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character : MonoBehaviour {

	public static Character 	instance = null;            // Static instance of GameManager which allows it to be accessed by any other script.

	private characterMovement	charaMovement;				// Access to the characterMovement component
	public AudioSource			voiceOverAudioSource;
    public GameObject           mainCamera;
    public GameObject           VRCamera;

	void Awake()
	{
		if (instance == null)								// Check if instance already exists
			instance = this;								// if not, set instance to this

		else if (instance != this)							// If instance already exists and it's not this:
			Destroy(gameObject);  							// Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
	}


	void Start(){
		if (ingameGlobalManager.instance.b_DesktopInputs) {	// Init all axis
			Input.ResetInputAxes();}

		if (gameObject.GetComponent<characterMovement> ())	// Access to the characterMovement component
			charaMovement = gameObject.GetComponent<characterMovement> ();

        if (ingameGlobalManager.instance.isSteamVR())
            switchtoVRCamera();
        else
            switchtoMainCamera();

		DontDestroyOnLoad (gameObject);						// Don't destroy if a new scene is loaded
	}


	void FixedUpdate () {
        if (ingameGlobalManager.instance.b_InputIsActivated)
        {
            if (ingameGlobalManager.instance.saveAndLoadManager.b_IngameDataHasBeenLoaded
                && ingameGlobalManager.instance.b_AllowCharacterMovment
                && !ingameGlobalManager.instance.b_Ingame_Pause)
            {
                // Character movement
                if (charaMovement)
                    charaMovement.charaGeneralMovementController();
            }
            else{
                if (charaMovement)
                    charaMovement.charaStopMoving();
            }

        }
	}

    public void switchtoMainCamera()
    {
        if (mainCamera != null && VRCamera != null)
        {
            mainCamera.SetActive(true);
            VRCamera.SetActive(false);
        }
    }

    public void switchtoVRCamera()
    {
        if (mainCamera != null && VRCamera != null)
        {
            mainCamera.SetActive(false);
            VRCamera.SetActive(true);
        }
    }

}
