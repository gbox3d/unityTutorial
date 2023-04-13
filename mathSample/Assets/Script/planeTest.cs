using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeTest : MonoBehaviour
{
    public GameObject mTarget;

    public Plane myPlane;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlane();
        //myPlane = new Plane(transform.up, transform.position);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePlane()
    {
        myPlane = new Plane(transform.up, transform.position);
    }

    public float GetDistanceToTarget()
    {
        if (mTarget != null)
        {
            float distance = myPlane.GetDistanceToPoint(mTarget.transform.position);
            return distance;
        }

        return 0;
    }

    void OnDrawGizmos()
    {
        // Draw a line from the object's center along its normal direction
        Vector3 lineStart = transform.position;
        Vector3 lineEnd = lineStart + transform.up * 5; // You can adjust the length of the line by changing the multiplier
        Gizmos.color = Color.green;
        Gizmos.DrawLine(lineStart, lineEnd);
    }


}

