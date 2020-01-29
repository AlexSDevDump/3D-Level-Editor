using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField]
    private GameObject objectSelected;

    [SerializeField]
    private float stepMod;

    private bool isArrowKeyDown = false;

    public enum TransformState
    {
        Rotation,
        Translation,
        Scale,
    }

    public TransformState state;

    void Start()
    {
        state = TransformState.Translation;
    }

    public void SetSelectedObject(GameObject obj) => objectSelected = obj;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { state = TransformState.Rotation; }
        if (Input.GetKeyDown(KeyCode.T)) { state = TransformState.Translation; }
        if (Input.GetKeyDown(KeyCode.Y)) { state = TransformState.Scale; }

        if (objectSelected != null)
        {
            Vector2 arrowInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if(arrowInput != Vector2.zero)
            {
                if(isArrowKeyDown == false)
                {
                    objectSelected.GetComponent<TranslateObject>().StepInput(arrowInput * stepMod);
                    isArrowKeyDown = true;
                }
            }     
            else { isArrowKeyDown = false; }
        }
    }
}
