//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Compilation;
//using UnityEngine;

//public class GameManagerScript : MonoBehaviour
//{

//    //02�̉ۑ�
//    //void PrintArray()
//    //{
//    //    string debugText = "";
//    //    for (int i = 0; i < map.Length; i++)
//    //    {
//    //        debugText += map[i].ToString() + ",";
//    //    }
//    //    Debug.Log(debugText);
//    //}

//    //02�̉ۑ�
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

//    //02�̉ۑ�
//    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
//    {
//        //2�����Ή�
//        //�ړ��悪�͈͊O�Ȃ�ړ��s��
//        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0))
//        {
//            //�����Ȃ��������ɏ����A���^�[������B�������^�[��
//            return false;
//        }
//        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1))
//        {
//            //�����Ȃ��������ɏ����A���^�[������B�������^�[��
//            return false;
//        }

//        ////�ړ����2(��)��������
//        //if (map[moveTo] == 2)
//        //{
//        //    //�ǂ̕����ֈړ����邩���Z�o
//        //    int velocity = moveTo - moveFrom;
//        //    //�v���C���[�̈ړ��悩��A����ɐ��2(��)���ړ�������B
//        //    //���̈ړ������BMoveNumber���\�b�h����MoveNumber���\�b�h��
//        //    //�ĂсA�闢���ċN���Ă���B�ړ��s��bool�ŋL�^
//        //    bool success = MoveNumber(2, moveTo, moveTo + velocity);
//        //    //���������ړ����s������A�v���C���[�̈ړ������s
//        //    if (!success)
//        //    {
//        //        return false;
//        //    }
//        //}
//        ////�v���C���[�E���ւ�炸�̈ړ�����
//        //map[moveTo] = number;
//        //map[moveFrom] = 0;
//        //return true;
//        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);

//        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
//        field[moveFrom.y, moveFrom.x] = null;
//        return true;
//    }


//    //�z��̐錾
//    //01��02�̉ۑ�
//    //int[] map;

//    //03�̉ۑ�
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
//        //�z��̎��Ԃ̍쐬�Ə�����

//        //01��02�̉ۑ�
//        //map = new int[] { 0, 0, 2, 1, 0, 2, 0, 0, 0 };
//        //PrintArray();


//        /*03�̉ۑ�
//        //GameObject instance = Instantiate
//        //    (playerPrefab,
//        //    new Vector3(0, 0, 0),
//        //    Quaternion.identity
//        //    );
//        */


//        //�������̗�
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
//        ////�ύX�B��dfor���œ񎟌��z��̏����o��
//        //for (int y = 0; y < map.GetLength(0); y++)
//        //{
//        //    for (int x = 0; x < map.GetLength(1); x++)
//        //    {
//        //        debugText += map[y, x].ToString() + ",";
//        //    }
//        //    debugText += "\n";// ���s
//        //}
//        //Debug.Log(debugText);


//        /* 01�̉ۑ�
//        //������Ɛ錾�̏�����
//        string debugText = "";
//        for (int i = 0; i < map.Length; i++)
//        {
//            debugText += map[i].ToString() + ",";
//        }
//        //����������������o��
//        Debug.Log(debugText);
//        */

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //02�̉ۑ�
//        //�E
//        if (Input.GetKeyDown(KeyCode.RightArrow))
//        {
//            //���\�b�h�������������g�p
//            Vector2Int playerIndex = GetPlayerIndex();
//            //�ړ��������֐���
//            MoveNumber(playerIndex, playerIndex + new Vector2Int(1, 0));

//            PrintArray();
//        }
//        //��
//        if (Input.GetKeyDown(KeyCode.LeftArrow))
//        {
//            //���\�b�h�������������g�p
//            Vector2Int playerIndex = GetPlayerIndex();

//            //�ړ��������֐���
//            MoveNumber(playerIndex, playerIndex - new Vector2Int(1, 0));
//            PrintArray();
//        }


//        /*01�̉ۑ�
//        //���͏���
//        //�E
//        if (Input.GetKeyDown(KeyCode.RightArrow))
//        {
//            int playerIndex = -1;
//            //�v�f����map.Length�Ŏ擾
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
//        //��
//        if (Input.GetKeyDown(KeyCode.LeftArrow))
//        {
//            int playerIndex = -1;
//            //�v�f����map.Length�Ŏ擾
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
    /// �^����ꂽ�������}�b�v��ňړ�������
    /// </summary>
    /// <param name="number">�ړ������鐔��</param>
    /// <param name="moveFrom">���̈ʒu</param>
    /// <param name="moveTo">�ړ���̈ʒu</param>
    /// <returns>�ړ��\�Ȏ� true</returns>
    bool MoveNumber(Vector2Int movefrom, Vector2Int moveto)
    {
        if (moveto.y < 0 || moveto.y >= field.GetLength(0))
            return false;
        if (moveto.x < 0 || moveto.x >= field.GetLength(1))
            return false;

        if (field[moveto.y, moveto.x]?.tag == "Box")
        {
            var offset = moveto - movefrom;  // ���̍s������߂邽�߂̍���
            bool result = MoveNumber(moveto, moveto + offset);

            if (!result)
                return false;
        }   // �s��ɔ������鎞

        //if (map[moveto] == 2)
        //{
        //    int offset = moveto - movefrom; // ���̍s������߂邽�߂̍���
        //    bool success = movenumber(2, moveto, moveto + offset);
        //    if (!success)
        //    {
        //        return false;
        //    }
        //}   // �s��ɔ������鎞
        field[movefrom.y, movefrom.x].transform.position =
            new Vector3(moveto.x, -1 * moveto.y, 0);    // �V�[����̃I�u�W�F�N�g�𓮂���
        // field �̃f�[�^�𓮂���
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
                }   // �v���C���[��������
            }
        }
        return new Vector2Int(-1, -1);  // ������Ȃ�����
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
                }   // �v���C���[��������
                else if (map[y, x] == 2)
                {
                    instance =
                        Instantiate(boxPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;
                }   // ����������
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
