using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    private void Awake()
    {
        // 画面を移動しても削除されないようにする
        DontDestroyOnLoad(gameObject);
    }

    // プレイボタンが押された時の処理
    public void PlayGame()
    {
        // BattleSceneに移動する
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        // メニューで再生している曲を止める
        audioManager.Stop("Theme");

        // バトルシーンの曲を再生する
        audioManager.Play("Battle");
        
    }

    // ゲーム終了ボタンが押された時の処理
    public void QuitGame()
    {
        // アプリを終了される
        Application.Quit();
    }


}
