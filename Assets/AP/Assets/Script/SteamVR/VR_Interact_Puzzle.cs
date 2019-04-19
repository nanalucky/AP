using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class VR_Interact_Puzzle : MonoBehaviour
{
    private void Start()
    {
        AddInteractable();
    }
    private void OnEnable()
    {
        AddInteractable();
    }

    void AddInteractable()
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>(true);
        foreach(Transform tran in transforms)
        {
            if(tran.gameObject.CompareTag("PuzzleObject") || tran.gameObject.CompareTag("PuzzleRefPosition"))
            {
                Interactable interacable = tran.gameObject.GetComponent<Interactable>();
                if(interacable == null)
                {
                    interacable = tran.gameObject.AddComponent<Interactable>() as Interactable;
                }
            }

        }
    }
}