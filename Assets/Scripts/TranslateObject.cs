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
        Vector3 positionRounded = GetMouseWorldPos() + mOffset;
        positionRounded = positionRounded.Round(0);
        transform.position = positionRounded;
    }    
    
    private void RotationDrag()
    {
        float rotX = (GetMouseWorldPos().y - transform.position.y)  / rotationSpeedMod;
        float rotY = (-GetMouseWorldPos().x + transform.position.x)  / rotationSpeedMod;
        transform.Rotate(rotX, rotY, 0, Space.World);
        Vector3 rotationRounded = transform.rotation.eulerAngles.Round(0);
        transform.rotation = Quaternion.Euler(rotationRounded);
    }    
    
    private void ScaleDrag()
    {
        float scale = Mathf.Clamp((GetMouseWorldPos().x - transform.position.x) / scaleSpeedMod, 0.2f - currentScale.x, Mathf.Infinity);
        Vector3 dragScaleRounded = Vector3.Scale(new Vector3(scale, scale, scale),  currentScale);
        dragScaleRounded = dragScaleRounded.Round(0);

        if (dragScaleRounded == Vector3.zero)
            dragScaleRounded = Vector3.one;
        transform.localScale = dragScaleRounded;
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

static class ExtensionMethods
{
    /// <summary>
    /// Rounds Vector3.
    /// </summary>
    /// <param name="vector3"></param>
    /// <param name="decimalPlaces"></param>
    /// <returns></returns>
    public static Vector3 Round(this Vector3 vector3, int decimalPlaces = 2)
    {
        float multiplier = 1;
        for (int i = 0; i < decimalPlaces; i++)
        {
            multiplier *= 10f;
        }
        return new Vector3(
            Mathf.Round(vector3.x * multiplier) / multiplier,
            Mathf.Round(vector3.y * multiplier) / multiplier,
            Mathf.Round(vector3.z * multiplier) / multiplier);
    }
}