using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キャラクター用のDatabase
[CreateAssetMenu(
    fileName = "CharacterStatusData",
    menuName = "ScriptableObject/CharacterStatusData",
    order = 0)
]
[System.Serializable]
public class CharacterStatusData : ScriptableObject
{

    public List<CharacterStatus> characterStatusList = new List<CharacterStatus>();
}



//System.Serializableを設定しないと、データを保持できない(シリアライズできない)ので注意
[System.Serializable]
public class CharacterStatus
{

    //設定したいデータの変数
    public string Name = "なまえ";
    public int HP = 100, SP = 50, Atk = 5, Def = 15, Spd = 99;
    //public bool IsBoss = false;
    public Sprite image;

}