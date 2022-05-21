using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] int target;
    [SerializeField] Color defaultColor = Color.red;
    [SerializeField] Color unlockColor = Color.blue;
    
    SpriteRenderer spriteRenderer;
    Score playerScore;

    bool isUnlocked;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        playerScore = FindObjectOfType<Score>();
    }

    void Update()
    {
        //Check if player has enough coins to unlock the goal
        if(playerScore.GetScore() >= target)
        {
            isUnlocked = true;
            spriteRenderer.color = unlockColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Complete the level if the player has enough coins
        if (other.GetComponent<Score>() == playerScore)
        {
            if(isUnlocked) {
                LevelManager.Instance.ReloadLevel();
            }
        }
    }
}
