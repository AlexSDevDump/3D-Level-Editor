using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UITransformSetting : MonoBehaviour
{
    public Vector3 scale;
    public Vector3 position;
    private SelectionController sc;

    [SerializeField]
    private InputField[] scaleInputs;
    [SerializeField]
    private InputField[] posInputs;

    // Start is called before the first frame update
    void Start()
    {
        sc = FindObjectOfType<SelectionController>();
        scale = Vector3.one;
    }

    public void UpdateX()
    {
        int x = int.Parse(scaleInputs[0].text);
        scale.x = x;
        UpdateScale();

        x = int.Parse(posInputs[0].text);
        position.x = x;
        UpdatePosition();

    }
    public void UpdateY()
    {
        int y = int.Parse(scaleInputs[1].text);
        scale.y = y;
        UpdateScale();

        y = int.Parse(posInputs[1].text);
        position.y = y;
        UpdatePosition();

    }
    public void UpdateZ()
    {
        int z = int.Parse(scaleInputs[2].text);
        scale.z = z;
        UpdateScale();

        z = int.Parse(posInputs[2].text);
        position.z = z;
        UpdatePosition();
    }

    private void UpdateScale()
    {
        if (sc.GetSelectedObject != null)
        {
            sc.GetSelectedObject.transform.localScale = scale;
        }
    }

    private void UpdatePosition()
    {
        if (sc.GetSelectedObject != null)
        {
            sc.GetSelectedObject.transform.position = position;
        }
    }
}
