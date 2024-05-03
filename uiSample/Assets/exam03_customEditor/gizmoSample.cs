using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmoSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 화살표 끝을 그리는 보조 함수
    void DrawArrowEnd(Vector3 start, Vector3 dir, Color color)
    {
        Gizmos.color = color;
        float arrowHeadAngle = 25.0f;
        float arrowHeadLength = 0.25f;

        // 화살표 머리의 두 선을 계산
        Vector3 right = Quaternion.LookRotation(dir) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(dir) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Gizmos.DrawRay(start + dir, right * arrowHeadLength);
        Gizmos.DrawRay(start + dir, left * arrowHeadLength);
    }

    void OnDrawGizmos()
    {
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, 1.0f);

        // 화살표 그리기
         // 원점에서 시작해서 (1,0,0) 방향으로 화살표 그리기
        Gizmos.color = Color.white;
        Vector3 direction = new Vector3(1, 0, 0);

        
        Gizmos.DrawRay(Vector3.zero, transform.position);
        DrawArrowEnd(transform.position, Vector3.forward, Color.green);
    }
}
