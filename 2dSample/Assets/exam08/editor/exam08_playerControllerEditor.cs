using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Exam08_PlayerContoller))]
public class exam08_playerControllerEditor : Editor
{
    // private void OnEnable()
    // {
    //     // if(SceneView.duringSceneGui != null)
    //     SceneView.duringSceneGui += _OnSceneGUI;
    // }

    
    // // private void OnDisable()
    // // {
    // //     SceneView.duringSceneGui += _OnSceneGUI;
    // // }
    
    // private void _OnSceneGUI(SceneView view)
    // {
    //     Exam08_PlayerContoller playerController = (Exam08_PlayerContoller)target;

    //     CapsuleCollider2D capsuleCollider = playerController.GetComponent<CapsuleCollider2D>();
    //     if (capsuleCollider != null)
    //     {
    //         // 캡슐 콜라이더의 중심 위치와 크기 정보
    //         Vector3 colliderCenter = capsuleCollider.bounds.center;
    //         Vector3 colliderSize = capsuleCollider.size;
    //         float colliderRadius = capsuleCollider.size.x / 2;
    //         float colliderHeight = capsuleCollider.size.y - (2 * colliderRadius);

    //         // 캡슐 콜라이더의 색상 및 스타일 설정
    //         Handles.color = Color.yellow;

    //         // 캡슐 콜라이더의 상단과 하단 원 부분 그리기
    //         Handles.DrawWireArc(colliderCenter + Vector3.up * (colliderHeight / 2), Vector3.forward, Vector3.left, -180, colliderRadius);
    //         Handles.DrawWireArc(colliderCenter - Vector3.up * (colliderHeight / 2), Vector3.forward, Vector3.left, 180, colliderRadius);

    //         // 캡슐 콜라이더의 원통 부분 그리기
    //         Handles.DrawLine(colliderCenter + Vector3.left * colliderRadius + Vector3.up * (colliderHeight / 2), colliderCenter + Vector3.left * colliderRadius - Vector3.up * (colliderHeight / 2));
    //         Handles.DrawLine(colliderCenter + Vector3.right * colliderRadius + Vector3.up * (colliderHeight / 2), colliderCenter + Vector3.right * colliderRadius - Vector3.up * (colliderHeight / 2));

            

    //     }
    // }

    public override void OnInspectorGUI()
    {
        Exam08_PlayerContoller playerController = (Exam08_PlayerContoller)target;

        // playerController.speed = EditorGUILayout.FloatField("Speed", playerController.speed);
        // playerController.jumpForce = EditorGUILayout.FloatField("Jump Force", playerController.jumpForce);
        // playerController.jumpCount = EditorGUILayout.IntField("Jump Count", playerController.jumpCount);
        // playerController.jumpDelay = EditorGUILayout.FloatField("Jump Delay", playerController.jumpDelay);

        // if (GUILayout.Button("Reset"))
        // {
        //     playerController.speed = 5.0f;
        //     playerController.jumpForce = 5.0f;
        //     playerController.jumpCount = 2;
        //     playerController.jumpDelay = 0.5f;
        // }
    }


}
