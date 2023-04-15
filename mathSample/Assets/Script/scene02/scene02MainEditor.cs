using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(scene02Main))]
public class scene02MainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        scene02Main myTarget = (scene02Main)target;

        EditorGUILayout.LabelField("----- This is a custom editor for scene02 -----");

        if (GUILayout.Button("about"))
        {
            //popup message
            EditorUtility.DisplayDialog("About", "This is a custom editor for scene02", "OK");
        }
        if(GUILayout.Button("generate"))
        {
            myTarget.Generate();
        }

        if(GUILayout.Button("clear"))
        {
            myTarget.clearChild();
        }


    }
    
}
