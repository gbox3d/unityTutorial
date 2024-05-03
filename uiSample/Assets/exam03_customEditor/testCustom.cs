using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCustom : MonoBehaviour
{
    public int testInt = 5;
    public float testFloat = 5.0f;
    // Start is called before the first frame update

    public float baseSize = 1.0f;
    void Start()
    {
        Debug.Log("testInt = " + testInt);

        GenColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, testFloat);
    // }

    public void GenColor()
    {
        Debug.Log("gen color");

        Color color = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<Renderer>().sharedMaterial.color = color;
    }

    public void ResetColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }
}
