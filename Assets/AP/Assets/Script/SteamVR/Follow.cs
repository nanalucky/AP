// Description : Cam_Follow.cs : use on camera to follow the player character
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    
	public Transform target;
    private Transform head;

    private void Start()
    {
        head = (Character.instance.gameObject.GetComponent<characterMovement>() as characterMovement).objCamera;
    }

    void Update()
    {
        if(target != null){
            transform.position = target.position;

            RaycastHit[] hits;
            Vector3 dir = (target.position - head.position).normalized;
            float maxDis = (target.position - head.position).magnitude;
            hits = Physics.RaycastAll(head.position, dir, maxDis);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform == target)
                {
                    transform.position = hit.point;
                    break;
                }
            }
        }
    }
}
