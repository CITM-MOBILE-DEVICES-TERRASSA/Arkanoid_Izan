using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LadrillosManager : MonoBehaviour
{
    public GameObject ladrilloPrefab;
    public GameObject ladrilloPrefab2;
    public GameObject ladrilloPrefab3;
    public GameObject ladrilloPrefab4;

    public BoxCollider2D spawnArea;
    public float distanceX = 0.5f;
    public float distanceY = 0.5f;

    void Start()
    {
        SpawnBricks();
        StartCoroutine(WaitBeforeCheckingBricks());
    }

    IEnumerator WaitBeforeCheckingBricks()
    {
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            CheckRemainingBricks();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnBricks()
    {
        Bounds bounds = spawnArea.bounds;

        // Obtener el tamaño del ladrillo, todos tienen el mismo tamaño por lo que solo lo hacemos una vez
        float brickWidth = ladrilloPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float brickHeight = ladrilloPrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        // Calcular el número máximo de ladrillos que caben en el área en X y Y
        int bricksInRow = Mathf.FloorToInt((bounds.size.x + distanceX) / (brickWidth + distanceX));
        int bricksInColumn = Mathf.FloorToInt((bounds.size.y + distanceY) / (brickHeight + distanceY));

        // Posición inicial
        float startX = bounds.min.x + (brickWidth / 2);
        float startY = bounds.max.y - (brickHeight / 2);

        for (int row = 0; row < bricksInColumn; row++)
        {
            for (int col = 0; col < bricksInRow; col++)
            {
                float posX = startX + col * (brickWidth + distanceX);
                float posY = startY - row * (brickHeight + distanceY);

                GameObject brickToSpawn = ChooseBrickPrefab();

                Instantiate(brickToSpawn, new Vector3(posX, posY, 0f), Quaternion.identity, transform);
            }
        }
    }

    GameObject ChooseBrickPrefab()
    {
        // Definir probabilidades para cada prefab
        float randomValue = Random.Range(0f, 1f);
        if (randomValue < 0.5f)
        {
            return ladrilloPrefab;
        }
        else if (randomValue < 0.75f)
        {
            return ladrilloPrefab2;
        }
        else if (randomValue < 0.9f)
        {
            return ladrilloPrefab3;
        }
        else
        {
            return ladrilloPrefab4;
        }
    }

    void CheckRemainingBricks()
    {
        if (transform.childCount == 0)
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    public void SaveScene()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    public void LoadSavedScene()
    {
        int savedSceneIndex = PlayerPrefs.GetInt("SavedScene", 0);
        SceneManager.LoadScene(savedSceneIndex);
    }
}