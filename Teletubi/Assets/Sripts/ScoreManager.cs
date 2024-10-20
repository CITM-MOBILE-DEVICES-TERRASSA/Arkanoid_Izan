using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir esto para trabajar con UI

public class ScoreManager : MonoBehaviour
{
    private int currentScore; 
    private int highScore; 

    public Text scoreText; 
    public Text highScoreText; 

    void Start()
    {
        currentScore = 0; 
        highScore = LoadHighScore(); 
        UpdateUI(); 
    }


    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd; 
        UpdateUI(); 

        CheckAndSaveHighScore(); 
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


    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore; 
        }

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore; 
        }
    }
}
