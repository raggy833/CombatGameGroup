using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // 接地判定用タグの定義
    private string groundTag = "Ground";
    // 接地判定用変数
    private bool isGround = false;
    // 接地状態の変数
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定を返すメソッド
    public bool IsGround()
    {
        // 接触しているかぎり接地判定をtrueとする
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        //それぞれの変数初期化して、接地判定用変数を返す
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    // 接触しようとしている物体がgroundTagの場合はtrueを代入
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
    }

    // 接触し続けている物体がgroundTagの場合はtrueを代入
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
    }

    // 離れようとしている物体がgroundTagの場合はtrueを代入
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
    }
}
