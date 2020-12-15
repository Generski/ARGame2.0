using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int playerScore = 0;

    public Text scoreText;

    public GameObject notEnoughMoneyText;

    public GameObject buyHPUI;
    public GameObject buyGunUI;
    public GameObject buySpeedUI;

    private void Start()
    {
        scoreText.text = "$ " + playerScore.ToString();
    }

    public void AddScore(int scoreAmount)
    {
        playerScore += scoreAmount;

        scoreText.text = "$ " + playerScore.ToString();
    }

    public void BuyHealth(int price)
    {
        if(playerScore >= price)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().IncreaseMaxHealth();

            playerScore -= price;
            scoreText.text = "$ " + playerScore.ToString();

            buyHPUI.SetActive(false);
        }
        else
        {
            notEnoughMoneyText.SetActive(true);
            StartCoroutine(DisplayMessage());
        }
    }

    public void BuyGun(int price)
    {
        if (playerScore >= price)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>().IncreaseFireRate();

            playerScore -= price;
            scoreText.text = "$ " + playerScore.ToString();

            buyGunUI.SetActive(false);
        }
        else
        {
            notEnoughMoneyText.SetActive(true);
            StartCoroutine(DisplayMessage());
        }
    }

    public void BuySpeed(int price)
    {
        if (playerScore >= price)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementTouch>().IncreaseMoveSpeed();

            playerScore -= price;
            scoreText.text = "$ " + playerScore.ToString();

            buySpeedUI.SetActive(false);
        }
        else
        {
            notEnoughMoneyText.SetActive(true);
            StartCoroutine(DisplayMessage());
        }
    }

    IEnumerator DisplayMessage()
    {
        notEnoughMoneyText.SetActive(true);

        yield return new WaitForSeconds(1f);

        notEnoughMoneyText.SetActive(false);
    }
}
