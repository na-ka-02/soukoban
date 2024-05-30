using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public CinemachineVirtualCameraBase virtualCamera;//カメラポジションをプレイヤー中心にする
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    /// <summary>荷物を格納する場所のプレハブ</summary>
    public GameObject storePrefab;
    /// <summary>クリアーしたことを示すテキストの GameObject</summary>
    public GameObject clearText;
    public GameObject wallPrefab;
    int[,] map; // マップの元データ（数字）
    GameObject[,] field;    // map を元にしたオブジェクトの格納庫

    bool IsClear()
    {
        // 格納場所一覧のデータを作る
        List<Vector2Int> goals = new List<Vector2Int>();

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 3)
                {
                    goals.Add(new Vector2Int(x, y));
                }   // 格納場所である場合
            }
        }
        // 格納場所に箱があるか調べる
        for (int i = 0; i < goals.Count; i++)
        {
            GameObject f = field[goals[i].y, goals[i].x];   // ゴールの座標に何があるかとってくる

            if (f == null || f.tag != "Box")
            {
                return false;
            }   // 格納場所に箱がない、というケースが一つでもあればクリアしてないと判定する
        }
        return true;    // すべての格納場所に箱がある場合
    }
    /// <summary>
    /// number を動かす
    /// </summary>
    /// <param name="number">動かす数字</param>
    /// <param name="moveFrom">移動元インデックス</param>
    /// <param name="moveTo">移動先インデックス</param>
    /// <returns></returns>
    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        // 動けない場合は false を返す
        if (moveTo.y < 1 || moveTo.y >= field.GetLength(0) - 1)
            return false;
        if (moveTo.x < 1 || moveTo.x >= field.GetLength(1) - 1)
            return false;
        if (field[moveTo.y, moveTo.x] != null
            && field[moveTo.y, moveTo.x].tag == "Box")
        {
            Vector2Int velocity = moveTo - moveFrom;    // 移動方向を計算する
            bool success = MoveNumber(moveTo, moveTo + velocity);
            if (!success)
                return false;
        }   // 移動先に箱がいた場合の処理
        // プレイヤー・箱の共通処理
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        // オブジェクトのシーン上の座標を動かす
        field[moveTo.y, moveTo.x].transform.position =
            new Vector3(moveTo.x, -1 * moveTo.y, 0);
        //field[moveTo.y, moveTo.x].transform.position =
        //    new Vector3(moveTo.x, -1 * moveTo.y, 0);
        // プレイヤーor箱のオブジェクトから、Moveコンポーネントをとってくる
        Move move = field[moveTo.y, moveTo.x].GetComponent<Move>();
        // Moveコンポーネントに対して、動けと命令する
        move.MoveTo(new Vector3(moveTo.x, -1 * moveTo.y, 0));

        return true;
    }
    /// <summary>
    /// プレイヤーの座標を調べて取得する
    /// ※）GetPlayerPosition 
    /// </summary>
    /// <returns>プレイヤーの座標</returns>
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] != null
                    && field[y, x].tag == "Player")
                {
                    // プレイヤーを見つけた
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);  // 見つからなかった
    }

    void Start()
    {
        //解像度とウィンドウモード
        Screen.SetResolution(1280,720,false);
        //クリアしたときのテクスチャの表示
        clearText.SetActive(false);

        map = new int[,]
        {
            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
            { 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4 },
            { 4, 0, 0, 0, 0, 3, 2, 0, 0, 0, 0, 0, 0, 4 },
            { 4, 0, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 4 },
            { 4, 0, 0, 0, 0, 3, 2, 0, 0, 0, 0, 0, 0, 4 },
            { 4, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 4 },
            { 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4 },
            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
        };  // 0: 何もない, 1: プレイヤー, 2: 箱,3:箱を格納する場所,4:壁

        field = new GameObject
        [
            map.GetLength(0),
            map.GetLength(1)
        ];  // map の行列と同じ升目の配列をもうひとつ作った
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    GameObject instance =
                        Instantiate(playerPrefab,
                        new Vector3(x, -1 * y, 0),
                        Quaternion.identity);
                    field[y, x] = instance; // プレイヤーを保存しておく
                    virtualCamera.Follow = instance.transform;//カメラをプレイヤー追従にする
                    //break;  // プレイヤーは１つだけなので抜ける
                    // break;  // プレイヤーは１つだけなので抜ける
                }   // プレイヤーを出す
                else if (map[y, x] == 2)
                {
                    GameObject instance =
                        Instantiate(boxPrefab,
                        new Vector3(x, -1 * y, 0),
                        Quaternion.identity); // 箱を保存しておく
                    field[y, x] = instance;
                }   // 箱を出す
                else if (map[y, x] == 3)
                {
                    GameObject instance =
                        Instantiate(storePrefab,
                        new Vector3(x, -1 * y, 0),
                        Quaternion.identity);
                    field[y, x] = instance;
                }   // 格納場所を出す
                else if (map[y, x] == 4)
                {
                    GameObject instance =
                        Instantiate(wallPrefab,
                        new Vector3(x, -1 * y, 0),
                        Quaternion.identity);
                    field[y, x] = instance;
                }
            }
        }
    }
    void Update()
    {

        if (IsClear())
            clearText.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var playerPosition = GetPlayerIndex();
            MoveNumber(playerPosition, new Vector2Int(playerPosition.x + 1, playerPosition.y));    // →に移動

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var playerPosition = GetPlayerIndex();
            MoveNumber(playerPosition, new Vector2Int(playerPosition.x - 1, playerPosition.y));    // ←に移動

            //if (IsClear())
            //    Debug.Log("Clear");
            //clearText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var playerPosition = GetPlayerIndex();
            MoveNumber(playerPosition, new Vector2Int(playerPosition.x, playerPosition.y - 1));    // ↑に移動

            //if (IsClear())
            //    Debug.Log("Clear");
            //clearText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var playerPosition = GetPlayerIndex();
            MoveNumber(playerPosition, new Vector2Int(playerPosition.x, playerPosition.y + 1));    // ↓に移動

        }
    }
}