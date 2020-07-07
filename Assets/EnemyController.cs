using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    	// メンバ変数宣言
    public GameManager gameManager;	// ゲームマネージャー
	public int health; // 体力HP

    // 起動時に１回だけ呼び出されるメソッド
	void Start ()
	{
		// 初期体力をUIに表示
		health = 5;
		gameManager.SetInitialEnemyHealthUI (health);
	}

	// 当たり判定内に他オブジェクトが侵入した際呼び出されるメソッド
	// 引数:接触オブジェクトしたオブジェクトのCollider情報
	void OnTriggerEnter2D (Collider2D collider)
	{
		// プレイヤーが発射した弾でなければ処理を終了
		if (collider.gameObject.name != "PlayerBullet")
		{ // 接触オブジェクト名がPlayerBulletで無ければ
			return; // メソッド終了
		}

		// 弾オブジェクトを消滅させる
		Destroy (collider.gameObject);

		// 自身の体力を1減らす
		health--;
        //現在体力を表示
        gameManager.SetEnemyHealthUI (health);
		// ボス消滅処理ゲームセット
		if (health <= 0)
		{// ボスの体力が0以下
			Destroy (gameObject); // 自オブジェクト消去
		}
	}
}
