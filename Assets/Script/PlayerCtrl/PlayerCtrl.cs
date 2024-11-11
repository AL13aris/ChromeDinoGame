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

    private Animator animator;

    public VibrationManager vibrationManager;

    // 새로운 변수 추가
    private bool isPlayerDead = false; // 플레이어의 죽음 상태를 관리하는 변수
    private SpriteRenderer spriteRenderer; // SpriteRenderer 참조 추가

    private Collider2D playerCollider; // 충돌 컴포넌트 참조 추가

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 가져오기
        playerCollider = GetComponent<Collider2D>(); // Collider2D 가져오기
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

            // 애니메이션 상태 변경
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);

            // 500ms 동안 진동 0~255까지 진동 세기 조절 0:진동 없음 255:최대 진동
            vibrationManager.TriggerCustomVibration(100,128);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("ENEMY"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("GROUND"))
        {
            Debug.LogWarning("GROUND");
            bIsJumping = false;

            // 땅에 닿았을 때 애니메이션 상태를 초기화
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            Debug.Log("Landed on Ground - IsJumping: false, IsFalling: false");

        }
    }

    private void Die()
    {
        isPlayerDead = true;
        animator.SetBool("IsDead", true); // 죽음 애니메이션 트리거
        rb.velocity = Vector2.zero; // 움직임 멈춤
        rb.isKinematic = false; // 물리 연산 중지 (필요에 따라 설정)
        rb.gravityScale = 1f;

        // 패턴 진동: 즉시 진동 시작, 500ms 진동, 200ms 멈춤, 500ms 진동 반복 (-1은 반복 없음)
        long[] pattern = { 0, 100, 50, 100 };
        int[] amplitudes = { 0, 50, 0, 128 }; // 진동 강도 배열 0~255까지
        int repeat = -1; // 반복 없음
        vibrationManager.TriggerPatternVibration(pattern, amplitudes, repeat);

        Debug.Log("Player has died!");

        rb.gravityScale = 1f; // 중력을 기본값으로 설정
        // 충돌 비활성화
        playerCollider.enabled = false;
        // 깜빡임 효과를 시작
        StartCoroutine(FadeAndDestroy());
    }

    private IEnumerator FadeAndDestroy()
    {
        float fadeDuration = 1f; // 깜빡이는 총 시간
        float fadeInterval = 0.1f; // 깜빡이는 간격
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // 투명도 변경 (깜빡임)
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(fadeInterval);
            elapsedTime += fadeInterval;
        }

        // 완전히 깜빡임이 끝난 후 오브젝트 제거
        Destroy(gameObject);
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


           
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
            
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Mouse0))  // 플레이어가 점프 중이고, 점프키를 누르고 있지 않을 때
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

            // 하강 중이 아니므로 Falling을 false로 설정
            animator.SetBool("IsFalling", false);
        }
    }


}
