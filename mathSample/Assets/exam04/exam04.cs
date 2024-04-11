using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

public class exam04 : MonoBehaviour
{
    [SerializeField] Button btn_polygon;
    [SerializeField] Texture2D texture;
    [SerializeField] Button btn_Texture;
    [SerializeField] Button btn_vertexcolor;
    [SerializeField] Button btn_ClearSqure;

    [SerializeField] Transform squareDummy;
    // Start is called before the first frame update
    void Start()
    {
        // Button btn_test1 = GameObject.Find("Button_test1").GetComponent<Button>();
        btn_ClearSqure.onClick.AddListener(() => {
            Debug.Log("Button_test1 Clicked");

            //clear all dummy children
            foreach (Transform child in squareDummy)
            {
                GameObject.Destroy(child.gameObject);
            }
            
        });

        btn_polygon.onClick.AddListener(()=> {

            Debug.Log("Button_test1 Clicked");

            GameObject square = new GameObject("triangle");
            
            square.transform.parent = squareDummy;

            // 위치, 크기, 회전 설정
            square.transform.position = new (0, 0, 0);
            square.transform.localScale = new (1, 1, 1);
            square.transform.Rotate(0, 0, 0);

            MeshFilter meshFilter = square.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = square.AddComponent<MeshRenderer>();

            Mesh mesh = new();
            meshFilter.mesh = mesh;

            // 정점 정의
            Vector3[] vertices = new Vector3[4]
            {
                new (-1, -1, 0),
                new (1, -1, 0),
                new (1, 1, 0),
                new (-1, 1, 0)
            };
            mesh.vertices = vertices;

            // 삼각형 정의 (시계방향)
            int[] triangles = new int[6] { 2, 1, 0, 0, 3, 2 };
            mesh.triangles = triangles;

            

            // 메시 속성 재계산
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            // 재질 할당
            meshRenderer.material = new Material(Shader.Find("Custom/SimpleColor"));

            meshRenderer.material.color = new Color(1, 0, 0, 1);
            meshRenderer.material.SetColor("_Color", new Color(1, 0, 0, 1));
        });


        btn_vertexcolor.onClick.AddListener(()=> {

            Debug.Log("Button_test1 Clicked");

            GameObject square = new GameObject("Square");
            
            square.transform.parent = squareDummy;

            // 위치, 크기, 회전 설정
            square.transform.position = new (0, 0, 0);
            square.transform.localScale = new (1, 1, 1);
            square.transform.Rotate(0, 0, 0);

            MeshFilter meshFilter = square.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = square.AddComponent<MeshRenderer>();

            Mesh mesh = new();
            meshFilter.mesh = mesh;

            // 정점 정의
            Vector3[] vertices = new Vector3[4]
            {
                new (-1, -1, 0),
                new (1, -1, 0),
                new (1, 1, 0),
                new (-1, 1, 0)
            };
            mesh.vertices = vertices;

            // 삼각형 정의 (시계방향)
            int[] triangles = new int[6] { 2, 1, 0, 0, 3, 2 };
            mesh.triangles = triangles;
            
            // Define vertex colors
            Color[] colors = new Color[4]
            {
                new(1, 0, 0, 1),
                new(0, 1, 0, 1),
                new(0, 0, 1, 1),
                new(1, 1, 1, 1)
            };
            mesh.colors = colors;

            // 메시 속성 재계산
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            // 재질 할당
            meshRenderer.material = new Material(Shader.Find("Custom/VertexColorShader"));

        });

        btn_Texture.onClick.AddListener(() => {
            Debug.Log("Button_test1 Clicked");

            GameObject square = new GameObject("Square");
            
            square.transform.parent = squareDummy;

            // 위치, 크기, 회전 설정
            square.transform.position = new (0, 0, 0);
            square.transform.localScale = new (1, 1, 1);
            square.transform.Rotate(0, 0, 0);

            MeshFilter meshFilter = square.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = square.AddComponent<MeshRenderer>();

            Mesh mesh = new();
            meshFilter.mesh = mesh;

            // 정점 정의
            Vector3[] vertices = new Vector3[4]
            {
                new (-1, -1, 0),
                new (1, -1, 0),
                new (1, 1, 0),
                new (-1, 1, 0)
            };
            mesh.vertices = vertices;

            // 삼각형 정의 (시계방향)
            int[] triangles = new int[6] { 2, 1, 0, 0, 3, 2 };
            mesh.triangles = triangles;

            // Define UVs
            Vector2[] uvs = new Vector2[4]
            {
                new(0, 0),
                new(1, 0),
                new(1, 1),
                new(0, 1)
            };
            mesh.uv = uvs;

            // 메시 속성 재계산
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            // 재질 할당
            meshRenderer.material = new Material(Shader.Find("Custom/SimpleTextureShader"));

            //텍스춰 설정
            meshRenderer.material.mainTexture = texture;

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
