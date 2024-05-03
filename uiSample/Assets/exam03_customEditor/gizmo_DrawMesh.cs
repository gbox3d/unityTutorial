using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmo_DrawMesh : MonoBehaviour
{
    public Mesh mesh; // 에디터에서 설정할 메시
    public Vector3 position = Vector3.zero;
    public Quaternion rotation = Quaternion.identity;
    public Vector3 scale = Vector3.one;

    // void OnDrawGizmos()
    // {
    //     if (mesh != null)
    //     {
    //         Gizmos.color = Color.green; // 기즈모의 색상을 설정
    //         Gizmos.DrawMesh(mesh, position, rotation, scale);
    //     }
    // }

    public Color lineColor = Color.white;

    void OnDrawGizmos()
    {
        if (mesh == null)
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                mesh = meshFilter.sharedMesh;
            }
        }

        if (mesh != null)
        {
            Gizmos.color = lineColor;
            DrawWireframe();
        }
    }

    void DrawWireframe()
    {
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        Gizmos.color = lineColor;

        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] triangles = mesh.GetTriangles(i);
            for (int j = 0; j < triangles.Length; j += 3)
            {
                DrawRay(mesh.vertices[triangles[j]], mesh.vertices[triangles[j + 1]] - mesh.vertices[triangles[j]]);
                DrawRay(mesh.vertices[triangles[j + 1]], mesh.vertices[triangles[j + 2]] - mesh.vertices[triangles[j + 1]]);
                DrawRay(mesh.vertices[triangles[j + 2]], mesh.vertices[triangles[j]] - mesh.vertices[triangles[j + 2]]);
            }
        }

        GL.PopMatrix();
    }

    void DrawRay(Vector3 start, Vector3 dir)
    {
        Gizmos.DrawRay(start, dir);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
