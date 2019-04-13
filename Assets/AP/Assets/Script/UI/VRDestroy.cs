using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRDestroy : MonoBehaviour
{
    private void Start()
    {
    }

    void OnDestroy()
    {
        Destroy(GameObject.Find("Player"));
    }
}