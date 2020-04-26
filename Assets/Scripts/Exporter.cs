using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Exporter : MonoBehaviour
{
    private string dir;
    private string mapName;
    private string mapPath;
    [SerializeField]
    private string mapObjectsTag;
    // Start is called before the first frame update
    void Start()
    {
        dir = Application.dataPath + "/Map Files/";
    }

    public void ExportMap(string name)
    {
        SetMapName(name);
        CreateMapFile();
        ExportMapObjects();
    }

    void CreateMapFile()
    {
        mapPath = dir + "/" + mapName + ".txt";

        if (!File.Exists(mapPath))
        {
            File.WriteAllText(mapPath, "");
        }
        else
        {
            Debug.Log("MAP ALREADY EXISTS");
        }
    }

    public void SetMapName(string name)
    {
        mapName = name;
    }

    void ExportMapObjects()
    {
        File.WriteAllText(mapPath, "");
        GameObject[] mapObjects = GameObject.FindGameObjectsWithTag(mapObjectsTag);
        foreach (GameObject mapObject in mapObjects)
        {
            AddObject(mapObject);
        }
    }

    void AddObject(GameObject objectToAdd)
    {
        string objectMesh = objectToAdd.GetComponent<MeshFilter>().mesh.ToString();
        objectMesh = objectMesh.Split(' ')[0];
        string objectTexCode = objectToAdd.GetComponent<SelectObject>().GetTextureCode();
        Transform t = objectToAdd.transform;
        string objectPos = t.position.ToString();
        string objectRot = t.rotation.eulerAngles.ToString();
        string objectScale = t.localScale.ToString();

        string contents = objectMesh + "|" + objectPos + "|" + objectRot + "|" + objectScale + "|" + objectTexCode + "\n";
        File.AppendAllText(mapPath, contents);
    }
}
