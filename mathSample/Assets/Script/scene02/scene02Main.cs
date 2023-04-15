using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene02Main : MonoBehaviour
{
    public GameObject prefabSphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {
        Debug.Log("Generate");


        for (int i = 0; i < 10; i++)
        {
            //random position
            Vector3 pos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            GameObject go = Instantiate(prefabSphere, pos, Quaternion.identity);
            go.transform.parent = transform;
        }
    }

    public void clearChild()
    {
        Debug.Log("clear");
        int childCount = transform.childCount;

        while(childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
            childCount--;
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 2);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 2);

    }
}
