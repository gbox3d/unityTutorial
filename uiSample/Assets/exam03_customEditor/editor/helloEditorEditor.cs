using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(helloEditor))]

public class helloEditorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        helloEditor myScript = (helloEditor)target;

        // add label
        GUILayout.Label("Custom Editor Elements");

        if (GUILayout.Button("Hello World"))
        {
            Debug.Log("Hello World");
        }

        if(GUILayout.Button("This is test read , write data")) {
            myScript.myString = "Hello, World! " + myScript.strName ;
            Debug.Log(myScript.myString);
        }
    }
    
}
