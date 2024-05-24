using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam05_click_instantiate : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Instantiate(prefab, mousePos, Quaternion.identity);
        }
        
    }
}
