using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;  // 소환할 장애물 프리팹
    public Transform spawnPosition;      // 소환할 위치
    public float minSpawnTime = 2f;    // 최소 소환 시간 간격
    public float maxSpawnTime = 5f;    // 최대 소환 시간 간격



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
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
    IEnumerator SpawnObstacleRoutine()
    {
        while (true) // 계속 반복
        {
            // 랜덤한 시간 간격 계산 (2초에서 5초 사이)
            float spawnInterval = Random.Range(minSpawnTime, maxSpawnTime);

            // 프리팹 소환
            Instantiate(obstaclePrefab, spawnPosition.position, Quaternion.identity);

            // 랜덤 시간만큼 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnItem()
    {
        //시간 남을때 구현 예정

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
