using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キャラクター用のDatabase
[CreateAssetMenu(
    fileName = "StageStatusData",
    menuName = "ScriptableObject/StageStatusData",
    order = 0)
]
[System.Serializable]
public class StageStatusData : ScriptableObject
{
    public List<StageStatus> stageStatusList = new List<StageStatus>();
}



//System.Serializableを設定しないと、データを保持できない(シリアライズできない)ので注意
[System.Serializable]
public class StageStatus
{

    //設定したいデータの変数
    public string Stage_Name = "場所の名前", Description = "場所の詳細";
    public int Friction = 1, Gravity = 1;
    //public bool IsBoss = false;
    public Sprite image;

}
