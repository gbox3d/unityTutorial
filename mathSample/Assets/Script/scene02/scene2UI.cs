using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class scene2UI : MonoBehaviour
{
    [SerializeField] private Button btn_Triangle;
    [SerializeField] private Button btn_Square;

    // Start is called before the first frame update
    void Start()
    {
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
            int[] triangles = new int[3] { 2,1,0 }; // 시계방향
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
            meshRenderer.material = new Material(Shader.Find("Standard"));
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
