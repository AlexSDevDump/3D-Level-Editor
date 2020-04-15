using UnityEngine;
using UnityEngine.UI;

public class UIScaleSetting : MonoBehaviour
{
    public Vector3 scale;
    private SelectionController sc;

    [SerializeField]
    private InputField xInput;
    [SerializeField]
    private InputField yInput;
    [SerializeField]
    private InputField zInput;

    // Start is called before the first frame update
    void Start()
    {
        sc = FindObjectOfType<SelectionController>();
        scale = Vector3.one;
    }

    public void UpdateX()
    {
        int x = int.Parse(xInput.text);
        scale.x = x;
        UpdateScale();

    }
    public void UpdateY()
    {
        int y = int.Parse(yInput.text);
        scale.y = y;
        UpdateScale();

    }
    public void UpdateZ()
    {
        int z = int.Parse(zInput.text);
        scale.z = z;
        UpdateScale();
    }

    private void UpdateScale()
    {
        sc.GetSelectedObject.transform.localScale = scale;
    }
}
