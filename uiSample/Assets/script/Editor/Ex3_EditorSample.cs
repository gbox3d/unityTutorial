using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ex3_customEditor))]

public class Ex3_EditorSample : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ex3_customEditor myScript = (ex3_customEditor)target;

        // add label
        GUILayout.Label("Custom Editor Elements");

        if (GUILayout.Button("Hello World"))
        {
            Debug.Log("Hello World");
        }
    }
}

