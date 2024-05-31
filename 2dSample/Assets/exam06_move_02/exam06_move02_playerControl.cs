using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam06_move02_playerControl : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    Vector2 velocity;

    public float speed = 1.0f;

    SpriteRenderer spriteRenderer;
    
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float _hozInput = Input.GetAxisRaw("Horizontal"); // -1, 0, 1

        // Move player left or right
        velocity = new Vector2(_hozInput, 0).normalized * speed; 
        animator.SetBool("isWalk", velocity.x != 0); // Set isWalk to true if player is moving

        // Flip sprite
        if (_hozInput > 0)
        {
            //현재 기준으로 y축 회전값을 0으로 만들기
            transform.rotation = Quaternion.Euler(0, 0, 0);

            
        }
        else if (_hozInput < 0)
        {
            //y축 회전값을 180으로 초기화
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(velocity.x, rigidbody.velocity.y);
    }
}
