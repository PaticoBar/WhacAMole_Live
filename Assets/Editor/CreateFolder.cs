using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class CreateFolder : Editor
{
    [MenuItem("±à¼­Æ÷ÍØÕ¹/CreateFolder")]
    private static void CreateMyFolder()
    {
        string path = Application.dataPath + "/";

        Directory.CreateDirectory(path + "Resources");   
        Directory.CreateDirectory(path + "Resources"+"/Prefabs");   
        Directory.CreateDirectory(path + "Prefabs");   
        Directory.CreateDirectory(path + "Editor");   
        Directory.CreateDirectory(path + "Scripts");   
        Directory.CreateDirectory(path + "StreamingAssets");   
        Directory.CreateDirectory(path + "Plugins");

        AssetDatabase.Refresh();
    }
}
