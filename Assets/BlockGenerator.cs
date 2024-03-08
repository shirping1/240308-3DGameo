using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockGenerator : MonoBehaviour
{
    [Header("블록 개수 설정")]
    public int X_BlockCount;
    public int Y_BlockCount;
    [Header("블록 생성 간격")]
    public int gapX;
    public int gapY;
    [Header("생성할 블록에 대한 정보")]
    public GameObject[] BlockPrefab;

    [Header("블록 리스트")]
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
            blocks[i] = Instantiate(BlockPrefab[idx]); // 0번은 x블록
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
