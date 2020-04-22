using UnityEngine;
using UnityEditor;
using System.IO;

public class TextureLoader : MonoBehaviour
{
    string path;
    [SerializeField]
    private Texture2D tex;
    [SerializeField]
    private Material material;
    private WWW w;
    private SelectionController sc;
    private int fileCounter;
    

    void Start()
    {
        sc = FindObjectOfType<SelectionController>();
        DirectoryInfo textureDir = new DirectoryInfo(Application.dataPath + "/Texture Files/");
        fileCounter = CheckFolderSize(textureDir);
    }

    private void FileExplorer()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
    }

    private void GetImage()
    {
        if (path != null)
        {
            w = new WWW("file:///" + path);
            tex = w.texture;
        }
    }

    private void SetObjectToTexture()
    {
        GameObject go = FindObjectOfType<SelectionController>().GetSelectedObject;
        if (go != null)
        {
            Material temp = new Material(material);
            temp.SetTexture("_MainTex", tex);
            go.GetComponent<MeshRenderer>().material = temp;
        }
    }

    public void TexButton()
    {
        FileExplorer();
        GetImage();
        SetObjectToTexture();
        SaveToDisk();
    }

    private void SaveToDisk()
    {
        var file = tex.EncodeToPNG();

        File.WriteAllBytes(Application.dataPath + "/Texture Files/" + fileCounter + ".png", file);
        fileCounter++;
    }

    private int CheckFolderSize(DirectoryInfo dir)
    {
        int i = 0;
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            if (file.Extension.Contains("png"))
                i++;
        }

        return i;
    }
}
