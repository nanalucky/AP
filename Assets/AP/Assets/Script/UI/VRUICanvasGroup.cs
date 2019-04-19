﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRUICanvasGroup : MonoBehaviour
{
    private void Start()
    {
        AddUIItem();
    }
    private void OnEnable()
    {
        AddUIItem();
    }

    void AddUIItem()
    {
        Button[] btns = gameObject.GetComponentsInChildren<Button>(true);
        foreach (Button btn in btns)
        {
            VRUIItem uiitem = btn.gameObject.GetComponent<VRUIItem>();
            if (uiitem == null)
                btn.gameObject.AddComponent<VRUIItem>();
        }
    }
}