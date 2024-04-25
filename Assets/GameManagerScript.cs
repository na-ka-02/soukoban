using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //�z��̐錾
    int[] map;
    // Start is called before the first frame update
    void Start()
    {
        //�z��̎��Ԃ̍쐬�Ə�����
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0 };
        //������Ɛ錾�̏�����
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        //����������������o��
        Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
