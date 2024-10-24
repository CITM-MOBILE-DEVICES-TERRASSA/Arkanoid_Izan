using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallLife : MonoBehaviour
{
    public int life; 
    BallController ballController;
    public TextMeshProUGUI lifesText;
    AudioSource audioSource;

    void Start()
    {
        ballController = GetComponent<BallController>();
        audioSource = GetComponent<AudioSource>();
        LoadBallLife(); 
    }

    void Update()
    {
        if (life <= 0)
        {
            DestroyBall();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            audioSource.Play();
            life -= 1;
            lifesText.text = life.ToString();
            ballController.isLaunched = false;
            SaveManager.instance.SaveGame(this, FindObjectOfType<ScoreManager>(), FindObjectOfType<LadrillosManager>());
        }
    }

    void DestroyBall()
    {
        SaveBallLife(); 
        SceneManager.LoadScene("Game Over");
    }

    public void SaveBallLife()
    {
        PlayerPrefs.SetInt("ballLife", life);
        PlayerPrefs.Save();
    }

    public void LoadBallLife()
    {
        life = PlayerPrefs.GetInt("ballLife", 3); 
        lifesText.text = life.ToString();
    }
}
