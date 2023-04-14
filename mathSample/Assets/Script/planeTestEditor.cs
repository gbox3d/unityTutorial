using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(planeTest))]
public class planeTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        planeTest myTarget = (planeTest)target;

        EditorGUILayout.LabelField("----- This is a custom editor -----");

        if (GUILayout.Button("calculate"))
        {

            // myTarget.UpdatePlane();
            // Debug.Log($"Button pressed : {myTarget.GetDistanceToTarget()}");

            // myTarget.changeColor();            


        }

        // void OnSceneGUI()
        // {
        //     planeTest myTarget = (planeTest)target;
        //     myTarget.UpdatePlane();
        // }




    }
}
