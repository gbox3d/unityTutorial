using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class exam01 : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;

    // // [SerializeField] int test;
    public Vector3 targetPosition;
    public Vector3 targetEulerAngle;

    public Matrix4x4 matrixOutput;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDrawGizmos() {
        // Gizmos.color = Color.red;
        // Gizmos.DrawSphere(transform.position, 1.0f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target1.transform.position);

        // Gizmos.color = Color.green;
        // Gizmos.DrawLine(target1.transform.position, target2.transform.position);

        Gizmos.color = Color.blue;

        Vector3 vForward = target1.transform.localToWorldMatrix.GetColumn(2);

        Gizmos.DrawRay(target1.transform.position, vForward * 2.0f);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(target1.transform.position, target1.transform.right * 2.0f);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(target1.transform.position, target1.transform.up * 2.0f);


    }
}
