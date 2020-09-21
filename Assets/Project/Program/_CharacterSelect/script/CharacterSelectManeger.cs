using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectManeger : MonoBehaviour
{
    CharacterStatusData characterStatusData = Resources.Load<CharacterStatusData>("/Project/Program/_DB/script/CharacterStatusData");
   
    //CharacterStatusを画面に表示する際に使用
    //TODO:各キャラボタン押下時に実行
    public void ReadCharacterStatus(int id)
    {
        Debug.Log("characterStatusData = " + characterStatusData);
        CharacterStatus characterStatus = characterStatusData.CharacterStatusList[id];
        Debug.Log("characterStatus = " + characterStatus);
        //return characterStatus;
    }
}
