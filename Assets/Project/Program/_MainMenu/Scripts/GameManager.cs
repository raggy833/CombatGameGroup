using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // ボタンを押した時の処理
    public void OnClickChangeSceneButton(string sceneName)
    {
        // 引数の画面に遷移する
        SceneManager.LoadScene(sceneName);
    }

}
