using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectManager : MonoBehaviour
{


    /* 画面の値へのレファレンス */
    public CharacterStatusData characterStatusData;
    public int currentCharacterID;
    public TextMeshProUGUI Name_Text;
    public TextMeshProUGUI HP_Text;
    public TextMeshProUGUI SP_Text;
    public TextMeshProUGUI ATK_Text;
    public TextMeshProUGUI DEF_Text;
    public TextMeshProUGUI SPD_Text;
    public Image image;


    void Start()
    {

    }

    // 各値を画面の値に反映する
    public void UpdateCharacterData(int indexNum)
    {
        // TODO IDの変更方法は変わる可能性あり
        currentCharacterID = (indexNum + 1);

        Name_Text.text = characterStatusData.characterStatusList[indexNum].Name;
        HP_Text.text = "HP: " + characterStatusData.characterStatusList[indexNum].HP;
        SP_Text.text = "SP: " + characterStatusData.characterStatusList[indexNum].SP;
        ATK_Text.text = "ATK: " + characterStatusData.characterStatusList[indexNum].Atk;
        DEF_Text.text = "DEF: " + characterStatusData.characterStatusList[indexNum].Def;
        SPD_Text.text = "SPD: " + characterStatusData.characterStatusList[indexNum].Spd;
        image.sprite = characterStatusData.characterStatusList[indexNum].image;
    }

    public void UpdateCharacterID()
    {
        GameManager.character_id = currentCharacterID;
    }

}
