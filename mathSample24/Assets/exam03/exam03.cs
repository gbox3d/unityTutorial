using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam03 : MonoBehaviour
{

    public Transform bone1;
    public Transform bone2;

    public List<Vector3> mVertices = new();
    public List<int> mIndices = new();
    public List<float> mWeights = new();

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
                    j * cellSize,
                    0));

                // Add weight to the list
                mWeights.Add(1.0f);
            }
        }

        // Create indices
        mIndices.Clear();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int index = i * (height + 1) + j;
                mIndices.Add(index);
                mIndices.Add(index + 1);
                mIndices.Add(index + height + 1);

                mIndices.Add(index + 1);
                mIndices.Add(index + height + 1);
                mIndices.Add(index + height + 2);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        if (mVertices.Count == 0)
            return;

        Gizmos.color = Color.red;
        for (int i = 0; i < mVertices.Count; i++)
        {
            Gizmos.DrawSphere(mVertices[i], 0.1f);
        }

        // Transform bone1 = GameObject.Find("Bone1").transform;

        Gizmos.color = Color.green;
        for (int i = 0; i < mIndices.Count; i += 3)
        {

            Vector3[] origin = new Vector3[3];
            origin[0] = mVertices[mIndices[i]];
            origin[1] = mVertices[mIndices[i + 1]];
            origin[2] = mVertices[mIndices[i + 2]];

            Vector3[] target = new Vector3[3];
            target[0] = bone1.TransformPoint(origin[0]);
            target[1] = bone1.TransformPoint(origin[1]);
            target[2] = bone1.TransformPoint(origin[2]);

            Gizmos.DrawLine(target[0], target[1]);
            Gizmos.DrawLine(target[1], target[2]);
            Gizmos.DrawLine(target[2], target[0]);



            
        }
        
        
    }
}
