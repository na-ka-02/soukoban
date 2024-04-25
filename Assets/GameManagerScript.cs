using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //配列の宣言
    int[] map;
    // Start is called before the first frame update
    void Start()
    {
        //配列の実態の作成と初期化
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0 };
        //文字列と宣言の初期化
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        //結合した文字列を出力
        Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
        //入力処理
        //右
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex = -1;
            //要素数はmap.Lengthで取得
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }

            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }

            string debugText = "";
            for (int i = 0; i < map.Length; i++)
            {
                debugText += map[i].ToString() + ",";
            }
            Debug.Log(debugText);
        }
        //左
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = -1;
            //要素数はmap.Lengthで取得
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }

            if (playerIndex > 0)
            {
                map[playerIndex - 1] = 1;

                map[playerIndex] = 0;
            }

            string debugText = "";
            for (int i = 0; i < map.Length; i++)
            {
                debugText += map[i].ToString() + ",";
            }
            Debug.Log(debugText);
        }
    }
}
