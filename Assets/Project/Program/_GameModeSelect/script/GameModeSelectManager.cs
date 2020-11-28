using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameModeSelectManager : MonoBehaviour
{


    /* 画面の値へのレファレンス */
    public GameModeStatusData gameModeStatusData;
    public int currentGameModeID;
    public TextMeshProUGUI Game_Mode_Name_Text;
    public TextMeshProUGUI Description_Text;
    public Image image;


    void Start()
    {

    }

    // 各値を画面の値に反映する
    public void UpdateGameModeData(int indexNum)
    {
        // TODO IDの変更方法は変わる可能性あり
        currentGameModeID = (indexNum + 1);

        Game_Mode_Name_Text.text = gameModeStatusData.gameModeStatusList[indexNum].Game_Mode_Name;
        Description_Text.text = gameModeStatusData.gameModeStatusList[indexNum].Description;
        image.sprite = gameModeStatusData.gameModeStatusList[indexNum].image;
    }

    //GMでID変更するかを検討
    public void UpdateGameModeID()
    {
        GameManager.gameMode_id = currentGameModeID;
    }

}
