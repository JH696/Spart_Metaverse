using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameStart()
    {
        ScoreManager.instance.StartScoreCount();
        Time.timeScale = 1.0f;
        GameManager.instance.startPanel.SetActive(false);
    }
}
