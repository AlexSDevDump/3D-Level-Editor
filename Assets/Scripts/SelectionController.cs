using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RaySelection))]

public class SelectionController : MonoBehaviour
{
    public GameObject objectSelected;
    public RaySelection rs;
    public Camera cam;
    public LayerMask objectLayer;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rs = GetComponent<RaySelection>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Select") == 1f)
        {
            GameObject os = rs.Select(cam.ScreenPointToRay(Input.mousePosition), objectLayer);
            objectSelected = os;
        }
    }
}
