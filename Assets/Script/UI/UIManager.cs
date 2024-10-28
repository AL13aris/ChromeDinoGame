using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText; // 최고 점수 텍스트 UI
    public TextMeshProUGUI currentScoreText;

    // Start is called before the first frame update
    private void Start()
    {
        // PlayerPrefs에서 최고 점수를 불러옵니다.
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = Mathf.Round(highScore).ToString(); // 최고 점수만 표시
        float currentScore = PlayerPrefs.GetFloat("CurrentScore", 0);
        currentScoreText.text = Mathf.Round(currentScore).ToString();
    }


    // Update is called once per frame
    void Update()
    {

    }

    //게임오버 UI 표시
    private void ShowGameOver()
    {

    }

    //게임시작 UI 표시
    private void ShowGameStart()
    {

    }

    //일시정지 UI 표시
    private void ShowPauseUI()
    {

    }

    //점수가 변할때마다 UI를 갱신
    public void UpdateScoreUI()
    {

    }


}
