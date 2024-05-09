using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam07 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(transform.position, 1.0f);
    // }

    void OnDrawGizmos()
    {
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, 1.0f);

        // 화살표 그리기
         // 원점에서 시작해서 (1,0,0) 방향으로 화살표 그리기
        Gizmos.color = Color.white;
        Vector3 direction = new Vector3(1, 0, 0);

        
        Gizmos.DrawRay(Vector3.zero, transform.position);
        // DrawArrowEnd(transform.position, Vector3.forward, Color.green);
    }
}
