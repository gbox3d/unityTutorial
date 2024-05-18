using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(exam03))]
public class exam03Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        exam03 script = target as exam03;

        if (GUILayout.Button("Create Grid Vertices"))
        {
            script.CreateGridVertices(2, 8, 1.0f);
        }
    }
   
}
