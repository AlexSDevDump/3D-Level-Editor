using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField]
    private GameObject objectSelected;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetSelectedObject(GameObject obj) => objectSelected = obj;
}
