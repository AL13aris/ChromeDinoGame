using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI curr;
    public TextMeshProUGUI high;
    public float curr_time;
    public float high_time;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curr_time += Time.deltaTime * 10;
        curr.text = "" + Mathf.Round(curr_time);

        if (curr_time > high_time)
        {
            high.text = "" + Mathf.Round(high_time);
        }
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
