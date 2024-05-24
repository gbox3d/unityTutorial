using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam05_bomb : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //check collision with tag list
        if(collision.gameObject.tag == "block")
        {
            Debug.Log("collision with block");
            animator.SetBool("isExplord", true);
            // Destroy(gameObject);
        }
    }

    void OnEndExplord()
    {
        Destroy(gameObject);
    }
}
