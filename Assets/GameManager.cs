using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI機能の利用に必要なusing文

public class GameManager : MonoBehaviour
{
    	// メンバ変数宣言
	public int currentRoundNum = 0;//ラウンド番号
	public GameObject popup;

	public Slider playerHPSlider;//プレーヤーHPスライダー
	public Slider enemyHPSlider;//敵HPスライダー
	public Image playerEnergy;//プレーヤーエネルギー
	public Image enemyEnergy;//敵エネルギー

	//ラウンド開始処理
	public void NextRound(){
		currentRoundNum += 1;//ラウンド数加算
		popup.SetActive(false);//ゲームセット画面を非表示に
	}
	// プレイヤーの残り体力をUIに適用(PlayerControllerから呼び出される)
	// 引数health : 残り体力
	public void SetInitialPlayerHealthUI (int health)
	{
		playerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();//gameObjから探している
		playerHPSlider.maxValue = health;//HPのMAXはプレーヤーの体力
		playerHPSlider.value = health;//HPの初期値はプレーヤーの体力
	}
	public void SetPlayerHealthUI (int health)
	{
		playerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();//gameObjから探している
		playerHPSlider.value = health;//HPの初期値はプレーヤーの体力
	}

	// ボスの残り体力をUIに適用(BossControllerから呼び出される)
	public void SetInitialEnemyHealthUI (int health)
	{
		enemyHPSlider = GameObject.Find("EnemyHPSlider").GetComponent<Slider>();//gameObjから探している
		enemyHPSlider.maxValue = health;//HPのMAXはプレーヤーの体力
		enemyHPSlider.value = health;//HPの初期値はプレーヤーの体力
	}
	public void SetEnemyHealthUI (int health)
	{
		enemyHPSlider = GameObject.Find("EnemyHPSlider").GetComponent<Slider>();//gameObjから探している
		enemyHPSlider.value = health;//HPの初期値はプレーヤーの体力
	}

	//エネルギー蓄積
	public void SetPlayerEnergyUI (int energy , int maxEnergy)
	{
		//蓄積しているエネルギー割合を算出
		float ratio;
		ratio = (float)energy / maxEnergy;
		//UIに反映
		playerEnergy.fillAmount = ratio;
		//エネルギーがMAXになったらMAXUI表示
		if(ratio == 1)
		{
			playerEnergy.color = new Color(210.0f , 15.0f, 15.0f ,1.0f);
		}
	}

	public void SetEnemyEnergyUI (int energy , int maxEnergy)
	{
		//蓄積しているエネルギー割合を算出
		float ratio;
		ratio = (float)energy / maxEnergy;
		//UIに反映
		enemyEnergy.fillAmount = ratio;
		//エネルギーがMAXになったらMAXUI表示
		if(ratio == 1)
		{
			playerEnergy.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
		}else{
			playerEnergy.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
		}
	}

	public void GameSet(){
		//ゲーム結果をpopupにセット

		popup.SetActive(true);//ゲームセット画面を表示
	}

}
