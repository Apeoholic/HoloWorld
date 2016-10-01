using UnityEngine;
using System.Collections;
using UnityEditor;

public static class UnityHelperMenu
{
    [MenuItem("UnityHelpers/Create folder structure", priority = 1)]
    public static void CreateFolderStructure()
    {
        var folders = new string[] {"Scripts","Prefabs","Meshes","Textures","Materials","Sounds","Resources","Scenes" };
        foreach (var f in folders)
        {
            AssetDatabase.CreateFolder("Assets", f);   
        }
    }
}