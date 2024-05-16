using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam02 : MonoBehaviour
{
    public List<Vector3> mVertices = new();
    public List<float> mWeights = new();

    // Start is called before the first frame update
    void Start()
    {
        // Example usage
        // CreateGridVertices(8, 8, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateGridVertices(int width, int height, float cellSize)
    {
        mVertices.Clear();

        for (int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                // Add vertex position to the list
                mVertices.Add(new Vector3(
                    i * cellSize - (width * cellSize) / 2,
                    j * cellSize - (height * cellSize) / 2,
                    0));

                // Add weight to the list
                mWeights.Add(1.0f);
            }
        }
    }

    public void CreateWeightList_1(int width, int height)
    {
        mWeights.Clear();

        // 중심 좌표 계산
        float centerX = width / 2.0f;
        float centerY = height / 2.0f;
        float maxDistance = Mathf.Sqrt(centerX * centerX + centerY * centerY);

        for (int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                // 중심으로부터의 거리 계산
                float distance = Mathf.Sqrt((i - centerX) * (i - centerX) + (j - centerY) * (j - centerY));

                // 거리 비율 계산 (0 ~ 1 사이의 값)
                float distanceRatio = distance / maxDistance;

                // sin 함수를 이용하여 가중치 계산
                float weight = Mathf.Sin((1 - distanceRatio) * Mathf.PI / 2);

                // 가중치 리스트에 추가
                mWeights.Add(weight);
            }
        }
    }


    // #if UNITY_EDITOR



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Draw spheres at the vertex positions with weights applied
        for (int i = 0; i < mVertices.Count; i++)
        {
            Vector3 vertex = mVertices[i];
            float weight = mWeights[i];


            Vector3 targetVertex = transform.TransformPoint(vertex);


            // Draw the original vertex with a wire sphere
            Vector3 finalVertex = Vector3.Lerp(vertex, targetVertex, weight);

            Gizmos.DrawWireSphere(finalVertex, 0.1f);

            // Apply weight to the vertex position
            // Vector3 weightedVertex = vertex * weight;

            // Transform the vertex position by the GameObject's transform
            // Vector3 transformedVertex = transform.TransformPoint(ㅡ);

            // Draw the vertex with a wire sphere
            // Gizmos.DrawWireSphere(transformedVertex, 0.1f);
        }
    }
    // #endif
}
