using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockGenerator : MonoBehaviour
{
    [Header("��� ���� ����")]
    public int X_BlockCount;
    public int Y_BlockCount;
    [Header("��� ���� ����")]
    public int gapX;
    public int gapY;
    [Header("������ ��Ͽ� ���� ����")]
    public GameObject[] BlockPrefab;

    [Header("��� ����Ʈ")]
    public GameObject[] X_Blocks;
    public GameObject[] Y_Blocks;

    // Start is called before the first frame update
    void Start()
    {
        SetBlock(X_Blocks, gapX, 0);
        SetBlock(Y_Blocks, gapY, 1);
    }

    private void SetBlock(GameObject[] blocks, int gapX, int idx)
    {
        for(int i = 0; i < blocks.Length; i++)
        {
            blocks[i] = Instantiate(BlockPrefab[idx]); // 0���� x���
            blocks[i].transform.position = new Vector3(10, 1, X_BlockCount - gapX * i);
            //blocks[i].GetComponent<BlockMovement>().position
            //if (blocks[i].GetComponent<BlockMovement>().Position == Position.X_Block )
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
