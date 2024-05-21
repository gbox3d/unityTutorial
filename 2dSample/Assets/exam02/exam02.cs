using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam02 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();

        // 1 key
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Destroy(gameObject);
            animator.SetBool("atk1_trg", true);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("atk2_trg", true);
        }

        
    }
}
