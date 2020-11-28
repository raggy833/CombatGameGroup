using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageSelectManager : MonoBehaviour
{


    /* 画面の値へのレファレンス */
    public StageStatusData stageStatusData;
    public int currentStageID;
    public TextMeshProUGUI Stage_Name_Text;
    public TextMeshProUGUI Description_Text;
    public Image image;


    void Start()
    {

    }

    // 各値を画面の値に反映する
    public void UpdateStageData(int indexNum)
    {
        // TODO IDの変更方法は変わる可能性あり
        currentStageID = (indexNum + 1);

        Stage_Name_Text.text = stageStatusData.stageStatusList[indexNum].Stage_Name;
        Description_Text.text = stageStatusData.stageStatusList[indexNum].Description;
        image.sprite = stageStatusData.stageStatusList[indexNum].image;
    }

    //GMでID変更するかを検討
    public void UpdateStageID()
    {
        GameManager.stage_id = currentStageID;
    }

}
