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
        if (GameManager.instance.newgame)
        {
            life = 3;
        }
        else
        {
            GameManager.instance.LoadBallLife();
        }
        ballController = GetComponent<BallController>();
        audioSource = GetComponent<AudioSource>();
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
            GameManager.instance.SaveBallLife();
            lifesText.text = life.ToString();
            ballController.isLaunched = false;
        }
    }

    void DestroyBall()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.LoadGameOver();
        }
        else
        {
            Debug.Log("GameManager.instance is null");
        }
    }
}
