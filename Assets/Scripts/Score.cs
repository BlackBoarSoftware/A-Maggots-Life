using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerController playerController;
    Rigidbody2D rb; 
    TMP_Text tMPTextField;
    int score;
    int winScore = 3;
    bool isMetamorphosisAnimPlaying = false;
    private void Start() 
    {
        tMPTextField = GetComponentInChildren<TMP_Text>(); 
        playerController = player.GetComponent<PlayerController>();
        rb  = player.GetComponent<Rigidbody2D>();  
        UpdateScore(score);
    }
    private void Update() 
    {
        if (isMetamorphosisAnimPlaying == true)
        {
            //rb.velocity = new Vector2(0,rb.velocity.y);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore()
    {
        score++;
        UpdateScore(score);
        if(score >= winScore)
        {
            WinGame();
        }
    }

    private void UpdateScore(int newScore)
    {
        tMPTextField.text = newScore.ToString();
    }

    void WinGame()
    {
        isMetamorphosisAnimPlaying = true;
        playerController.WinSequence();
    }
}
