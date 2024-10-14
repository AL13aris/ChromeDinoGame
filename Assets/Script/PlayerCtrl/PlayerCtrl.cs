using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private bool bIsJumping;
    public float JumpPower = 9f; // 점프 힘
    public float fallMultiplier = 2.5f;  // 떨어질 때 중력 가속도
    public float lowJumpMultiplier = 2f; // 낮은 점프 가속도
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bIsJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        ApplyGravityModifiers();

    }

    private void Jump()// 화면을 누르면 플레이어가 점프를 합니다
    {
        if (!bIsJumping && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.LogWarning("점프키를 눌렀습니다");
            bIsJumping = true;
            rb.velocity = Vector2.up * JumpPower;  // Impulse 대신 velocity로 바로 점프
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            Debug.LogWarning("GROUND");
            bIsJumping = false;
        }
    }
    private void Hit()
    {
        // 플레이어가 맞는 판정 <-얘는 OnCollisionEnter2D로 가는게 나을듯?
    }

    private void Attack()
    {
        //시간 남을때 구현 예정
    }

    private void UseItem()
    {
        //시간남을때 구현 예정
    }

    private void GetItem()
    {
        //시간남을때 구현 예정

    }

    private void ButtonAttack()
    {
        //시간남을때 구현 예정
    }

    //private void Gravity()
    //{
    //    // 떨어지는 속도가 부족하므르 ApplyGravityModifiers()로 이동
    //}

    // 추가적인 중력 조정 (플레이어가 더 빠르게 떨어지도록)
    private void ApplyGravityModifiers()
    {
        if (rb.velocity.y < 0)  // 플레이어가 하강 중일 때
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Mouse0))  // 플레이어가 점프 중이고, 점프키를 누르고 있지 않을 때
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


}
