using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;

    public void incScore(int value)
    {
        score += value;
        Debug.Log(score);
    }
}
