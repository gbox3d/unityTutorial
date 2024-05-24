using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam03_exporld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void End()
    {
        Debug.Log("End");

        // 0.5 초후 오즈잭트 제거
        Destroy(gameObject, 0.1f);
    }
}
