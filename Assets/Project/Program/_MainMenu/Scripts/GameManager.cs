using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    //TODO ①デフォルト値をどうするか検討 <--初めてのLogin時
    //TODO ②再起動した時にどこで各ID情報を保持するのか <--2回目以降のLogin時
    public static int character_id;     //CharacterSelect画面で選択されたキャラクターのID
    public static int stage_id;         //StageSelect画面で選択されたステージのID
    public static int gameMode_id;      //GameSelect画面で選択されたゲームのID
    public static Dictionary<string, int> settings;   //Setting画面で選択した各種設定のIDの配列

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

    // 画面遷移用ボタン押下
    public void OnClickChangeSceneButton(string sceneName)
    {
        // 引数の画面に遷移する
        SceneManager.LoadScene(sceneName);
    }

    //各ID変更(character_id, stage_id, gameMode_id)
    public void ChangeId (string targetId, int id)
    {
        switch (targetId)
        {
            case "character":
                character_id = id;
                Debug.Log("character_id = " + character_id);
                break;
            case "stage":
                stage_id = id;
                Debug.Log("stage_id = " + stage_id);
                break;
            case "gameMode":
                gameMode_id = id;
                Debug.Log("gameMode_id = " + gameMode_id);
                break;
            default:
                Debug.Log("ID is not change!!");
                break;
        }

    }

    //TODO Settingの変更methodの検討
    //Setting内容変更
    //public void ChangeSetting (string targetSetting, int value)
    //{
    //    switch (targetSetting)
    //    {
    //        case "volume":
    //            settings.volume = value;
    //            break;
    //    }
    //}

}
