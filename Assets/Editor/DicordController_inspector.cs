using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
 
 

 

[CustomEditor(typeof(DiscordController))]
 public class DicordController_inspector : Editor
{

    
    public override void OnInspectorGUI()
    {
        DiscordController Script = (DiscordController)target;
       
       
    //    DrawDefaultInspector();

        GUILayout.BeginHorizontal();
        GUILayout.Label("GET:" ,  GUILayout.Width(50));
        Script.getUrl = GUILayout.TextField(Script.getUrl, GUILayout.Width(800));
        GUILayout.EndHorizontal();
        if (GUILayout.Button( "GET" , GUILayout.Width(100), GUILayout.Height(30)))
        {
            Script.Button_GetRequest(Script.getUrl);
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label("Post:", GUILayout.Width(50));
        Script.postUrl = GUILayout.TextField(Script.postUrl, GUILayout.Width(800));
        GUILayout.EndHorizontal();
        if (GUILayout.Button("POST", GUILayout.Width(100), GUILayout.Height(30)))
        {
            Script.Button_postRequest(Script.postUrl);
        }



    }
}
