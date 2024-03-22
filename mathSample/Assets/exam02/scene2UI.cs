using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System;

public class scene2UI : MonoBehaviour
{
    [SerializeField] private Button btn_Sine;
    [SerializeField] private Button btn_Cosine;
    [SerializeField] private Button btn_Triangle;
    [SerializeField] private Button btn_Square;

    // Start is called before the first frame update
    void Start()
    {
        btn_Sine.onClick.AddListener(() =>
        {
            // 라인 GameObject를 생성하고 속성을 설정합니다.
            GameObject lineGameObject = new GameObject("SineGraph");
            LineRenderer lineRenderer = lineGameObject.AddComponent<LineRenderer>();

            // 선의 두께 설정
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;

            // 선의 색상 설정
            lineRenderer.startColor = Color.blue;
            lineRenderer.endColor = Color.blue;

            // 메터리얼과 셰이더 설정
            lineRenderer.material = new Material(Shader.Find("Unlit/Color")); 
            lineRenderer.material.color = Color.blue;

            // 사인 그래프를 그리기 위한 점들을 계산
            int pointsCount = 100; // 그래프에 사용할 점의 개수
            float xRange = MathF.PI * 2; // x축 범위
            Vector3[] points = new Vector3[pointsCount];

            for (int i = 0; i < pointsCount; i++)
            {
                float x = (i / (float)pointsCount) * xRange;
                float y = Mathf.Sin(x);
                points[i] = new Vector3(x - Mathf.PI, y, 0);
            } 

            // LineRenderer에 점 설정
            lineRenderer.positionCount = pointsCount;
            lineRenderer.SetPositions(points);

        });

        btn_Cosine.onClick.AddListener(()=> {

            // 라인 GameObject를 생성하고 속성을 설정합니다.
            GameObject lineGameObject = new GameObject("SineGraph");
            LineRenderer lineRenderer = lineGameObject.AddComponent<LineRenderer>();

            // 선의 두께 설정
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;

            // 선의 색상 설정
            // lineRenderer.startColor = Color.red;
            // lineRenderer.endColor = Color.red;

            // 메터리얼과 셰이더 설정
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
            lineRenderer.material.color = Color.red;

            // 사인 그래프를 그리기 위한 점들을 계산
            int pointsCount = 100; // 그래프에 사용할 점의 개수
            float xRange = MathF.PI * 2; // x축 범위
            Vector3[] points = new Vector3[pointsCount];

            for (int i = 0; i < pointsCount; i++)
            {
                float x = (i / (float)pointsCount) * xRange;
                float y = Mathf.Cos(x);
                points[i] = new Vector3(x - Mathf.PI, y, 0);
            }

            // LineRenderer에 점 설정
            lineRenderer.positionCount = pointsCount;
            lineRenderer.SetPositions(points);


        });

        btn_Triangle.onClick.AddListener(() =>
        {
            // 삼각형 GameObject를 생성하고 속성을 설정합니다.
            GameObject triangle = new GameObject("Triangle");

            // 위치, 크기, 회전 설정
            triangle.transform.position = new Vector3(0, 0, 0);
            triangle.transform.localScale = new Vector3(1, 1, 1);
            triangle.transform.Rotate(0, 0, 0);


            MeshFilter meshFilter = triangle.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = triangle.AddComponent<MeshRenderer>();

            Mesh mesh = new Mesh();
            meshFilter.mesh = mesh;

            // 정점 정의
            Vector3[] vertices = new Vector3[3]
            {
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(0.5f, 1, 0)
            };
            mesh.vertices = vertices;

            // 삼각형 정의
            int[] triangles = new int[3] { 2, 1, 0 }; // 시계방향
            mesh.triangles = triangles;

            // Barycentric 좌표 추가
            Vector3[] barycentricCoordinates = new Vector3[3]
            {
                new Vector3(1, 0, 0), // 첫 번째 정점
                new Vector3(0, 1, 0), // 두 번째 정점
                new Vector3(0, 0, 1)  // 세 번째 정점
            };
            // Barycentric 좌표를 UV2에 저장
            mesh.SetUVs(1, new List<Vector3>(barycentricCoordinates));

            // 메시 속성 재계산
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            // 재질 할당
            meshRenderer.material = new Material(Shader.Find("Custom/SimpleWireframe"));

        });

        btn_Square.onClick.AddListener(() =>
        {
            // 사각형 GameObject를 생성하고 속성을 설정합니다.
            GameObject square = new GameObject("Square");

            // 위치, 크기, 회전 설정
            square.transform.position = new Vector3(-1, 0, 0);
            square.transform.localScale = new Vector3(1, 1, 1);
            square.transform.Rotate(0, 0, 0);

            MeshFilter meshFilter = square.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = square.AddComponent<MeshRenderer>();

            Mesh mesh = new Mesh();
            meshFilter.mesh = mesh;

            // 정점 정의
            Vector3[] vertices = new Vector3[4]
            {
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(1, 1, 0),
                new Vector3(0, 1, 0)
            };
            mesh.vertices = vertices;

            // 삼각형 정의 (시계방향)
            int[] triangles = new int[6] { 2, 1, 0, 0, 3, 2 };
            mesh.triangles = triangles;

            // 메시 속성 재계산
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            // 재질 할당
            // meshRenderer.material = new Material(Shader.Find("Standard"));
            meshRenderer.material = new Material(Shader.Find("Unlit/Color"));
            meshRenderer.material.color = Color.green;
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
