using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2d platformer player controller

public class Exam08_PlayerContoller : MonoBehaviour
{
    Vector2 velocity;
    public float moveSpeed = 5.0f;
    public float jumpPower = 10.0f;
    Animator BodyAnnimator;
    new Rigidbody2D rigidbody;

    bool isGrounded = false;

    [SerializeField] GameObject bodySprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        BodyAnnimator = bodySprite.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 이동 처리
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 플레이어의 이동 방향 설정
        velocity = new Vector2(horizontal, 0).normalized * moveSpeed;

        if( Mathf.Abs(velocity.x) > 0 && isGrounded)
        {
            BodyAnnimator.SetBool("isWalk", true);

            if(velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            BodyAnnimator.SetBool("isWalk", false);
        }

        //jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
            // BodyAnnimator.SetBool("isJumping", true);
        }

    }

    void FixedUpdate()
    {   
        rigidbody.velocity = new Vector2(velocity.x, rigidbody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "block")
        {
            isGrounded = true;
            // BodyAnnimator.SetBool("isJumping", false);
        }
    }

#if UNITY_EDITOR


    void OnDrawGizmos()
    {
        CapsuleCollider2D capsuleCollider = GetComponent<CapsuleCollider2D>();
        if (capsuleCollider != null)
        {
            // 캡슐 콜라이더의 중심 위치와 크기 정보
            Vector3 colliderCenter = capsuleCollider.bounds.center;
            Vector3 colliderSize = capsuleCollider.size;
            float colliderRadius = capsuleCollider.size.x / 2;
            float colliderHeight = capsuleCollider.size.y - (2 * colliderRadius);

            // 회전 행렬 생성
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(colliderCenter, transform.rotation, Vector3.one);
            Gizmos.matrix = rotationMatrix;

            // 캡슐 콜라이더의 색상 및 스타일 설정
            Gizmos.color = Color.yellow;

            // 캡슐 콜라이더의 상단과 하단 원 부분 그리기
            Gizmos.DrawWireSphere(Vector3.up * (colliderHeight / 2), colliderRadius);
            Gizmos.DrawWireSphere(Vector3.down * (colliderHeight / 2), colliderRadius);

            // 캡슐 콜라이더의 원통 부분 그리기
            Gizmos.DrawLine(Vector3.left * colliderRadius + Vector3.up * (colliderHeight / 2), Vector3.left * colliderRadius - Vector3.up * (colliderHeight / 2));
            Gizmos.DrawLine(Vector3.right * colliderRadius + Vector3.up * (colliderHeight / 2), Vector3.right * colliderRadius - Vector3.up * (colliderHeight / 2));

            // Gizmos 행렬 초기화
            Gizmos.matrix = Matrix4x4.identity;
        }
    }

#endif

    //get collider
    // public Collider GetCollider()
    // {
    //     return GetComponent<CapsuleCollider2D
    // }
}
