using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam06_playerController : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    Vector2 velocity;

    public float speed = 1.0f;

    SpriteRenderer spriteRenderer;

    public float jumpPower = 1.0f;
    bool isGrounded = false;

    Animator animator;

    CapsuleCollider2D capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        capsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            velocity = Vector2.zero;

        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump")) {

            velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized * speed;
            
            //공중에 떳을때는 좌우로만 움직이게

            // if( Mathf.Abs( rigidbody.velocity.y ) > 0)
            // {
            //     velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized * speed;
            // }
        }
        else
        {

            velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized * speed;

            animator.SetBool("isWalk", velocity.x != 0);

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;
                

                // capsuleCollider2D.offset = new Vector2(0.5f, 0);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
                // capsuleCollider.offset = new Vector2(-Mathf.Abs(capsuleCollider.offset.x), capsuleCollider.offset.y);
            }

            if (Input.GetMouseButtonDown(1))
            {
                animator.SetTrigger("atk1_trg");
            }

            if (Input.GetMouseButtonDown(0) && isGrounded )
            {
                // animator.SetTrigger("jmp_trg");
                velocity = Vector2.zero;
                Jump();
            }
        }


        
    }

    void Jump()
    {
        // rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpPower);
        animator.SetTrigger("jmp_trg");
        isGrounded = false;
        animator.SetBool("isGrounded", isGrounded);
    }

    void OnJumpUp()
    {

        // Vector2 vDir = Vector2.up;

        //45도 회전
        // vDir = Quaternion.Euler(0, 0, 45) * vDir;

        // rigidbody.velocity = vDir * jumpPower;



        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpPower);
        // if (rigidbody.velocity.y > 0)
        // {
        //     rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
        // }
    }

    void FixedUpdate()
    {
        // rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        rigidbody.velocity = new Vector2(velocity.x, rigidbody.velocity.y);

        // if(spriteRenderer.flipX)
        // {
        //     capsuleCollider.offset = new Vector2(-Mathf.Abs(capsuleCollider.offset.x), capsuleCollider.offset.y);
        //     // capsuleCollider.offset = new Vector2(1, capsuleCollider.offset.y);
        // }
        // else
        // {
        //     capsuleCollider.offset = new Vector2(Mathf.Abs(capsuleCollider.offset.x), capsuleCollider.offset.y);
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //get angle of collision
        // Debug.Log(collision.contacts[0].normal);

        //collision.contacts[0].normal 각도 구하기
        // Debug.Log(Vector2.Angle(Vector2.up, collision.contacts[0].normal));

        

        if (collision.contacts[0].normal.y > 0.5 && rigidbody.velocity.y <= 0)
        {
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);
            // animator.SetBool("isGrounded", isGrounded);
            // animator.SetTrigger("land_trg");
        }
    }

    


}
