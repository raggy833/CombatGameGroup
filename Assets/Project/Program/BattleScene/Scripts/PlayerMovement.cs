using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region 定義
    // CharacterController2Dスクリプトの定義
    public CharacterController2D controller;
    // アニメーターの定義
    public Animator animator;

    // 移動スピードの調整
    [SerializeField] private float runSpeed = 40f;
    // 移動スピードの定義
    private float horizontalMove = 0f;
    // ジャンプの定義
    private bool jump = false;
    // しゃがみの定義
    private bool crouch = false;

    // スピードを0にする値
    private const int ZERO_SPEED = 0;

    #endregion


    private void Update()
    {
        // 左右のインプットの値を移動スピードに保管
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // アニメーターに現在のスピードを設定する
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Qキーが押された時
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // アニメーターのトリガーを設定する
            animator.SetTrigger("Punch");
            // 移動速度を0にする
            horizontalMove = ZERO_SPEED;
        }

        // Jumpボタンが押された時
        if (Input.GetButtonDown("Jump"))
        {
            // アニメーターのboolを設定する
            animator.SetBool("IsJumping", true);
            // jumpをtrueに変更
            jump = true;
        }

        // Crouchボタンが押された時
        if (Input.GetButtonDown("Crouch"))
        {
            // しゃがみをtrueに変更
            crouch = true;
        }
        // Crouchボタンが離された時
        else if (Input.GetButtonUp("Crouch"))
        {
            // しゃがみをfalseに変更
            crouch = false;
        }
    }

    // 地面に着地した時の処理
    public void OnLanding()
    {
        // アニメーターのboolを変更
        animator.SetBool("IsJumping", false);
    }

    // しゃがんでいる時の処理
    public void OnCrouching(bool isCrouching)
    {
        // アニメーターのboolを変更
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate() 
    {
        // Moveのメソッドを呼ぶ
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        // jumpをfalseに変更
        jump = false;
    }
}
