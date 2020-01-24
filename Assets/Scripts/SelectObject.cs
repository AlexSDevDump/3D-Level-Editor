using UnityEngine;

public class SelectObject : MonoBehaviour
{
    void OnMouseDown()
    {
        FindObjectOfType<SelectionController>().SetSelectedObject(gameObject);
    }
}
