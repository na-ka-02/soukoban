using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    
    //02�̉ۑ�
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
        //�ړ��悪�͈͊O�Ȃ�ړ��s��
        if (moveTo < 0 || moveTo >= map.Length)
        {
            //�����Ȃ��������ɏ����A���^�[������B�������^�[��
            return false;
        }
        //�ړ����2(��)��������
        if (map[moveTo] == 2)
        {
            //�ǂ̕����ֈړ����邩���Z�o
            int velocity = moveTo - moveFrom;
            //�v���C���[�̈ړ��悩��A����ɐ��2(��)���ړ�������B
            //���̈ړ������BMoveNumber���\�b�h����MoveNumber���\�b�h��
            //�ĂсA�闢���ċN���Ă���B�ړ��s��bool�ŋL�^
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //���������ړ����s������A�v���C���[�̈ړ������s
            if (!success)
            {
                return false;
            }
        }
        //�v���C���[�E���ւ�炸�̈ړ�����
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
    

    //�z��̐錾
    //01��02�̉ۑ�
    int[] map;

    //03�̉ۑ�
    //int[,] map;

    // Start is called before the first frame update
    void Start()
    {
        //�z��̎��Ԃ̍쐬�Ə�����

        //01��02�̉ۑ�
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
        PrintArray();


        //03�̉ۑ�
        //�������̗�
        /*
        map = new int[,]
        {
            { 0,0,0,0,0 },
            { 0,0,1,0,0 },
            { 0,0,0,0,0 },
        };

        string debugText = "";
        //�ύX�B��dfor���œ񎟌��z��̏����o��
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }
            debugText+= "\n";// ���s
        }
        Debug.Log(debugText); 
         */

        /* 01�̉ۑ�
        //������Ɛ錾�̏�����
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        //����������������o��
        Debug.Log(debugText);
        */

    }

    // Update is called once per frame
    void Update()
    {
        //02�̉ۑ�
        //�E
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //���\�b�h�������������g�p
            int playerIndex = GetPlayerIndex();
            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }
            //�ړ��������֐���
            MoveNumber(1, playerIndex, playerIndex + 1);

            PrintArray();
        }
        //��
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //���\�b�h�������������g�p
            int playerIndex = GetPlayerIndex();
            if (playerIndex > 0)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;
            }
            //�ړ��������֐���
            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();
        }


        /*01�̉ۑ�
        //���͏���
        //�E
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex = -1;
            //�v�f����map.Length�Ŏ擾
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
        //��
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = -1;
            //�v�f����map.Length�Ŏ擾
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
