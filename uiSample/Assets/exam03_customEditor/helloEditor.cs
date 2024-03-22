using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helloEditor : MonoBehaviour
{
    public string myString = "Hello, World!";
    public string strName = "arakis";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(myString);
        Debug.Log(strName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
