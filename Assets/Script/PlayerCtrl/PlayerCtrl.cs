using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private bool bIsJumping;
    public float JumpPower;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bIsJumping = false;
        JumpPower = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bIsJumping)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                Debug.LogWarning("점프키를 눌렀습니다");

                Jump();

            }
        }
       



    }

    private void Jump()
    {
        Debug.LogWarning("JUMP");
        bIsJumping = true;
        rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            Debug.LogWarning("GROUND");
            bIsJumping = false ;
        }
    }
}
