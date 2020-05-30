using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMovement : MonoBehaviour
{
    // Rigidbody2Dの定義
    public Rigidbody2D rb;
    // Animatorの定義
    public Animator animator;
    // 接地判定オブジェクト定義
    public GroundCheck ground;
    // 接地判定用変数
    bool isGround = false;

    // 左右判定用変数
    private int key = 0;
    // キャラクターの現在の体勢  
    private string state;
    // キャラクターの遷移前体勢
    private string prevState;


    // ジャンプ時に加える力
    private float jumpForce = 300f;

    // 走っている間の速度
    private float runSpeed = 0.1f;

    // Start is called before the first frame update ←デフォルトのコメント
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame　←デフォルトのコメント
    void FixedUpdate()
    {
        // キーボード入力を取得
        GetInputKey();

        // キャラクターの体勢遷移
        ChangeState();

        // 体勢に合わせてアニメーションを設定          
        ChangeAnimation();

        // 地面と接している時に上矢印キー押下でジャンプ 
        VerticalMove();

        // 左右の入力に応じて水平移動
        HorizontalMove();

    }


    // キーボード入力を左右判定用変数に保存
    void GetInputKey()
    {
        key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;

    }

    // 水平移動用メソッド
    void HorizontalMove()
    {
        // 方向keyにrunspeedを掛けた値をスピードとして水平移動
        this.transform.position += new Vector3(runSpeed * key, 0, 0);

    }


    // 垂直移動用メソッド
    void VerticalMove()
    {
        // 接地判定
        isGround = ground.IsGround();

        // 設置している場合は矢印上キー押下すると垂直方向にジャンプ
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // ジャンプ時に加える力のみで垂直方向に移動
                this.rb.AddForce(transform.up * this.jumpForce);
            }
        }
    }


    // キャラクターの現在の体勢を保存するメソッド
    void ChangeState()
    {
        // 接地状態を確認
        isGround = ground.IsGround();

        // 地上or空中の体勢判断
        if (isGround)
        {
            // 左右移動の判断
            if (key == 1 || key == -1)
            {

                // 歩く体勢
                state = "WALK";

                // 左右入力の切り替えによりキャラクターの反転
                GetComponent<SpriteRenderer>().flipX = false;
                transform.localScale = new Vector3(key, 1, 1);

            }
            else
            {
                // アイドル体勢
                state = "IDLE";
            }
        }
        else
        {
            // ジャンプの体勢
            state = "JUMP";
        }
    }


    // キャラクターの現在の状態によってアニメーションを設定するメソッド
    void ChangeAnimation()
    {
        // 状態が変わった場合のみアニメーションを変更する
        if (prevState != state)
        {
            switch (state)
            {
                case "JUMP":
                    // ジャンプ体勢の設定
                    animator.SetBool("isJump", true);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", false);
                    break;
                case "WALK":
                    // 歩く体勢の設定
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isIdle", false);
                    break;
                default:
                    // 立っている体勢の設定
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }

    }

}
