using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    private float H;

    private int jumpCount = 1;
    private int playerDirection = 1;

    Rigidbody2D rigid;
    Animator anim;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameStart)
        {
            Movement();
            Direction();
            MoveAnimation();
        }
        
    }
    void Movement()
    {
        H = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(H * MoveSpeed, rigid.velocity.y);
    }

    void MoveAnimation()
    {
        bool isRun = H == 0 ? false : true;
        anim.SetBool("isRun", isRun);
    }
    void Direction()
    {
        playerDirection = H != 0 ? (H > 0 ? 1 : -1) : playerDirection;
        transform.localScale = new Vector3(playerDirection, 1, 1);
    }
}
