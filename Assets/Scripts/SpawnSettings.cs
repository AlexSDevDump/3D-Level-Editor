using UnityEngine;

public class SpawnSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    //Rudimentary Shapes
    private Mesh cube;
    private Mesh sphere;
    private Mesh triangle;

    private SpawnObject spawner;

    void Start()
    {
        spawner = FindObjectOfType<SpawnObject>();
    }

    public void SpawnObject(Mesh mesh)
    {
        obj.GetComponent<MeshFilter>().mesh = mesh;
        spawner.SpawnInWorld(obj);
    }

    public void DestroySelectedObject()
    {
        SelectionController sc = FindObjectOfType<SelectionController>();
        Destroy(sc.GetSelectedObject);
        sc.SetSelectedObject(null);
    }
}
