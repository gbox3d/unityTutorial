using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam08_PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        CapsuleCollider2D capsuleCollider = GetComponent<CapsuleCollider2D>();
        if (capsuleCollider != null) {

            // 캡슐 콜라이더의 중심 위치와 크기 정보
            Vector3 colliderCenter = capsuleCollider.bounds.center;
            Vector3 colliderSize = capsuleCollider.size;
            float colliderRadius = capsuleCollider.size.x / 2;
            float colliderHeight = capsuleCollider.size.y - (2 * colliderRadius);

            // 캡슐 콜라이더의 색상 및 스타일 설정
            Gizmos.color = Color.yellow;

            // 캡슐 콜라이더의 상단과 하단 원 부분 그리기
            
            Gizmos.DrawWireSphere(colliderCenter + Vector3.up * (colliderHeight / 2), colliderRadius);
            Gizmos.DrawWireSphere(colliderCenter - Vector3.up * (colliderHeight / 2), colliderRadius);

            // 캡슐 콜라이더의 원통 부분 그리기
            Gizmos.DrawLine(colliderCenter + Vector3.left * colliderRadius + Vector3.up * (colliderHeight / 2), colliderCenter + Vector3.left * colliderRadius - Vector3.up * (colliderHeight / 2));
            Gizmos.DrawLine(colliderCenter + Vector3.right * colliderRadius + Vector3.up * (colliderHeight / 2), colliderCenter + Vector3.right * colliderRadius - Vector3.up * (colliderHeight / 2));

        }
    }

#endif

    //get collider
    // public Collider GetCollider()
    // {
    //     return GetComponent<CapsuleCollider2D
    // }
}
