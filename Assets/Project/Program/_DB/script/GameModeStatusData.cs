using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キャラクター用のDatabase
[CreateAssetMenu(
    fileName = "GameModeStatusData",
    menuName = "ScriptableObject/GameModeStatusData",
    order = 0)
]
[System.Serializable]
public class GameModeStatusData : ScriptableObject
{
    public List<GameModeStatus> gameModeStatusList = new List<GameModeStatus>();
}



//System.Serializableを設定しないと、データを保持できない(シリアライズできない)ので注意
[System.Serializable]
public class GameModeStatus
{

    //設定したいデータの変数
    public string Game_Mode_Name = "ゲームモードの名前", Description = "ゲームモードの詳細";
    //public bool IsBoss = false;
    public Sprite image;

}
