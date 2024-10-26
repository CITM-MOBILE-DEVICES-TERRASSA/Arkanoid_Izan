using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    BallLife ballLife;

    void Start()
    {
        if (GameManager.instance.newgame)
        {
            ResetScore();
            GameManager.instance.SaveCurrentScore();
        }
        else
        {
            currentScore = GameManager.instance.LoadCurrentScore();
            UpdateUI();
        }
        highScore = LoadHighScore();
        UpdateUI();

        ballLife = FindObjectOfType<BallLife>();
    }

    private void Update()
    {
        if (ballLife.life <= 0)
        {
            ResetScore();
            UpdateUI();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateUI();

        CheckAndSaveHighScore();
        CheckAndSaveCurrentScore();
    }

    private void CheckAndSaveHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
            UpdateUI();
        }
    }
    private void CheckAndSaveCurrentScore()
    {
        GameManager.instance.SaveCurrentScore();
        UpdateUI();
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }

    private int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    public void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "" + currentScore;
        }

        if (highScoreText != null)
        {
            highScoreText.text = "" + highScore;
        }
    }
}
