using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject groundObstaclePrefab; // 지상 장애물 프리팹  <---- 새로 추가
    public GameObject airObstaclePrefab;    // 공중 장애물 프리팹  <---- 새로 추가


    public Transform[] groundSpawnPoints;   // 지상 스폰 포인트 배열  <---- 새로 추가
    public Transform[] airSpawnPoints;      // 공중 스폰 포인트 배열  <---- 새로 추가

    public float groundMinSpawnTime = 2f;   // 지상 장애물 최소 소환 시간 간격 <---- 새로 추가
    public float groundMaxSpawnTime = 5f;   // 지상 장애물 최대 소환 시간 간격 <---- 새로 추가
    public float airMinSpawnTime = 3f;      // 공중 장애물 최소 소환 시간 간격 <---- 새로 추가
    public float airMaxSpawnTime = 6f;      // 공중 장애물 최대 소환 시간 간격 <---- 새로 추가

    public float initialMoveSpeed = 5f;  // 장애물들의 초기 속도
    public float acceleration = 0.001f;  // 초당 가속도 (속도 증가율)
    private float currentMoveSpeed;      // 현재 속도

    public BackGroundManager backgroundManager;  // 배경 관리자 참조
    public float backgroundSpeedMultiplier = 0.05f;  // 배경 속도 증가율 (장애물 속도에 대한 배수)

    private GameManager gameManager; // GameManager 참조 변수 <---- 새로 추가

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GroundObstacleSpawnRoutine());  // 지상 장애물 스폰 코루틴 시작 <---- 새로 추가
        StartCoroutine(AirObstacleSpawnRoutine());     // 공중 장애물 스폰 코루틴 시작 <---- 새로 추가
        ResetSpeed();  // 게임 시작 시 속도 초기화
        // BackGroundManager를 찾아서 참조 (씬에 존재하는 오브젝트를 찾음)
        backgroundManager = FindObjectOfType<BackGroundManager>();

        // GameManager 인스턴스를 찾아 참조 설정 <---- 새로 추가
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 가속도를 추가하여 속도를 증가시킴
        UpdateSpeed();

        // 배경 속도를 장애물 속도와 연동
        if (backgroundManager != null)
        {
            backgroundManager.UpdateSpeed(currentMoveSpeed * backgroundSpeedMultiplier);  // 배경 속도는 장애물 속도의 배수로 설정
        }


        // 플레이어가 존재하지 않으면 GameOver 호출
        if (GameObject.FindWithTag("Player") == null)
        {
            gameManager.GameOver();
        }

    }

    private void UpdateSpeed()
    {
        // 매 프레임마다 가속도를 추가하여 속도를 증가시킴
        currentMoveSpeed += acceleration * Time.deltaTime;
    }

    private void SpawnObstacle()
    {
        //장애물을 일정 시간마다 스폰
    }

    //private void SpawnPosition()<- 코루틴으로 변경
    //{
    //    //장애물 스폰 위치 정하기
    //}

    // 장애물을 소환하는 코루틴
   

    // 지상 장애물을 스폰하는 코루틴
    IEnumerator GroundObstacleSpawnRoutine()  // <---- 새로 추가
    {
        while (true)
        {
            float spawnInterval = Random.Range(groundMinSpawnTime, groundMaxSpawnTime); // <---- 새로 추가
            int spawnIndex = Random.Range(0, groundSpawnPoints.Length);
            Instantiate(groundObstaclePrefab, groundSpawnPoints[spawnIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval); // <---- 새로 추가
        }
    }

    // 공중 장애물을 스폰하는 코루틴
    IEnumerator AirObstacleSpawnRoutine()  // <---- 새로 추가
    {
        while (true)
        {
            float spawnInterval = Random.Range(airMinSpawnTime, airMaxSpawnTime); // <---- 새로 추가
            int spawnIndex = Random.Range(0, airSpawnPoints.Length);
            Instantiate(airObstaclePrefab, airSpawnPoints[spawnIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval); // <---- 새로 추가
        }
    }

    private void SpawnItem()
    {
        //시간 남을때 구현 예정

    }
    // 현재 속도를 반환하는 함수
    public float GetCurrentSpeed()
    {
        return currentMoveSpeed;
    }

    // 게임 재시작 또는 처음 시작 시 속도를 초기화하는 함수
    public void ResetSpeed()
    {
        currentMoveSpeed = initialMoveSpeed;
    }

    //private void Remove()
    //{
    //    //장애물 삭제 <-Obstacle로 이동
    //}

    //private void BirdArray()
    //{
    //    //구현 안 할수도 있음
    //}

    //private void MushroomArray()
    //{
    //    //구현 안 할수도 있음
    //}

}
