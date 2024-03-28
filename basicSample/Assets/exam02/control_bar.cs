using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_bar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //좌우로 기울이기
        float move = Input.GetAxis("Horizontal");

        // Calculate the new z rotation based on input and speed (assuming speed of rotation is desired)
        // Multiplying by Time.deltaTime makes the rotation frame-independent
        float speed = 100.0f; // Adjust the speed as necessary
        float newZRotation = transform.eulerAngles.z + move * speed * Time.deltaTime;

        // Clamp the new z rotation to the range [-45, 45] degrees
        // The Euler angles might be greater than 360 or less than 0, so we adjust them to be within [0, 360]
        if (newZRotation > 180) newZRotation -= 360; // If the rotation is above 180 degrees, make it negative
        newZRotation = Mathf.Clamp(newZRotation, -45, 45);

        // Set the new rotation while preserving the x and y rotations
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newZRotation);
    }
}
