using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class planeTest : MonoBehaviour
{
    public GameObject mTarget;

    public TextMeshPro mInfoText;

    public Plane myPlane;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        UpdatePlane();

        //rotate dummy
        mTarget.transform.Rotate(0, 0, 45 * Time.deltaTime);

        //get children of dummy
        Transform[] children = mTarget.GetComponentsInChildren<Transform>();

        string _info = "";

        foreach (Transform child in children)
        {
            //get distance to child
            
            //get maerial of child
            Renderer renderer = child.GetComponent<Renderer>();

            if(renderer == null)
                continue;

            float _dist = myPlane.GetDistanceToPoint(child.position);

            _info += $"child : {child.name} / dist : {_dist} , ";


            Material _material = renderer.material;

            //change color of child
            Color color = new Color(1,1,1,1);
            //가까울수록 blue
            if (_dist < 5)
            {
                color.r = _dist / 5.0f;
                color.g = _dist / 5.0f;
            }

            _material.color = color;
        }

        mInfoText.text = _info;

    }

    public void UpdatePlane()
    {
        myPlane = new Plane(transform.up, transform.position);
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

