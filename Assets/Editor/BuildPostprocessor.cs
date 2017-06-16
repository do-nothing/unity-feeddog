using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;
using Object = UnityEngine.Object; 

public class BuildPostprocessor
{
    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        //Debug.Log("打包完成 =========================" + pathToBuiltProject);
    }


    [PostProcessSceneAttribute(2)]
    public static void OnPostprocessScene()
    {
        //Debug.Log("开始打包 =========================" );
        AppInfo appInfo = Object.FindObjectOfType<AppInfo>();
        appInfo.buildTagBat();
    }
}
