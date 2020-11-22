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
    // 特定アクション判定用変数
    private string action_key = "";
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


    // 左右入力を左右判定用変数に保存
    // 特定キー入力をアクション判定用変数に保存
    void GetInputKey()
    {

        key = 0;
        action_key = "";
        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;
        if (Input.GetKey(KeyCode.F))
            action_key = "attack";
        if (Input.GetKey(KeyCode.T))
            action_key = "taunt";
        if (Input.GetKey(KeyCode.D))
            action_key = "down";
        if (Input.GetKey(KeyCode.S))
            action_key = "damaged";
        if (Input.GetKey(KeyCode.G))
            action_key = "guard";
        if (Input.GetKey(KeyCode.C))
            action_key = "confused";


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

                // 徒歩状態を保存
                state = "WALK";

                // 左右入力の切り替えによりキャラクターの反転
                GetComponent<SpriteRenderer>().flipX = false;
                transform.localScale = new Vector3(key, 1, 1);

            }
            // 攻撃状態を保存
            else if (action_key == "attack")
            {
                state = "ATTACK";
            }
            // 叫ぶ状態を保存
            else if (action_key == "taunt")
            {
                state = "TAUNT";
            }
            // 叫ぶ状態を保存
            else if (action_key == "down")
            {
                state = "DOWN";
            }
            // 被ダメージ状態を保存
            else if (action_key == "damaged")
            {
                state = "DAMAGED";
            }
            // ガード状態を保存
            else if (action_key == "guard")
            {
                state = "GUARD";
            }
            // 混乱状態を保存
            else if (action_key == "confused")
            {
                state = "CONFUSED";
            }
            else
            {
                // アイドル状態保存
                state = "IDLE";
            }
        }
        else
        {
            // ジャンプの体勢
            state = "JUMP";
        }
        action_key = "";
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
                    animator.SetBool("isConfused", false);
                    animator.SetBool("isGuarded", false);
                    animator.SetBool("isDamaged", false);
                    animator.SetBool("isJump", true);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isTaunt", false);
                    animator.SetBool("isDown", false);
                    break;
                case "WALK":
                    // 歩く体勢の設定
                    animator.SetBool("isConfused", false);
                    animator.SetBool("isGuarded", false);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isTaunt", false);
                    animator.SetBool("isDown", false);
                    animator.SetBool("isDamaged", false);
                    break;
                case "ATTACK":
                    // 攻撃体勢の設定
                    animator.SetBool("isConfused", false);
                    animator.SetBool("isGuarded", false);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isAttack", true);
                    animator.SetBool("isTaunt", false);
                    animator.SetBool("isDown", false);
                    animator.SetBool("isDamaged", false);
                    break;
                case "TAUNT":
                    // 叫ぶ体勢の設定
                    animator.SetBool("isConfused", false);
                    animator.SetBool("isGuarded", false);
                    animator.SetBool("isDamaged", false);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isTaunt", true);
                    animator.SetBool("isDown", false);
                    break;
                case "DOWN":
                    // 倒れる体勢の設定
                    animator.SetBool("isConfused", false);
                    animator.SetBool("isGuarded", false);
                    animator.SetBool("isDamaged", false);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isTaunt", false);
                    animator.SetBool("isDown", true);
                    break;
                case "DAMAGED":
                    // ダメージ体勢の設定
                    animator.SetBool("isConfused", false);
                    animator.SetBool("isGuarded", false);
                    animator.SetBool("isDamaged", true);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isTaunt", false);
                    animator.SetBool("isDown", false);
                    break;
                case "GUARD":
                    // ガード体勢の設定
                    animator.SetBool("isConfused", false);
                    animator.SetBool("isGuarded", true);
                    animator.SetBool("isDamaged", false);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isTaunt", false);
                    animator.SetBool("isDown", false);
                    break;
                case "CONFUSED":
                    // 混乱体勢の設定
                    animator.SetBool("isConfused", true);
                    animator.SetBool("isGuarded", false);
                    animator.SetBool("isDamaged", false);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isTaunt", false);
                    animator.SetBool("isDown", false);
                    break;
                default:
                    // 立っている体勢の設定
                    animator.SetBool("isConfused", false);
                    animator.SetBool("isGuarded", false);
                    animator.SetBool("isDamaged", false);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isIdle", true);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isTaunt", false);
                    animator.SetBool("isDown", false);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }

    }

}
