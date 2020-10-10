using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    //TODO ①デフォルト値をどうするか検討 <--初めてのLogin時
    //TODO ②再起動した時にどこで各ID情報を保持するのか <--2回目以降のLogin時

    //CharacterSelect画面で選択されたキャラクターのID
    public static int character_id;
    //StageSelect画面で選択されたステージのID
    public static int stage_id;
    //GameSelect画面で選択されたゲームのID
    public static int gameMode_id;
    //Setting画面で選択した各種設定のIDの配列

    public CharacterStatusData characterStatusData;
    public Image characterImage;
    public static Dictionary<string, int> settings;

    private void Awake()
    {
        if (instance == null)
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

    // CharacterIdの変更
    public void ChangeCharacterId(int id)
    {
        character_id = id;
    }
    // StageIDの変更
    public void ChangeStageId(int id)
    {
        stage_id = id;
    }
    // GameIdの変更
    public void ChangeGameId(int id)
    {
        gameMode_id = id;
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
