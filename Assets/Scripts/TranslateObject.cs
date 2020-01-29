using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObject : MonoBehaviour
{
    public float rotationSpeedMod;
    public float scaleSpeedMod;
    private Vector3 mOffset;
    private Vector3 currentScale;
    private float mzCoord;
    private Camera cam;
    private SelectionController sel;

    void Start()
    {
        sel = FindObjectOfType<SelectionController>();
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        mzCoord = cam.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        currentScale = transform.localScale;
    }

    void OnMouseDrag()
    {
        switch (sel.state)
        {
            case SelectionController.TransformState.Translation:
                PositionDrag();
                break;
            case SelectionController.TransformState.Rotation:
                RotationDrag();
                break;
            case SelectionController.TransformState.Scale:
                ScaleDrag();
                break;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mzCoord;
        return cam.ScreenToWorldPoint(mousePos);
    }

    private void PositionDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }    
    
    private void RotationDrag()
    {
        float rotX = (GetMouseWorldPos().y - transform.position.y)  / rotationSpeedMod;
        float rotY = (-GetMouseWorldPos().x + transform.position.x)  / rotationSpeedMod;
        transform.Rotate(rotX, rotY, 0, Space.World);
    }    
    
    private void ScaleDrag()
    {
        float scale = Mathf.Clamp((GetMouseWorldPos().x - transform.position.x) / scaleSpeedMod, 0.2f - currentScale.x, Mathf.Infinity);

        transform.localScale = new Vector3(scale, scale, scale) + currentScale; 
    }

    public void StepInput(Vector2 step)
    {
        switch (sel.state)
        {
            case SelectionController.TransformState.Translation:
                PositionStep(step);
                break;
            case SelectionController.TransformState.Rotation:
                RotationStep(step);
                break;
            case SelectionController.TransformState.Scale:
                ScaleStep(step);
                break;
        }
    }

    private void PositionStep(Vector2 stepP)
    {
        transform.position += (Vector3)stepP;
    }

    private void RotationStep(Vector2 stepR)
    {

    }

    private void ScaleStep(Vector2 stepS)
    {

    }
}