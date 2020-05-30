using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public GroundCheck ground;

    bool isGround = false;   //接地判定
    int key = 0;    //左右判定のキー
    string state; //キャラクターの状態
    string prevState; // 前の状態



    float jumpForce = 300f;       // ジャンプ時に加える力
    float runSpeed = 0.1f;       // 走っている間の速度


    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GetInputKey();          // 入力を取得
        ChangeState();          // 状態遷移
        ChangeAnimation();      // 動きに合わせてアニメーションを設定
        Jump();                 // 地面と接している時に上矢印キー押下でジャンプ
        Move();                 // 入力に応じて移動

    }


    void GetInputKey()
    {
        key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;

    }

    void Move()
    {
        //方向keyとrunspeedによって決める
        this.transform.position += new Vector3(runSpeed * key, 0, 0);

    }


    void Jump()
    {
        isGround = ground.IsGround(); //接地判定
        // 設置している時矢印上キー押下でジャンプ
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.rb.AddForce(transform.up * this.jumpForce);
                isGround = false;
            }
        }
    }


    void ChangeState()
    {
        isGround = ground.IsGround();
        if (isGround)
        {
            if (key == 1 || key == -1)
            {
                //animator.SetBool("isWalk", true);
                state = "WALK";
                GetComponent<SpriteRenderer>().flipX = false;
                transform.localScale = new Vector3(key, 1, 1); // 向きに応じてキャラクターのspriteを反転

            }
            else
            {
                //animator.SetBool("isIdle", true);
                state = "IDLE";
            }
        }
        else
        {
            //animator.SetBool("isIdle", true);
            state = "JUMP";
        }
    }


    void ChangeAnimation()
    {
        // 状態が変わった場合のみアニメーションを変更する
        if (prevState != state)
        {
            switch (state)
            {
                case "JUMP":
                    animator.SetBool("isJump", true);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", false);
                    Console.WriteLine("Im jumping");
                    break;
                case "WALK":
                    //GetComponent<SpriteRenderer>().flipX = false;
                    //transform.localScale = new Vector3(key, 1, 1); // 向きに応じてキャラクターのspriteを反転
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isIdle", false);
                    Console.WriteLine("Im walking");
                    break;
                default:
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", true);
                    Console.WriteLine("Im standing");
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }

    }

}
