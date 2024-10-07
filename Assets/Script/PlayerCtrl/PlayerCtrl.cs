using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private bool bIsJumping;
    public float JumpPower;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bIsJumping = false;
        JumpPower = 8;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

    }

    private void Jump()// 화면을 누르면 플레이어가 점프를 합니다
    {
        if (!bIsJumping)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                Debug.LogWarning("점프키를 눌렀습니다");

                Debug.LogWarning("JUMP");
                bIsJumping = true;
                rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);

            }
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
    //    //필요 없음 유니티 엔진 내부에서 자체 처리
    //}




}
