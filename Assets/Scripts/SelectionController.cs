using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField]
    private GameObject objectSelected;

    public void SetSelectedObject(GameObject obj) => objectSelected = obj;
}
