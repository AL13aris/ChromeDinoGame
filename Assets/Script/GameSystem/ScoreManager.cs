using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI curr;
    public TextMeshProUGUI high;
    public float curr_time;
    public float high_time;


    // Start is called before the first frame update
    void Start()
    {
        // 게임이 처음 실행되는 경우 기존 점수 초기화
        if (!PlayerPrefs.HasKey("HasPlayedBefore"))
        {
            PlayerPrefs.SetFloat("HighScore", 0);
            PlayerPrefs.SetFloat("CurrentScore", 0);
            PlayerPrefs.SetInt("HasPlayedBefore", 1); // 첫 실행 표시
            PlayerPrefs.Save();
        }

        // 게임 시작 시 최고 점수를 불러옵니다.
        high_time = PlayerPrefs.GetFloat("HighScore", 0);
        high.text = Mathf.Round(high_time).ToString(); // 최고 점수만 표시
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        CheckAndSaveHighScore();

    }

    //현재점수를 계속 증가
    private void UpdateScore()
    {
        curr_time += Time.deltaTime * 10;
        curr.text = "" + Mathf.Round(curr_time);
    }

    // 현재 점수가 최고 점수를 넘으면 갱신하고 저장
    private void CheckAndSaveHighScore()
    {
        if (curr_time > high_time)
        {
            high_time = curr_time;
            high.text = Mathf.Round(high_time).ToString(); // 최고 점수만 표시
            SaveHighScore();
        }
    }


    //최고점수를 저장
    //private void SaveScore() 아래로 변경
    private void SaveHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", high_time);
        PlayerPrefs.Save(); // 저장을 즉시 적용
    }

    // 현재 점수 저장 메서드 (게임 오버 시 호출)
    public void SaveCurrentScore()
    {
        PlayerPrefs.SetFloat("CurrentScore", curr_time);
        PlayerPrefs.Save();
    }

}
