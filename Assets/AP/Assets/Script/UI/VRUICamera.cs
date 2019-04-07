using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class VRUICamera : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject vrCamera;
    private GameObject uiCamera;
    private Camera comMainCamera;
    private Camera comVRCamera;
    private Camera comUICamera;

    public static bool b_UI = false;


    private void OnEnable()
    {
        b_UI = true;
        mainCamera = GameObject.Find("Main Camera");
        vrCamera = GameObject.Find("VRCamera");
        uiCamera = GameObject.Find("Camera");
        mainCamera.transform.position = vrCamera.transform.position;
        mainCamera.transform.rotation = vrCamera.transform.rotation;
        mainCamera.transform.localScale = vrCamera.transform.localScale;
        comMainCamera = mainCamera.GetComponent<Camera>() as Camera;
        comVRCamera = vrCamera.GetComponent<Camera>() as Camera;
        comUICamera = uiCamera.GetComponent<Camera>() as Camera;
        comMainCamera.enabled = true;
        comMainCamera.CopyFrom(comVRCamera);
        comVRCamera.CopyFrom(comUICamera);

        GameObject grpCanvas = GameObject.Find("Grp_Canvas");
        Player.instance.transform.position = grpCanvas.transform.position;
        Player.instance.transform.rotation = grpCanvas.transform.rotation;
    }

    private void OnDisable()
    {
        //Camera camera = gameObject.GetComponentInParent<Canvas>().worldCamera;
        Player.instance.transform.position = Character.instance.transform.position;
        Player.instance.transform.rotation = Character.instance.transform.rotation;
        comVRCamera.CopyFrom(comMainCamera);
        comMainCamera.enabled = false;
        b_UI = false;
    }
}


