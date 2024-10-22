using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    ScoreManager ScoreManager;
    LadrillosManager LadrillosManager;
    Player Player;
    BallController BallController;
    BallLife BallLife;
    public void SaveGame()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();
        LadrillosManager = FindObjectOfType<LadrillosManager>();
        Player = FindObjectOfType<Player>();
        BallController = FindObjectOfType<BallController>();
        BallLife = FindObjectOfType<BallLife>();

        ScoreManager.SaveCurrentScore();
        LadrillosManager.SaveScene();
        Player.SavePlayerPosition();
        BallController.SaveBall();
        BallLife.SaveBallLife();

        Debug.Log("Juego guardado");
    }

    public void LoadGame()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();
        LadrillosManager = FindObjectOfType<LadrillosManager>();
        Player = FindObjectOfType<Player>();
        BallController = FindObjectOfType<BallController>();
        BallLife = FindObjectOfType<BallLife>();

        ScoreManager.LoadCurrentScore();
        LadrillosManager.LoadSavedScene();
        Player.LoadPlayerPosition();
        BallController.LoadBall();
        BallLife.LoadBallLife();

        Debug.Log("Juego cargado");
    }
}
