using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0; // VSync 비활성화
        Application.targetFrameRate = 60; // 60 FPS로 고정
        Time.fixedDeltaTime = 1.0f / 60.0f; // 물리 연산도 60 FPS에 맞춤
    }

    // Update is called once per frame
    void Update()
    {

    }

    //게임 시작 버튼
    public void StartGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    //게임 오버UI 전환
    public void GameOver()
    {
        scoreManager.SaveCurrentScore(); // 현재 점수 저장
        SceneManager.LoadScene("GameOverScene"); // 게임 오버 씬 로드
        
    }

    //게임 재시작
    public void RestartGame()
    {
        
        SceneManager.LoadScene("TitleScene"); // 씬 다시 로드
    }

    //게임 일시정지
    public void PauseGame()
    {
        //Time.timeScale = Time.timeScale == 0 ? 1 : 0; // 시간 정지/재개
    }

    //카운트다운을 한 후 게임을 실행시킵니다. StartGame()
    private void CountDown()
    {

    }
}
