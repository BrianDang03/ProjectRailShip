using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;

    TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    public void incScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        Debug.Log(score);
    }
}
