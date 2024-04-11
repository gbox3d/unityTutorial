using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exam05MainUI : MonoBehaviour
{
    [SerializeField] private Button btnCreatePolygon;
    [SerializeField] GameObject vertexGroup;

    // Start is called before the first frame update
    void Start()
    {
        btnCreatePolygon.onClick.AddListener(() =>
        {
            //vertexGroup 의 모든 자식 얻기
            Transform[] children = vertexGroup.GetComponentsInChildren<Transform>();

            foreach (Transform child in children)
            {
                if (child != vertexGroup.transform)
                {
                    Debug.Log(child.name);
                    Debug.Log(child.position);
                }
            }


            
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
