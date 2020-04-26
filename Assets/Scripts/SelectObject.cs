using UnityEngine;

public class SelectObject : MonoBehaviour
{
    [SerializeField]
    private string textureCode;
    public void SetTextureCode(string texCode) => textureCode = texCode;
    public string GetTextureCode() => textureCode;
    void OnMouseDown()
    {
        FindObjectOfType<SelectionController>().SetSelectedObject(gameObject);
    }
}
