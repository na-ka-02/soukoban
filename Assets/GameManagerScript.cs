using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    int GetPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        //移動先が範囲外なら移動不可
        if (moveTo < 0 || moveTo >= map.Length)
        {
            //動けない条件を先に書き、リターンする。早期リターン
            return false;
        }
        //移動先に2(箱)がいたら
        if (map[moveTo] == 2)
        {
            //どの方向へ移動するかを算出
            int velocity = moveTo - moveFrom;
            //プレイヤーの移動先から、さらに先へ2(箱)を移動させる。
            //箱の移動処理。MoveNumberメソッド内でMoveNumberメソッドを
            //呼び、朱里が再起している。移動可不可をboolで記録
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //もし箱が移動失敗したら、プレイヤーの移動も失敗
            if (!success)
            {
                return false;
            }
        }
        //プレイヤー・箱関わらずの移動処理
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
    //配列の宣言
    int[] map;
    // Start is called before the first frame update
    void Start()
    {
        //配列の実態の作成と初期化
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
        PrintArray();

        /* 01の課題
        //文字列と宣言の初期化
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        //結合した文字列を出力
        Debug.Log(debugText);
        */

    }

    // Update is called once per frame
    void Update()
    {
        //右
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //メソッド化した処理を使用
            int playerIndex = GetPlayerIndex();
            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }
            //移動処理を関数か
            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();
        }
        //左
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //メソッド化した処理を使用
            int playerIndex = GetPlayerIndex();
            if (playerIndex > 0)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;
            }
            //移動処理を関数か
            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();
        }

        /*01の課題
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
        */

    }
}
