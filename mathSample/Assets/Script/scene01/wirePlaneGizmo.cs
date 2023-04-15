using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wirePlaneGizmo : MonoBehaviour
{
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
        //와이어 프레임 그리기
        // 평면의 크기를 정의합니다. 크기는 평면의 절반 길이를 나타냅니다.
        float size = 5.0f;

        // 평면의 각 변에 대한 방향 벡터를 정의합니다.
        Vector3 right = transform.right * size;
        Vector3 forward = transform.forward * size;

        // 평면의 네 모서리를 계산합니다.
        Vector3 topLeft = transform.position - right + forward;
        Vector3 topRight = transform.position + right + forward;
        Vector3 bottomLeft = transform.position - right - forward;
        Vector3 bottomRight = transform.position + right - forward;

        // 기즈모의 색상을 설정합니다.
        Gizmos.color = Color.yellow;

        // 와이어 프레임 평면의 네 변을 그립니다.
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);


        //법선그리기
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 5.0f);
    }

}
