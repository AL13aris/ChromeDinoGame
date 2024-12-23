using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.U2D.Sprites;
#endif
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    
    public float speed = 0.25f;
    public float BackgroundSpeed = 0;

    [SerializeField]
    private float CurrentSpeed;
    
    float offset_x;



    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        ScrollBackGround();
        
    }

    //배경을 일정속도로 움직임
    public void ScrollBackGround()
    {
        offset_x += (BackgroundSpeed * speed * Time.deltaTime);

        Vector2 offset = new Vector2(offset_x, 0);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);

    }

    //일정 점수마다 속도를 증가
    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;  // 장애물 매니저에서 제공하는 속도로 배경 속도 업데이트
    }
}
