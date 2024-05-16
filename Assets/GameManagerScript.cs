//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Compilation;
//using UnityEngine;

//public class GameManagerScript : MonoBehaviour
//{

//    //02の課題
//    //void PrintArray()
//    //{
//    //    string debugText = "";
//    //    for (int i = 0; i < map.Length; i++)
//    //    {
//    //        debugText += map[i].ToString() + ",";
//    //    }
//    //    Debug.Log(debugText);
//    //}

//    //02の課題
//    //int GetPlayerIndex()
//    //{
//    //    for (int i = 0; i < map.Length; i++)
//    //    {
//    //        if (map[i] == 1)
//    //        {
//    //            return i;
//    //        }
//    //    }
//    //    return -1;
//    //}

//    //02の課題
//    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
//    {
//        //2次元対応
//        //移動先が範囲外なら移動不可
//        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0))
//        {
//            //動けない条件を先に書き、リターンする。早期リターン
//            return false;
//        }
//        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1))
//        {
//            //動けない条件を先に書き、リターンする。早期リターン
//            return false;
//        }

//        ////移動先に2(箱)がいたら
//        //if (map[moveTo] == 2)
//        //{
//        //    //どの方向へ移動するかを算出
//        //    int velocity = moveTo - moveFrom;
//        //    //プレイヤーの移動先から、さらに先へ2(箱)を移動させる。
//        //    //箱の移動処理。MoveNumberメソッド内でMoveNumberメソッドを
//        //    //呼び、朱里が再起している。移動可不可をboolで記録
//        //    bool success = MoveNumber(2, moveTo, moveTo + velocity);
//        //    //もし箱が移動失敗したら、プレイヤーの移動も失敗
//        //    if (!success)
//        //    {
//        //        return false;
//        //    }
//        //}
//        ////プレイヤー・箱関わらずの移動処理
//        //map[moveTo] = number;
//        //map[moveFrom] = 0;
//        //return true;
//        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);

//        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
//        field[moveFrom.y, moveFrom.x] = null;
//        return true;
//    }


//    //配列の宣言
//    //01と02の課題
//    //int[] map;

//    //03の課題
//    int[,] map;
//    public GameObject playerPrefab;
//    GameObject[,] field;
//    GameObject instance;
//    Vector2Int GetPlayerIndex()
//    {
//        for (int y = 0; y < field.GetLength(0); y++)
//        {
//            for (int x = 0; x < field.GetLength(1); x++)
//            {
//                if (map[y, x] == 1)
//                {
//                    GameObject obj = field[y, x];
//                }
//                if (obj!=null&&field[y, x].tag == "Player")
//                {
//                    return new Vector2Int(x, y);
//                }
//            }
//        }
//        return new Vector2Int(-1, -1);
//    }

//    void PrintArray()
//    {
//        string debugText = "";
//        for (int y = 0; y < map.GetLength(0); y++)
//        {
//            for (int x = 0; x < map.GetLength(1); x++)
//            {
//                debugText += map[y, x].ToString() + ",";
//            }
//            debugText += "\n";
//        }
//        Debug.Log(debugText);
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        //配列の実態の作成と初期化

//        //01と02の課題
//        //map = new int[] { 0, 0, 2, 1, 0, 2, 0, 0, 0 };
//        //PrintArray();


//        /*03の課題
//        //GameObject instance = Instantiate
//        //    (playerPrefab,
//        //    new Vector3(0, 0, 0),
//        //    Quaternion.identity
//        //    );
//        */


//        //初期化の例
//        map = new int[,]
//        {
//            { 1, 0, 0, 0, 0, 2, 0, 2, 0 },
//            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
//            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
//            { 0, 0, 0, 0, 1, 2, 0, 2, 0 },
//            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
//            { 0, 0, 0, 0, 0, 2, 0, 2, 0 }
//        };

//        PrintArray();

//        field = new GameObject
//                [
//                map.GetLength(0),
//                map.GetLength(1)
//                ];

//        for (int y = 0; y < map.GetLength(0); y++)
//        {
//            for (int x = 0; x < map.GetLength(1); x++)
//            {
//                //if (map[y, x] == 1)
//                //{
//                //GameObject instance = Instantiate
//                //    (
//                //    playerPrefab,
//                //    new Vector3(x,map.GetLength(0)-y,0),
//                //    Quaternion.identity
//                //    );
//                //}
//                if (map[y, x] == 1)
//                {
//                    instance =
//                       Instantiate(playerPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
//                    field[y, x] = instance;
//                    break;
//                }
//            }
//        }

//        //string debugText = "";
//        ////変更。二重for文で二次元配列の情報を出力
//        //for (int y = 0; y < map.GetLength(0); y++)
//        //{
//        //    for (int x = 0; x < map.GetLength(1); x++)
//        //    {
//        //        debugText += map[y, x].ToString() + ",";
//        //    }
//        //    debugText += "\n";// 改行
//        //}
//        //Debug.Log(debugText);


