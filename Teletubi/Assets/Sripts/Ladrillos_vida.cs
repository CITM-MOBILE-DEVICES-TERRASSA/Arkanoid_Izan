using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladrillos : MonoBehaviour
{
    public float health = 1.0f; 
    public int puntos = 1;      
    public bool isspecial = false;

    ScoreManager scoreManager;
    BallController ballController;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); 
        ballController = FindObjectOfType<BallController>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            health -= 1.0f;

            if (health <= 0)
            {
                DestroyBrick();
            }
        }
    }

    void DestroyBrick()
    {
        Destroy(gameObject);
        scoreManager.AddScore(puntos);
        if (isspecial)
        {
            ballController.powerup = true;
        }
    }
}
