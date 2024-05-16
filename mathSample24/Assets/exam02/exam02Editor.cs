using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Exam02))]

public class exam02Editor : Editor
{
    // private void OnEnable()
    // {
    //     SceneView.duringSceneGui += OnSceneGUI;
    // }

    
    // private void OnDisable()
    // {
    //     SceneView.duringSceneGui -= OnSceneGUI;
    // }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Exam02 scr = target as Exam02;

        if (GUILayout.Button("Create Grid Vertices"))
        {
            scr.CreateGridVertices(8, 8, 1.0f);
        }

        if (GUILayout.Button("Create Weight List 1"))
        {
            scr.CreateWeightList_1(8, 8);
        }
    }

    
}

