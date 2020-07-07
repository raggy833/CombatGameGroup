using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
	// メンバ変数宣言
    public GameManager gameManager;	// ゲームマネージャー
	public GameObject bulletPrefab; // 弾のプレハブ
	private int health; // 体力
	private Slider playerHPSlider;//HPスライダー
	private int pEnergy; //プレーヤーenergy
	private int pMaxEnergy;//プレーヤーのMAXenergy

	// 起動時に１回だけ呼び出されるメソッド
	void Start ()
	{
		health = 3;
		pEnergy = 0;
		pMaxEnergy = 5;
        gameManager.SetInitialPlayerHealthUI (health);//初期体力をUIに表示
		gameManager.SetPlayerEnergyUI (pEnergy , pMaxEnergy);//初期エネルギーセット

	}

	// 毎フレーム呼び出されるメソッド
	void Update ()
	{
		// -----移動処理-----
		// マウスカーソルの座標をVector2型変数cursorPosに取得
		Vector2 cursorPos = Input.mousePosition;
		// cursorPos内の座標データをスクリーン座標からワールド座標に変換する
		cursorPos = Camera.main.ScreenToWorldPoint (cursorPos);
		// Transformコンポーネントのpositionに計算したcursorPosを代入
		transform.position = cursorPos;

		// -----弾発射処理-----
		if (Input.GetMouseButtonDown (0))
		{ // 左クリックを押された瞬間
		  // GameObject型ローカル変数を宣言 (生成したインスタンスを格納する)
			GameObject obj;
			// 弾プレハブのインスタンスを生成し、変数objに格納
			obj = Instantiate (bulletPrefab);
			// 弾インスタンスの座標にプレイヤーの座標をセット
			obj.transform.position = transform.position;
			// インスタンスのオブジェクト名を変更(敵弾と区別するため)
			obj.name = "PlayerBullet";
			//スライダー確認
			health--;
			gameManager.SetPlayerHealthUI (health);//テキスト表示
		}

		//エネルギー蓄積
		if (Input.GetKeyDown (KeyCode.Space))
		{ //スペースキーを押された瞬間
		  //エネルギーが1溜まる
		  pEnergy++;
		  //UI表示
		  gameManager.SetPlayerEnergyUI(pEnergy,pMaxEnergy);
		}
		//エネルギー消費（必殺技）
		if (Input.GetKeyDown (KeyCode.LeftControl))
		{
			//もしエネルギーがMAXだったら必殺技可能＆エネルギー消費
			if(pEnergy == pMaxEnergy)
			{
				pEnergy = 0;
				gameManager.SetPlayerEnergyUI(pEnergy , pMaxEnergy);
			}
		}
	}

	// 当たり判定内に他オブジェクトが侵入した際呼び出されるメソッド
	void OnTriggerEnter2D (Collider2D collider)
	{
		// ボスが発射した弾でなければ処理を終了
		if (collider.gameObject.name != "EnemyBullet")
		{ // 接触オブジェクト名がEnemyBulletで無ければ
			return; // メソッド終了
		}

		// 弾オブジェクトを消滅させる
		Destroy (collider.gameObject);

		// 自身の体力を1減らす
		health--;
        // 現在体力をUIに表示
		gameManager.SetPlayerHealthUI (health);//テキスト表示

		// プレイヤー消滅処理
		if (health <= 0)
		{// プレイヤーの体力が0以下
			Destroy (gameObject); // 自オブジェクト消去
		}
	}
}
