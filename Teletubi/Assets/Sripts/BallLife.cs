using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallLife : MonoBehaviour
{
    public int life = 3; 
    BallController ballController;
    public TextMeshProUGUI lifesText;
    AudioSource AudioSource;

    void Start()
    {
        ballController = GetComponent<BallController>();
        AudioSource = GetComponent<AudioSource>();
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
            AudioSource.Play();
            life -= 1;
            ballController.isLaunched = false;
            lifesText.text = "" + life.ToString();
        }
    }

    void DestroyBall()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Game Over");
    }
}
