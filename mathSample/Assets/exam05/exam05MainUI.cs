using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exam05MainUI : MonoBehaviour
{
    [SerializeField] private Button btnCreatePolygon;
    [SerializeField] private Button btnCreateTexture;
    [SerializeField] GameObject vertexGroup;

    [SerializeField] Texture2D texture;


    void CreateTexturePolygon() {

        //vertexGroup 의 모든 자식 얻기
            Transform[] children = vertexGroup.GetComponentsInChildren<Transform>();

            //Vector3 list 생성
            List<Vector3> vertices = new List<Vector3>();

            foreach (Transform child in children)
            {
                if (child != vertexGroup.transform)
                {
                    Debug.Log(child.name);
                    Debug.Log(child.position);
                    vertices.Add(child.position);
                }
            }

            //정점 정의
            Vector3[] verticesArray = vertices.ToArray();
            foreach (Vector3 vertex in verticesArray)
            {
                Debug.Log(vertex);
            }

            //삼각형 생성
            GameObject polygon = new GameObject("polygon");

            //위치, 크기, 회전 설정
            polygon.transform.position = new Vector3(0, 0, 0);
            polygon.transform.localScale = new Vector3(1, 1, 1);
            polygon.transform.Rotate(0, 0, 0);

            MeshFilter meshFilter = polygon.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = polygon.AddComponent<MeshRenderer>();

            Mesh mesh = new Mesh();
            meshFilter.mesh = mesh;

            //삼각형 정점 정의
            mesh.vertices = verticesArray;


            /*

            (0,1) ---- (1,1)
                |          |
                |          |
            (0,0) ---- (1,0)

            */

            //uv 정의
            Vector2[] uvs = new Vector2[4]
            {
                new Vector2(0, 1),
                new Vector2(1, 1),
                new Vector2(1, 0),
                new Vector2(0, 0)
            };
            mesh.uv = uvs;

            //삼각형 면 정의
            mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };

            // UnlitTexture Shader 사용
            meshRenderer.material = new Material(Shader.Find("Unlit/Texture"));
            meshRenderer.material.mainTexture = texture;

            //메시 속성 재계산
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

    }

    // Start is called before the first frame update
    void Start()
    {
        btnCreatePolygon.onClick.AddListener(() =>
        {
            //vertexGroup 의 모든 자식 얻기
            Transform[] children = vertexGroup.GetComponentsInChildren<Transform>();

            //Vector3 list 생성
            List<Vector3> vertices = new List<Vector3>();

            foreach (Transform child in children)
            {
                if (child != vertexGroup.transform)
                {
                    Debug.Log(child.name);
                    Debug.Log(child.position);
                    vertices.Add(child.position);
                }
            }

            //정점 정의
            Vector3[] verticesArray = vertices.ToArray();
            foreach (Vector3 vertex in verticesArray)
            {
                Debug.Log(vertex);
            }

            //삼각형 생성
            GameObject polygon = new GameObject("polygon");            

            //위치, 크기, 회전 설정
            polygon.transform.position = new Vector3(0, 0, 0);
            polygon.transform.localScale = new Vector3(1, 1, 1);
            polygon.transform.Rotate(0, 0, 0);

            MeshFilter meshFilter = polygon.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = polygon.AddComponent<MeshRenderer>();

            Mesh mesh = new Mesh();
            meshFilter.mesh = mesh;

            //삼각형 정점 정의
            mesh.vertices = verticesArray;

            //삼각형 면 정의
            mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3};

            // UnlitColor Shader 사용
            meshRenderer.material = new Material(Shader.Find("Unlit/Color"));
            meshRenderer.material.color = new Color(1, 0, 0, 1);

            //메시 속성 재계산
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            
        });
        
        btnCreateTexture.onClick.AddListener(()=> {

            CreateTexturePolygon();

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
