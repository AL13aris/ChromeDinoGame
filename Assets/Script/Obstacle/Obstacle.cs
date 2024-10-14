using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Obstacle : MonoBehaviour
{

    public float initialMoveSpeed = 5f;  // 초기 속도
    public float acceleration = 0.001f;    // 초당 가속도 (속도 증가율)
    private float currentMoveSpeed;      // 현재 속도
    Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMoveSpeed = initialMoveSpeed;  // 초기 속도로 설정
        rb.velocity = Vector2.left * currentMoveSpeed;  // 왼쪽으로 초기 속도로 이동 시작

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            
        }
        if(collision.gameObject.CompareTag("REMOVEOB"))
        {
            Destroy(this.gameObject);
        }
        //Hit() 대체
    }

    private void Move()
    {

        // 매 프레임마다 가속도를 추가
        currentMoveSpeed += acceleration * Time.deltaTime;

        // 속도가 업데이트된 상태로 계속 이동
        rb.velocity = Vector2.left * currentMoveSpeed;
    }

    private void Crash()
    {
        //PlayerCrash->Crash로 변경
        //플레이어와 충돌하면 본인 삭제
        //
    }

    private void UpdateSpeed()
    {
        //시간이 지날때마다 속도 증가
    }


}
