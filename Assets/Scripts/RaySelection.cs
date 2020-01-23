using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelection : MonoBehaviour
{
    [SerializeField]
    private float rayLength;
    public GameObject Select(Ray rayDirection, LayerMask targetLayer)
    {
        //Selection Logic
        RaycastHit hit;
        Debug.DrawRay(rayDirection.origin, rayDirection.direction * rayLength, Color.red, 1f);

        if (Physics.Raycast(rayDirection, out hit, rayLength, targetLayer))
        {
            Transform objectHit = hit.transform;
            return objectHit.root.gameObject;
        }

        else { return null; }
    }
}

