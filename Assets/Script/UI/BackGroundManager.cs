using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{

    public float speed;
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
        offset_x += (speed * Time.deltaTime);

        Vector2 offset = new Vector2(offset_x, 0);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);

    }

    //일정 점수마다 속도를 증가
    private void UpdateSpeed()
    {

    }
}
