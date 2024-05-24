using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class exam03 : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        //자신이 카메라 객체임
        //GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 클릭시 프리펩 생성 , 마우스 위치에 생성
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Instantiate(prefab, mousePos, Quaternion.identity);
        }
        
    }
}
