using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    LadrillosManager ladrillosManager;
    ScoreManager scoreManager;
    BallLife ballLife;

    public bool newgame = false;
    public bool savedGame;

    void Awake()
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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ladrillosManager = FindObjectOfType<LadrillosManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        ballLife = FindObjectOfType<BallLife>();

        Debug.Log($"Scene {scene.name} loaded. ladrillosManager: {ladrillosManager}, scoreManager: {scoreManager}, ballLife: {ballLife}");
    }

    // Scene management methods
    public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(GetSceneIndex() + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        newgame = true;
        savedGame = false;
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(1);
        newgame = false;
    }

    public void AplicationQuit()
    {
        Application.Quit();
    }

    // Save and Load methods
    public void SaveCurrentScore()
    {
        if (scoreManager != null)
        {
            PlayerPrefs.SetInt("CurrentScore", scoreManager.currentScore);
            PlayerPrefs.Save();
        }
    }

    public int LoadCurrentScore()
    {
        return PlayerPrefs.GetInt("CurrentScore", 0);
    }

    public void SaveBallLife()
    {
        if (ballLife != null)
        {
            PlayerPrefs.SetInt("BallLife", ballLife.life);
            PlayerPrefs.Save();
        }
    }

    public int LoadBallLife()
    {
        return PlayerPrefs.GetInt("BallLife", 3); // Valor predeterminado
    }

    public void SaveBricks()
    {
        if (ladrillosManager != null)
        {
            var bricks = new List<string>();

            // Recorre todos los hijos de `LadrillosManager`, es decir, todos los ladrillos actuales en la escena
            foreach (Transform brick in ladrillosManager.transform)
            {
                // Convierte la información de cada ladrillo (posición y tipo) a una cadena
                string brickData = $"{brick.position.x},{brick.position.y},{brick.position.z},{brick.name}";

                // Añade la información del ladrillo a la lista
                bricks.Add(brickData);
            }

            // Une todas las cadenas en una sola, separada por puntos y comas
            string bricksData = string.Join(";", bricks);

            // Guarda la información en PlayerPrefs
            PlayerPrefs.SetString("BricksData", bricksData);
            PlayerPrefs.Save();
        }
    }

    public void LoadBricks()
    {
        // Limpiar ladrillos actuales en LadrillosManager
        if (ladrillosManager != null)
        {
            foreach (Transform brick in ladrillosManager.transform)
            {
                Destroy(brick.gameObject);
            }

            // Obtener la cadena de ladrillos desde PlayerPrefs
            string bricksData = PlayerPrefs.GetString("BricksData", "");

            if (!string.IsNullOrEmpty(bricksData))
            {
                // Dividir la cadena de ladrillos en una lista
                var bricks = bricksData.Split(';');

                foreach (var brickData in bricks)
                {
                    var data = brickData.Split(',');

                    // Parsear posición y tipo del ladrillo
                    float posX = float.Parse(data[0]);
                    float posY = float.Parse(data[1]);
                    float posZ = float.Parse(data[2]);
                    string brickType = data[3];

                    // Elegir el prefab correcto según el tipo guardado
                    GameObject prefab = null;
                    switch (brickType)
                    {
                        case "ladrilloPrefab":
                            prefab = ladrillosManager.ladrilloPrefab;
                            break;
                        case "ladrilloPrefab2":
                            prefab = ladrillosManager.ladrilloPrefab2;
                            break;
                        case "ladrilloPrefab3":
                            prefab = ladrillosManager.ladrilloPrefab3;
                            break;
                        case "ladrilloPrefab4":
                            prefab = ladrillosManager.ladrilloPrefab4;
                            break;
                        case "ladrilloEspecial":
                            prefab = ladrillosManager.ladrilloEspecial;
                            break;
                    }

                    if (prefab != null)
                    {
                        Instantiate(prefab, new Vector3(posX, posY, posZ), Quaternion.identity, ladrillosManager.transform);
                    }
                }
            }
        }
    }

    public void SaveCurrentScene()
    {
        // Guarda el índice de la escena actual
        PlayerPrefs.SetInt("CurrentScene", GetSceneIndex());
        PlayerPrefs.Save();
        Debug.Log("Current scene saved");
    }

    public void LoadCurrentScene()
    {
        // Carga la escena guardada
        int sceneIndex = PlayerPrefs.GetInt("CurrentScene", 1); // Valor predeterminado 1
        SceneManager.LoadScene(sceneIndex);
        Debug.Log($"Loaded scene {sceneIndex}");
    }

    public void SaveGame()
    {
        SaveCurrentScore();
        SaveBallLife();
        SaveBricks();
        SaveCurrentScene(); // Guarda la escena actual
        Debug.Log("Game Saved");
        savedGame = true;
    }

    public void LoadCurrentGame()
    {
        LoadCurrentScene(); // Carga la escena guardada
        //scoreManager.currentScore = LoadCurrentScore();
        //ballLife.life = LoadBallLife();
        //LoadBricks();
        Debug.Log("Game Loaded");
        newgame = false;
    }
}
