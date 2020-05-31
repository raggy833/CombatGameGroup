using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーキャラクターをジャンプさせる
// PlayerWalk2Dクラスから接地判定を受け取り、多段ジャンプをさせないよう制御する
public class PlayerJump : MonoBehaviour
{
    // 値はインスペクターから変更可能
    [SerializeField] float jumpPower = 100f;

    private PlayerWalk playerWalk;
    private Rigidbody2D rb;
    public Animator animator;

    private void Start()
    {
        // このスクリプトと同じゲームオブジェクトにアタッチされている、
        // PlayerWalk スクリプトのコンポーネントを取得する
        playerWalk = GetComponent<PlayerWalk>();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("jump", playerWalk.isGrounded);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 接地しているときのみ、ジャンプできる（多段ジャンプをさせない）
            if (playerWalk.isGrounded)
            {
                rb.AddForce(new Vector3 (0f, jumpPower));
            }
        }
    }
}