//        /* 01の課題
//        //文字列と宣言の初期化
//        string debugText = "";
//        for (int i = 0; i < map.Length; i++)
//        {
//            debugText += map[i].ToString() + ",";
//        }
//        //結合した文字列を出力
//        Debug.Log(debugText);
//        */

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //02の課題
//        //右
//        if (Input.GetKeyDown(KeyCode.RightArrow))
//        {
//            //メソッド化した処理を使用
//            Vector2Int playerIndex = GetPlayerIndex();
//            //移動処理を関数か
//            MoveNumber(playerIndex, playerIndex + new Vector2Int(1, 0));

//            PrintArray();
//        }
//        //左
//        if (Input.GetKeyDown(KeyCode.LeftArrow))
//        {
//            //メソッド化した処理を使用
//            Vector2Int playerIndex = GetPlayerIndex();

//            //移動処理を関数化
//            MoveNumber(playerIndex, playerIndex - new Vector2Int(1, 0));
//            PrintArray();
//        }


//        /*01の課題
//        //入力処理
//        //右
//        if (Input.GetKeyDown(KeyCode.RightArrow))
//        {
//            int playerIndex = -1;
//            //要素数はmap.Lengthで取得
//            for (int i = 0; i < map.Length; i++)
//            {
//                if (map[i] == 1)
//                {
//                    playerIndex = i;
//                    break;
//                }
//            }

//            if (playerIndex < map.Length - 1)
//            {
//                map[playerIndex + 1] = 1;
//                map[playerIndex] = 0;
//            }

//            string debugText = "";
//            for (int i = 0; i < map.Length; i++)
//            {
//                debugText += map[i].ToString() + ",";
//            }
//            Debug.Log(debugText);
//        }
//        //左
//        if (Input.GetKeyDown(KeyCode.LeftArrow))
//        {
//            int playerIndex = -1;
//            //要素数はmap.Lengthで取得
//            for (int i = 0; i < map.Length; i++)
//            {
//                if (map[i] == 1)
//                {
//                    playerIndex = i;
//                    break;
//                }
//            }

//            if (playerIndex > 0)
//            {
//                map[playerIndex - 1] = 1;

//                map[playerIndex] = 0;
//            }

//            string debugText = "";
//            for (int i = 0; i < map.Length; i++)
//            {
//                debugText += map[i].ToString() + ",";
//            }
//            Debug.Log(debugText);
//        }
//        */

//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    int[,] map;
    GameObject[,] field;
    GameObject instance;
    /// <summary>
    /// 与えられた数字をマップ上で移動させる
    /// </summary>
    /// <param name="number">移動させる数字</param>
    /// <param name="moveFrom">元の位置</param>
    /// <param name="moveTo">移動先の位置</param>
    /// <returns>移動可能な時 true</returns>
    bool MoveNumber(Vector2Int movefrom, Vector2Int moveto)
    {
        if (moveto.y < 0 || moveto.y >= field.GetLength(0))
            return false;
        if (moveto.x < 0 || moveto.x >= field.GetLength(1))
            return false;

        if (field[moveto.y, moveto.x]?.tag == "Box")
        {
            var offset = moveto - movefrom;  // 箱の行先を決めるための差分
            bool result = MoveNumber(moveto, moveto + offset);

            if (!result)
                return false;
        }   // 行先に箱がある時

        //if (map[moveto] == 2)
        //{
        //    int offset = moveto - movefrom; // 箱の行先を決めるための差分
        //    bool success = movenumber(2, moveto, moveto + offset);
        //    if (!success)
        //    {
        //        return false;
        //    }
        //}   // 行先に箱がある時
        field[movefrom.y, movefrom.x].transform.position =
            new Vector3(moveto.x, -1 * moveto.y, 0);    // シーン上のオブジェクトを動かす
        // field のデータを動かす
        field[moveto.y, moveto.x] = field[movefrom.y, movefrom.x];
        field[movefrom.y, movefrom.x] = null;
        return true;
    }
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                GameObject obj = field[y, x];
                if (obj != null && obj.tag == "Player")
                {
                    return new Vector2Int(x, y);
                }   // プレイヤーを見つけた
            }
        }
        return new Vector2Int(-1, -1);  // 見つからなかった
    }
    void PrintArray()
    {
        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
    }
    void Start()
    {
        map = new int[,]
        {
            { 1, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 }
        };
        PrintArray();
        field = new GameObject[
            map.GetLength(0),
            map.GetLength(1)
        ];
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    instance =
                        Instantiate(playerPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;
                    break;
                }   // プレイヤーを見つけた
                else if (map[y, x] == 2)
                {
                    instance =
                        Instantiate(boxPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;
                }   // 箱を見つけた
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion + Vector2Int.right);
            PrintArray();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion + Vector2Int.left);
            PrintArray();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion - Vector2Int.up);
            PrintArray();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion - Vector2Int.down);
            PrintArray();
        }
    }
}
