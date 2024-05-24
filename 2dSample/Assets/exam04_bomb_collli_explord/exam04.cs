using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam04 : MonoBehaviour
{
    public GameObject prefab_Bomb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //create bomb mouse click , create bomb at mouse position
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Instantiate(prefab_Bomb, mousePos, Quaternion.identity);
        }
        
    }
}
