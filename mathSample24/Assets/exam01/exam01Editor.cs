using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(exam01))]
public class exam01Editor : Editor
{
    // void OnSceneGUI() {
    //     exam01 script = (exam01)target;
    //     Handles.color = Color.red;
    //     Handles.DrawWireDisc(script.transform.position, Vector3.up, 1.0f);

    //     Handles.color = Color.blue;
    //     Handles.DrawLine(script.transform.position, script.target1.transform.position);

    //     Handles.color = Color.green;
    //     Handles.DrawLine(script.target1.transform.position, script.target2.transform.position);
    // }

    public override void OnInspectorGUI() {
        exam01 script = (exam01)target;

        base.OnInspectorGUI();

        if(GUILayout.Button("make transform")) {


            Matrix4x4 target2Matrix = script.target2.transform.localToWorldMatrix;

            //행렬 만들기
            Vector3 _pos = script.targetPosition;
            Vector3 _rot = script.targetEulerAngle;

            Quaternion _quat = Quaternion.Euler(_rot);

            Matrix4x4 matrix = Matrix4x4.TRS(_pos, _quat, Vector3.one);
            script.matrixOutput = matrix;

            //apply matrix target1
            Matrix4x4 _mat = matrix;
            // _mat =  matrix * _mat;
            // _mat = target2Matrix * _mat;

            script.target1.transform.position = _mat.GetColumn(3);
            script.target1.transform.rotation = Quaternion.LookRotation(
                _mat.GetColumn(2), //forward
                _mat.GetColumn(1) //up
                );
            
            
        }


        // (GameObject)EditorGUILayout.ObjectField("Target1", , typeof(GameObject), true);
        // (GameObject)EditorGUILayout.ObjectField("Target2", , typeof(GameObject), true);

        // GUILayout.TextField("Target1 Position: " + script.target1.transform.position);

        //get position button
        // if (GUILayout.Button("Get Position")) {
        //     Debug.Log("Target1 Position: " + script.target1.transform.position);

        //     // Debug.Log("Target2 Position: " + script.target2.transform.position);
        // }

    }

    
    
}
