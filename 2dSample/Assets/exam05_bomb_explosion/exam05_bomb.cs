using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam05_bomb : MonoBehaviour
{
    Animator animator;
    new Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //check collision with tag list
        if (collision.gameObject.tag == "block")
        {
            Debug.Log("collision with block");
            animator.SetBool("isExplord", true);


            // 회전을 Quaternion.identity로 설정하여 회전을 막음
            transform.rotation = Quaternion.identity;
            // Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

            if (rigidbody != null)
            {
                rigidbody.angularVelocity = 0f; // 각속도를 0으로 설정하여 회전을 막음
                rigidbody.velocity = Vector2.zero; // 이동 속도를 0으로 설정
                rigidbody.isKinematic = true; // 물리 시뮬레이션 비활성화
            }
        }
    }

    void OnEndExplord()
    {
        Destroy(gameObject);
    }
}
