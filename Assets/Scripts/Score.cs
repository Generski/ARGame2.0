using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int playerScore = 0;

    public Text scoreText;

    private void Start()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void AddScore(int scoreAmount)
    {
        playerScore += scoreAmount;

        scoreText.text = "Score: " + playerScore.ToString();
    }
}
