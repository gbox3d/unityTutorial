 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class exam06Main : MonoBehaviour
{
    [SerializeField] GameObject arrowObj;
    [SerializeField] GameObject targetObj;
    [SerializeField] TMP_Text textObj;
    [SerializeField] TMP_Text textObj2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move forward
        if (Input.GetKey(KeyCode.W))
        {
            arrowObj.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            arrowObj.transform.Translate(Vector3.back * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            arrowObj.transform.Translate(Vector3.left * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            arrowObj.transform.Translate(Vector3.right * Time.deltaTime);
        }

        // rotate
        if (Input.GetKey(KeyCode.Q))
        {
            arrowObj.transform.Rotate(Vector3.up, -45.0f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            arrowObj.transform.Rotate(Vector3.up, 45.0f * Time.deltaTime);
        }
        
        // arrowObj front vector
        Vector3 front = arrowObj.transform.forward;
        textObj.text = "Front Vector: " + front.ToString();

        // arrowObj angle
        float angle = Vector3.Angle(Vector3.forward, front);
        textObj.text += "\nAngle: " + angle.ToString();

        // arrowObj distance from target
        float distance = Vector3.Distance(arrowObj.transform.position, targetObj.transform.position);

        textObj2.text = "Distance: " + distance.ToString();

        // arrowObj to target vector
        Vector3 toTarget = targetObj.transform.position - arrowObj.transform.position;
        //normalized vector
        toTarget.Normalize();
        textObj2.text += "\nTo Target Vector: " + toTarget.ToString();

    }
}
