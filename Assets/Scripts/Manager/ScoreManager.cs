using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text timeTxt;
    public Text nowScoreTxt;
    public Text bestScoreTxt;

    public GameObject newRecordUI;

    private float time = 0f;
    private bool isCounting = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("bestScore"))
        {
            float best = PlayerPrefs.GetFloat("bestScore");
            bestScoreTxt.text = best.ToString("N2");
        }
        else
        {
            bestScoreTxt.text = "0.00";
        }
    }

    void Update()
    {
        if (!isCounting) return;

        time += Time.deltaTime;

        if (timeTxt != null)
        {
            timeTxt.text = time.ToString("N2");
        }
    }

    public void StartScoreCount()
    {
        time = 0f;
        isCounting = true;
    }

    public void StopScoreCount()
    {
        isCounting = false;
    }

    public void ShowFinalScore()
    {
        if (nowScoreTxt != null)
            nowScoreTxt.text = time.ToString("N2");

        float best = PlayerPrefs.GetFloat("bestScore", 0f);
        if (time > best)
        {
            PlayerPrefs.SetFloat("bestScore", time);
            bestScoreTxt.text = time.ToString("N2");

            if (newRecordUI != null)
            {
                newRecordUI.SetActive(true);
            }
        }
        else
        {
            bestScoreTxt.text = best.ToString("N2");
        }
    }

    public float GetCurrentScore()
    {
        return time;
    }
}
