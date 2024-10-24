using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    ScoreManager scoreManager;
    BallLife ballLife; // Agregar referencia a BallLife

    public void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        ballLife = FindObjectOfType<BallLife>(); 
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        ResetPlayerStats(); 
        SceneManager.LoadScene("Arkanoid_1");
    }

    public void ContinuePlaying()
    {
        SceneManager.LoadScene("Arkanoid_1"); 
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    private void ResetPlayerStats()
    {
        PlayerPrefs.SetInt("CurrentScore", 0); 
        PlayerPrefs.SetInt("ballLife", 3); 
        PlayerPrefs.Save();
    }
}
