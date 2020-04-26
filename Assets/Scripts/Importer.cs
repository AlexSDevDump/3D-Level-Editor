using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class Importer : MonoBehaviour
{
    private string mapDir;
    private string[] mapObjects;
    [SerializeField]
    private GameObject baseObject;

    // Start is called before the first frame update
    void Start()
    {
        mapDir = Application.dataPath + "/Map Files/";
        ImportMap("test");
    }

    // Update is called once per frame
    public void ImportMap(string mapName)
    {
        mapObjects = File.ReadAllLines(mapDir + "/" + mapName + ".txt");
        
        foreach (string mapObject in mapObjects)
        {
            ImportObject(mapObject);
        }
    }

    private void ImportObject(string objectToImport)
    {
        string[] objectData = objectToImport.Split('|');

        GameObject go = Instantiate(baseObject);
        go.GetComponent<MeshFilter>().mesh = FindMesh(objectData[0]);
        TextureLoader tl = FindObjectOfType<TextureLoader>();
        tl.SetObjectToTexture(tl.GetImage(Application.dataPath + "/Texture Files/" + objectData[4] + ".png"), go, false);
        go.GetComponent<SelectObject>().SetTextureCode(objectData[4]);

        go.transform.position = ParseVector3(objectData[1]);
        go.transform.eulerAngles = ParseVector3(objectData[2]);
        go.transform.localScale = ParseVector3(objectData[3]);
    }

    private Mesh FindMesh(string meshName)
    {
        Mesh mesh = (Mesh)AssetDatabase.LoadAssetAtPath("Assets/Meshes/" + meshName + ".asset", typeof(Mesh));
        if (mesh == null)
        {
            mesh = (Mesh)AssetDatabase.LoadAssetAtPath("Assets/Meshes/Cube.asset", typeof(Mesh));
        }
        return mesh;
    }

    private Vector3 ParseVector3(string vectorToParse)
    {
        if (vectorToParse.StartsWith("(") && vectorToParse.EndsWith (")"))
        {
            vectorToParse = vectorToParse.Substring(1, vectorToParse.Length - 2);
        }

        string[] floats = vectorToParse.Split(',');
        Vector3 vec;
        vec.x = float.Parse(floats[0]);
        vec.y = float.Parse(floats[1]);
        vec.z = float.Parse(floats[2]);

        return vec;
    }
}
