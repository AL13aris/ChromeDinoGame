using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Hit() 대체
    }

    private void Move()
    {
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
