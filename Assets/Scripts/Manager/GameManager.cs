using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject startPanel;
    public GameObject endPanel;

    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject heart_3;


    public int lifeCount = 3;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startPanel != null)
        {
            startPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
        }

        if (endPanel != null)
        {
            endPanel.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GameOver()
    {
        Time.timeScale = 0f;

        if (endPanel != null)
        {
            ScoreManager.instance.StopScoreCount();
            ScoreManager.instance.ShowFinalScore();
            endPanel.SetActive(true);
        }
    }

    public void ReduceLife()
    {
        lifeCount--;

        if (lifeCount == 2)
        {
            heart_3.SetActive(false);
        }
        else if (lifeCount == 1)
        {
            heart_2.SetActive(false);
        }
        else
        {
            heart_1.SetActive(false);
            GameOver();
        }
    }

    public void IncreaseLife()
    {
        if (lifeCount == 2)
        {
            lifeCount++;
            heart_3.SetActive(true);
        }
        else if (lifeCount == 1)
        {
            lifeCount++;
            heart_2.SetActive(true);
        }
    }
}
