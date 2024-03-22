using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

using System;


public class exam03 : MonoBehaviour
{

    Vector3[] mVertices;

    // Start is called before the first frame update
    void Start()
    {

        DrawCircle(0, 0, 0, new Color(1,0,0), 0.5f, 32);

        // 그리드 생성
        CreateGridVertices(8, 8, 1f);
        DrawGridCircle();

        DrawGridLine(8, 8);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if the mouse is Down and not over a UI element
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            // get the mouse position
			Debug.Log (string.Format("mousePosition ({0:f}, {1:f})", Input.mousePosition.x, Input.mousePosition.y));

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;

            // 마우스 포지션을 월드 좌표로 변환합니다.
            // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log (string.Format("worldPosition ({0:f}, {1:f}, {2:f})", worldPosition.x, worldPosition.y, worldPosition.z));
            
            // 원을 그립니다.
            DrawCircle(worldPosition.x, worldPosition.y, worldPosition.z, new Color(0,1,0), 1, 32);
		}
    }

    // 원을 그리는 함수
    public void DrawCircle(float centerX, float centerY, float centerZ,Color color,float radius=1, int segments=32)
    {
        GameObject circleGameObject = new GameObject("Circle");
        LineRenderer lineRenderer = circleGameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.useWorldSpace = false; // 원의 위치를 로컬 좌표계로 설정
        lineRenderer.positionCount = segments + 1; // 원을 완성하기 위해 첫 정점을 마지막에 다시 추가

        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = (Color)color; // 색상 적용

        float angle = 0f;

        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
        }

        // 원의 중심 위치 조정
        circleGameObject.transform.position = new Vector3(centerX, centerY, centerZ);
    }

    public void DrawLineShape(Vector3[] vertices, Color color,Boolean isLoop = false)
    {
        GameObject lineGameObject = new GameObject("Line");
        LineRenderer lineRenderer = lineGameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.useWorldSpace = false; // 원의 위치를 로컬 좌표계로 설정
        lineRenderer.positionCount = vertices.Length; // 원을 완성하기 위해 첫 정점을 마지막에 다시 추가

        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = (Color)color; // 색상 적용

        for (int i = 0; i < vertices.Length; i++)
        {
            lineRenderer.SetPosition(i, vertices[i]);
        }

        if (isLoop)
        {
            lineRenderer.loop = true;
        }
    }


    void CreateGridVertices(int width, int height, float cellSize)
    {
        mVertices = new Vector3[(width + 1) * (height + 1)];

        for (int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                // 정점 위치에 작은 원을 생성
                mVertices[i * (height + 1) + j] = new Vector3(
                    i * cellSize - (width * cellSize) / 2, 
                    j * cellSize - (height * cellSize) / 2
                    , 0);
            }
        }
    }

    void DrawGridCircle()
    {
        for (int i = 0; i < mVertices.Length; i++)
        {
            DrawCircle(mVertices[i].x, mVertices[i].y, mVertices[i].z, new Color(1,0,0), 0.05f, 32);
        }
    }

    void DrawGridLine(int width,int height)
    {
        // 가로 선 그리기
        for (int i = 0; i <= width; i++)
        {
            Vector3[] vertices = new Vector3[height + 1];
            for (int j = 0; j <= height; j++)
            {
                vertices[j] = mVertices[i * (height + 1) + j];
            }
            DrawLineShape(vertices, new Color(0,0,1));
        }

        // 세로 선 그리기
        for (int i = 0; i <= height; i++)
        {
            Vector3[] vertices = new Vector3[width + 1];
            for (int j = 0; j <= width; j++)
            {
                vertices[j] = mVertices[j * (height + 1) + i];
            }
            DrawLineShape(vertices, new Color(0,0,1));
        }
    }



    void OnDrawGizmosSelected()
    {
        // if (mVertices == null)
        //     return;

        // Gizmos.color = Color.red;

        // for (int i = 0; i < mVertices.Length; i++)
        // {
        //     Gizmos.DrawWireSphere(mVertices[i], 0.1f);
        // }
    }

    void OnDrawGizmos()
    {
        // if (mVertices == null)
        //     return;

        // Gizmos.color = Color.red;

        // for (int i = 0; i < mVertices.Length; i++)
        // {
        //     Gizmos.DrawWireSphere(mVertices[i], 0.01f);
        // }
    }
}
