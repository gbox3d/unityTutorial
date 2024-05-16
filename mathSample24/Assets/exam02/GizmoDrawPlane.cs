using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawPlane : MonoBehaviour
{

    public ArrayList mVertices = new();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

#if UNITY_EDITOR

    void CreateGridVertices(int width, int height, float cellSize)
    {

        mVertices.Clear();

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

        // return vertice;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        //array list of points
        // Vector3[] points = CreateGridVertices(8, 8, 1.0f);



        // //draw lines
        // for (int i = 0; i < points.Length; i++)
        // {
        //     Gizmos.DrawWireSphere(points[i], 0.1f);
        // }

    }

#endif

}
