using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene("Arkanoid_1");
    }
}
