using UnityEngine;
using UnityEditor;
using System.IO;

public class TextureLoader : MonoBehaviour
{
    private string path;
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
        SetObjectToTexture(GetImage(path), FindObjectOfType<SelectionController>().GetSelectedObject, true);
    }

    public Texture2D GetImage(string path)
    {
        if (path != null)
        {
            w = new WWW("file:///" + path);
            return w.texture;
        }
        else
            return null;
    }

    public void SetObjectToTexture(Texture2D tex, GameObject objectToSet, bool usePath)
    {
        GameObject go = objectToSet;
        if (go != null)
        {
            string texCode;
            if (usePath)
            {
                if (!path.Contains(Application.dataPath + "/Texture Files/"))
                {
                    texCode = NewTextureCode();
                    SaveToDisk(tex, texCode);
                }

                else
                {
                    string[] split = path.Split('/');
                    texCode = split[split.Length - 1].Split('.')[0];
                }            
                go.GetComponent<SelectObject>().SetTextureCode(texCode);      
            }

            Material temp = new Material(material);
            temp.SetTexture("_MainTex", tex);
            go.GetComponent<MeshRenderer>().material = temp;
        }
    }

    public void TexButton()
    {
        FileExplorer();
    }

    private void SaveToDisk(Texture2D tex, string texCode)
    {
        var file = tex.EncodeToPNG();
        string newTexCode = texCode + ".png";
        File.WriteAllBytes(Application.dataPath + "/Texture Files/" + newTexCode, file);
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

    private string NewTextureCode()
    {
        string texCode = "";

        for (int i = 0; i < 9; i++)
        {
            texCode += (Random.Range(0, 10)).ToString();
        }

        return texCode;
    }
}
