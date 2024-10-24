using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    ScoreManager scoreManager;
    
    public void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }   
    public void ResetGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Arkanoid_1");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    
    public void Conitnue()
    {

    }
}
