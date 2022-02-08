using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReopenProject 
{
    [MenuItem("编辑器拓展/ReopenProject &r")]
    static void DoRepenProject()
    {
        EditorApplication.OpenProject(Application.dataPath.Replace("Assets", string.Empty));
    }
}
