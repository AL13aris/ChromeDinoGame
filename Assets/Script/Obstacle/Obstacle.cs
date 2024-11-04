using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Obstacle : MonoBehaviour
{
    
    
    public VibrationManager vibrationManager;

    public float initialMoveSpeed = 5f;  // 초기 속도
    public float acceleration = 0.001f;    // 초당 가속도 (속도 증가율)

    
    // 모든 장애물이 공유하는 속도 (static으로 설정)
    [SerializeField]
    private static float currentMoveSpeed;

    Rigidbody2D rb;


    private ObstacleManager obstacleManager;  // 장애물 매니저 참조




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ObstacleManager를 찾아서 참조
        obstacleManager = FindObjectOfType<ObstacleManager>();

        rb.velocity = Vector2.left * currentMoveSpeed;  // 왼쪽으로 초기 속도로 이동 시작

        if(vibrationManager == null)
        {
            vibrationManager = FindObjectOfType<VibrationManager>();
        }



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
            // 패턴 진동: 즉시 진동 시작, 500ms 진동, 200ms 멈춤, 500ms 진동 반복 (-1은 반복 없음)
            long[] pattern = { 0, 500, 200, 1000 };
            int[] amplitudes = { 0, 30, 0, 100 }; // 진동 강도 배열 0~255까지
            int repeat = -1; // 반복 없음
            vibrationManager.TriggerPatternVibration(pattern, amplitudes, repeat);
            
        }
        if(collision.gameObject.CompareTag("REMOVEOB"))
        {
            Destroy(this.gameObject);
        }
        //Hit() 대체
    }

    private void Move()
    {

        // 장애물 매니저로부터 현재 속도를 가져와서 이동
        float currentSpeed = obstacleManager.GetCurrentSpeed();
        rb.velocity = Vector2.left * currentSpeed;

    }

    private void Crash()
    {
        //PlayerCrash->Crash로 변경
        //플레이어와 충돌하면 본인 삭제
        //
    }

    //private void UpdateSpeed()
    //{
    //    //시간이 지날때마다 속도 증가<-장애물 매니저로 이동
    //}


}
