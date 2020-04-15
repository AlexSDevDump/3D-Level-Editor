using UnityEngine;

public class SpawnSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    public void SpawnObject()
    {
        FindObjectOfType<SpawnObject>().SetObject(obj);
        FindObjectOfType<SpawnObject>().SpawnInWorld();
    }
}
