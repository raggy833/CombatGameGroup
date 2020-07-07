using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 変数宣言
	private float speed = 3.0f; // スピード
	private float time = 0.0f;  // 経過時間

	// 起動時に１回だけ呼び出されるメソッド
	void Start () {
	}

	// 毎フレーム呼び出されるメソッド
	void Update ()
	{
		// -----移動処理-----
		// Transformコンポーネントからposition(座標)パラメータを取得
		Vector3 pos = transform.position;
		// 右に指定した速度で直進する
		pos.x += speed * Time.deltaTime;
		// Transformコンポーネントのpositionに変数posをセット
		transform.position = pos;

		// -----寿命処理-----
		// 前回のUpdate実行から経過した時間をtimeに加算
		time += Time.deltaTime;
		// 消滅処理
		if (time > 5.0f)
		{ // 弾の経過時間が５秒より大きければ
			Destroy (gameObject);
		}
	}
}
