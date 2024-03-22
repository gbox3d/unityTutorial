using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(testCustom))]
public class testCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        testCustom myTarget = (testCustom)target;
        
        EditorGUILayout.LabelField("----- This is a custom editor -----");

        myTarget.testInt = EditorGUILayout.IntField("Test Int", myTarget.testInt);
        myTarget.testFloat = EditorGUILayout.Slider("Test Float", myTarget.testFloat, 0.0f, 10.0f);

        EditorGUILayout.HelpBox("This is a help box", MessageType.Info);

        if(GUILayout.Button("This is a button")) {
            Debug.Log("Button pressed");

            myTarget.GenColor();
        }

        GUILayout.Label("Oscillates around a base size.");
        myTarget.baseSize = EditorGUILayout.Slider("Base Size", myTarget.baseSize, 0.0f, 10.0f);

        myTarget.transform.localScale = Vector3.one * myTarget.baseSize;

    }

}
