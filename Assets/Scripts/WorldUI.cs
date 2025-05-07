using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SavePosition : MonoBehaviour
{
    public Text myScore;

    void Start()
    {
        ScoreManager.instance.bestScoreTxt.text = myScore.text;
    }
}
