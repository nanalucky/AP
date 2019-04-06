using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

[RequireComponent(typeof(Button))]
public class VRUIItem : MonoBehaviour
{
    private Button btn;

    private void OnEnable()
    {
        btn = GetComponent<Button>();
        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider>() as BoxCollider;
            Rect rect = btn.GetComponent<RectTransform>().rect;
            collider.size = new Vector3(rect.width, rect.height, 10.0f);
        }
    }
}