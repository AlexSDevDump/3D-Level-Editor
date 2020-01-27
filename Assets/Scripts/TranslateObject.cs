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
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { state = TransformState.Rotation; }
        if (Input.GetKeyDown(KeyCode.T)) { state = TransformState.Translation; }
        if (Input.GetKeyDown(KeyCode.Y)) { state = TransformState.Scale; }
    }

    void OnMouseDown()
    {
        mzCoord = cam.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        currentScale = transform.localScale;
    }

    void OnMouseDrag()
    {
        switch (state)
        {
            case TransformState.Translation:
                PositionDrag();
                break;
            case TransformState.Rotation:
                RotationDrag();
                break;
            case TransformState.Scale:
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
}
