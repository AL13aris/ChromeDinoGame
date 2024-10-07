using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Obstacle : MonoBehaviour
{
    public float ObstacleMoveSpeed;
    Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
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
        rb.AddForce(Vector2.left * ObstacleMoveSpeed ,ForceMode2D.Force);
        //장애물이 왼쪽으로 움직이게
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
