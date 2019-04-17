// Desciption : deactivateOnStart : Deactivate the object that contains this script on Awake.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimator : MonoBehaviour
{
    public Vector3 vecTargetScale = new Vector3(0, 0, 0);

    public float iconScaleSpeed;                                     // icon scale speed
    public float iconCurrentScale;                                   // icon current scale
    public AnimationCurve iconCurveSpeed;                                         // icon scale speed

    private void Awake()
    {
        vecTargetScale = transform.localScale;
    }

    private void OnEnable()
    {
        iconCurrentScale = 0.0f;
        transform.localScale = new Vector3(0, 0, 0);
    }


    private void Start()
    {
        iconScaleSpeed = ingameGlobalManager.instance.canvasPlayerInfos.iconScaleSpeed;
        iconCurveSpeed = ingameGlobalManager.instance.canvasPlayerInfos.iconCurveSpeed;
    }

    private void OnDisable()
    {
        transform.localScale = vecTargetScale;
    }

    //Orient the camera after all movement is completed this frame to avoid jittering
    void Update()
    {
        if(iconCurrentScale < 1)
        {
            iconCurrentScale = Mathf.MoveTowards(iconCurrentScale, 1, iconScaleSpeed * Time.deltaTime);
            gameObject.transform.localScale = Vector3.MoveTowards(transform.localScale, vecTargetScale, iconCurveSpeed.Evaluate(iconCurrentScale) * iconScaleSpeed * Time.deltaTime);
        }
    }
}
