using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Text pointText;
    Text deathCountText;
    GameObject goalIn;
    GameObject goalText;
    int point = 0;
    static int deathCount = 0;
    public int speed;
    public int maxScore;
    static int maxStage = 5;
    GameObject[] stage1Point;
    GameObject[] stage2Point;
    static int nowStage = 1;
    int maxPoint = 5;
    Transform nowStartPosition;
    Text stageText;

    // Start is called before the first frame update
    void Start()
    {
        pointText = GameObject.Find("Point Text").GetComponent<Text>();
        deathCountText = GameObject.Find("DeathCount Text").GetComponent<Text>();
        goalIn = GameObject.Find("Goal In Text");
        stageText = GameObject.Find("Stage Text").GetComponent<Text>();

        stage1Point = GameObject.FindGameObjectsWithTag("Point1");
        stage2Point = GameObject.FindGameObjectsWithTag("Point2");

        nowStartPosition = GameObject.Find("StartPoint" + nowStage).transform;
        SetstageText();
        UpdatePointText();
        goalText = GameObject.Find("Goal Text");
        goalText.SetActive(false);
        goalIn.SetActive(false);
    }

    private void SetstageText()
    {
        stageText.text = "Stage " + nowStage.ToString() + "/" + maxStage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PLayerMove();
    }

    void PLayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(0, 0, speed) * Time.deltaTime;
        }

        // transform.Translate 이용
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        // transform.Translate 이용
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dead"))
        {
            Dead();
        }
        else if (other.CompareTag("Point1"))
        {
            point++;
            UpdatePointText();
            other.gameObject.SetActive(false);
            if(point == maxPoint)
            {
                goalText.SetActive(true);
            }
        }
        else if (other.CompareTag("Point2"))
        {
            point++;
            UpdatePointText();
            other.gameObject.SetActive(false);
            if (point == maxPoint)
            {
                goalText.SetActive(true);
            }
        }
        else if (other.CompareTag("Goal"))
        {

            if (point == maxPoint && nowStage == maxStage)
            {
                goalIn.GetComponent<Text>().text = "Cear!!!!\nSCORE : " + (maxScore - deathCount * 10);
                goalIn.SetActive(true);
            }
            else if (point == maxPoint)
            {
                nowStage++;
                nowStartPosition = GameObject.Find("StartPoint" + nowStage).transform;
                transform.position = nowStartPosition.position + new Vector3(0, 1, 0);
                point = 0;
                UpdatePointText();
                goalText.SetActive(false);
                SetstageText();

            }
        }
    }

    void Dead()
    {
        transform.position = nowStartPosition.position + new Vector3 (0, 1, 0);
        
        for (int i = 0; i < maxPoint; i++)
        {
            stage1Point[i].SetActive(true);
        }

        for (int i = 0; i < maxPoint; i++)
        {
            stage2Point[i].SetActive(true);
        }

        point = 0;
        UpdatePointText();
        deathCount++;
        deathCountText.text = "DeathCount: " + deathCount.ToString();
        goalText.SetActive(false);

    }

    void UpdatePointText()
    {
        pointText.text = "Point: " + point.ToString() + "/" + maxPoint.ToString();

    }
}
