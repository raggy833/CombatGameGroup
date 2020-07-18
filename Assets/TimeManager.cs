using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //変数宣言
    public GameManager gameManager;	// ゲームマネージャー

    //カウントダウン
    public float countdown = 60.0f;
 
    //時間を表示するText型の変数
    public Text timeText;
 
    //ポーズしているかどうか
    private bool isPose = false;

    // Update is called once per frame
    void Update()
    {
        //時間をカウントする
        countdown -= Time.deltaTime;
 
        //時間を表示する
        timeText.text = countdown.ToString("f1");
 
        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "TimeUp!";
            //結果画面のポップアップ
            gameManager.GameSet();
        }
    }
}
