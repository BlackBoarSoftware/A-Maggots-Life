using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    TMP_Text tMPTextField;
    int score;
    private void Start() 
    {
        tMPTextField = GetComponentInChildren<TMP_Text>();   
        UpdateScore(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore()
    {
        score++;
        UpdateScore(score);
    }

    private void UpdateScore(int newScore)
    {
        tMPTextField.text = newScore.ToString();
    }
}
