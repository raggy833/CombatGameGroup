using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region 定義
    // CharacterController2Dスクリプトの定義
    public CharacterController2D controller;
    // アニメーターの定義
    private Animator animator;
    // Rigidbody2Dの定義
    private Rigidbody2D myRigidbody2D;

    // パンチ当たり判定のポジション
    public Transform punchAttackPoint;
    // 当たり判定の範囲
    public float punchAttackRange = 0.5f;
    // 敵のレイヤー
    public LayerMask enemyLayers;

    // 攻撃速度
    public float attackRate = 2f;
    // 次の攻撃までの時間
    private float nextAttackTime = 0f;

    // ノックバックの定義
    #region knockback defines
    public float knockbackAmountX;
    public float knockbackAmountY;
    public float knockbackDuration;
    public float knockbackCounter;
    public bool knockbackFromRight;
    #endregion

    // 移動スピードの調整
    [SerializeField] private float runSpeed = 40f;
    // 移動スピードの定義
    private float horizontalMove = 0f;
    // ジャンプの定義
    private bool jump = false;
    // しゃがみの定義
    private bool crouch = false;

    // test play bool
    [SerializeField]
    private bool inControl;

    // スピードを0にする値
    private const int ZERO_SPEED = 0;

    #endregion

    private void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!inControl)
        {
            return;
        }
        // 
        KnockbackChecker();
    }

    private void FixedUpdate() 
    {

        // Moveのメソッドを呼ぶ
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        // jumpをfalseに変更
        jump = false;
    }

    // ノックバック中か確認
    private void KnockbackChecker()
    {
        if (knockbackCounter <= 0)
        {
            MovementControl();
        }
        else
        {
            KnockbackControl();
        }
    }

    // ノックバックの処理
    private void KnockbackControl()
    {
        if (knockbackFromRight)
        {
            myRigidbody2D.velocity = new Vector2(-knockbackAmountX, knockbackAmountY);
        }
        if (!knockbackFromRight)
        {
            myRigidbody2D.velocity = new Vector2(knockbackAmountX, knockbackAmountY);
        }
        knockbackCounter -= Time.deltaTime;
    }

    // 移動の処理
    private void MovementControl()
    {
        // 左右のインプットの値を移動スピードに保管
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // アニメーターに現在のスピードを設定する
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        // nextAttackTimeがTimeより少ない場合
        if (Time.time >= nextAttackTime)
        {
            // Qキーが押された時
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PunchAttack();
                // 1秒に2回攻撃できるように設定
                nextAttackTime = Time.time + 1f / attackRate;
            }
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

    // パンチの処理
    public void PunchAttack()
    {
        // アニメーターのトリガーを設定する
        animator.SetTrigger("Punch");
        // 移動速度を0にする
        horizontalMove = ZERO_SPEED;

        // Detect enemy in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(punchAttackPoint.position, punchAttackRange, enemyLayers);

        // 攻撃が当たった敵への処理
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
        }
    }

    // パンチの当たり判定にGizmo表示
    private void OnDrawGizmosSelected()
    {
        if(punchAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(punchAttackPoint.position, punchAttackRange);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Got hit");
            if(collision.gameObject.transform.position.x >= gameObject.transform.position.x)
            {
                knockbackFromRight = true;
            }
            else
            {
                knockbackFromRight = false;
            }
            knockbackCounter = knockbackDuration;
            KnockbackControl();
        }
    }
}
