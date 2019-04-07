using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRDestroy : MonoBehaviour
{
    void OnDestroy()
    {
        Destroy(GameObject.Find("Player"));
    }
}