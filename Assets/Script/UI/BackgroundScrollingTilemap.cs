using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundScrollingTilemap : MonoBehaviour
{
    [SerializeField]
    private Transform target; // 현재 배경과 이어지는 타겟
    [SerializeField]
    private float scrollAmount; // 이어지는 두 배경 사이의 거리
    [SerializeField]
    private float parallaxFactor = 1.0f; // Parallax 효과를 위한 속도 조정 변수
    [SerializeField]
    private Vector3 moveDirection; // 이동 방향

    private float baseMoveSpeed; // 기본 이동 속도
    private float moveSpeed; // Parallax 적용된 이동 속도
    private ObstacleManager obstacleManager; // 장애물 매니저 참조

    private void Start()
    {
        // 장애물 매니저를 찾아서 참조합니다.
        obstacleManager = FindObjectOfType<ObstacleManager>();
    }

    private void FixedUpdate()
    {
        ParallaxBackGround();
    }

    private void ParallaxBackGround()
    {

        // 장애물 매니저의 기본 속도와 연동
        if (obstacleManager != null)
        {
            baseMoveSpeed = obstacleManager.GetCurrentSpeed(); // 장애물 매니저의 속도 가져오기
        }

        // Parallax 효과를 적용한 이동 속도 계산
        moveSpeed = baseMoveSpeed * parallaxFactor;

        // 배경이 MoveDirection 방향으로 Parallax 적용된 MoveSpeed의 속도로 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 배경이 설정한 범위를 벗어나면 위치 재설정
        if (transform.position.x <= -scrollAmount)
        {
            transform.position = target.position - moveDirection * scrollAmount;
        }
    }
}
