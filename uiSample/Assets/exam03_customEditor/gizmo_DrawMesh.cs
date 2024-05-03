using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmo_DrawMesh : MonoBehaviour
{
    public Mesh mesh; // 에디터에서 설정할 메시
    public Vector3 position = Vector3.zero;
    public Quaternion rotation = Quaternion.identity;
    public Vector3 scale = Vector3.one;

    public Color lineColor = Color.white;

    void OnDrawGizmos()
    {
        if (mesh != null)
        {
            Gizmos.color = lineColor;
            DrawWireframe();
        }
    }

    void DrawWireframe()
    {
        // GL.PushMatrix();
        // GL.MultMatrix(transform.localToWorldMatrix);
        Gizmos.color = lineColor;

        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] triangles = mesh.GetTriangles(i);
            for (int j = 0; j < triangles.Length; j += 3)
            {
                Vector3[] vertices = {
                    transform.localToWorldMatrix.MultiplyPoint(mesh.vertices[triangles[j]]),
                    transform.localToWorldMatrix.MultiplyPoint(mesh.vertices[triangles[j + 1]]),
                    transform.localToWorldMatrix.MultiplyPoint(mesh.vertices[triangles[j + 2]])
                };

                Gizmos.DrawLine(vertices[0], vertices[1]);
                Gizmos.DrawLine(vertices[1], vertices[2]);
                Gizmos.DrawLine(vertices[2], vertices[0]);
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
}
