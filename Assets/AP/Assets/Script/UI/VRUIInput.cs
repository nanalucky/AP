using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class VRUIInput : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;

    private void OnEnable()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += HandlePointerIn;
        laserPointer.PointerOut += HandlePointerOut;
        laserPointer.PointerClick += HandlePointerClick;
    }

    private void OnDisable()
    {
        laserPointer.PointerIn -= HandlePointerIn;
        laserPointer.PointerOut -= HandlePointerOut;
        laserPointer.PointerClick -= HandlePointerClick;
    }

    private void HandlePointerIn(object sender, PointerEventArgs e)
    {
        Button btn = e.target.GetComponent<Button>();
        if(btn != null)
            btn.OnPointerEnter(null);
    }

    private void HandlePointerOut(object sender, PointerEventArgs e)
    {
        Button btn = e.target.GetComponent<Button>();
        if (btn != null)
            btn.OnPointerExit(null);
    }

    private void HandlePointerClick(object sender, PointerEventArgs e)
    {
        Button btn = e.target.GetComponent<Button>();
        if (btn != null)
        {
            BaseEventData data = new BaseEventData(EventSystem.current)
            {
                selectedObject = e.target.gameObject
            };
            ExecuteEvents.Execute(e.target.gameObject, data, ExecuteEvents.submitHandler);
        }
    }
}