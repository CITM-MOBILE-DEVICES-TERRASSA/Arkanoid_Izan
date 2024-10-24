using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(BallLife ballLife, ScoreManager scoreManager, LadrillosManager ladrillosManager)
    {
        SaveBallLife(ballLife);
        SaveScore(scoreManager);
        SaveBrickCount(ladrillosManager);
        SaveScene();
    }

    public void LoadGame(BallLife ballLife, ScoreManager scoreManager, LadrillosManager ladrillosManager)
    {
        LoadBallLife(ballLife);
        LoadScore(scoreManager);
        LoadBrickCount(ladrillosManager);
        LoadScene();
    }

    private void SaveBallLife(BallLife ballLife)
    {
        PlayerPrefs.SetInt("BallLife", ballLife.life);
        PlayerPrefs.Save();
    }

    private void LoadBallLife(BallLife ballLife)
    {
        ballLife.life = PlayerPrefs.GetInt("BallLife", 3); 
        ballLife.lifesText.text = ballLife.life.ToString();
    }

    private void SaveScore(ScoreManager scoreManager)
    {
        PlayerPrefs.SetInt("CurrentScore", scoreManager.currentScore);
        PlayerPrefs.SetInt("HighScore", scoreManager.highScore);
        PlayerPrefs.Save();
    }

    private void LoadScore(ScoreManager scoreManager)
    {
        scoreManager.currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        scoreManager.highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreManager.UpdateUI();
    }

    private void SaveBrickCount(LadrillosManager ladrillosManager)
    {
        int remainingBricks = ladrillosManager.GetRemainingBricks();
        PlayerPrefs.SetInt("RemainingBricks", remainingBricks);
        PlayerPrefs.Save();
    }

    private void LoadBrickCount(LadrillosManager ladrillosManager)
    {
        int remainingBricks = PlayerPrefs.GetInt("RemainingBricks", 0);
    }

    private void SaveScene()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    private void LoadScene()
    {
        int savedSceneIndex = PlayerPrefs.GetInt("SavedScene", 0); 
        SceneManager.LoadScene(savedSceneIndex);
    }
}
