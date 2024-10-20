using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLife : MonoBehaviour
{
    public int life = 3; 
    BallController ballController;

    void Start()
    {
        ballController = GetComponent<BallController>();
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
            life -= 1;
            ballController.isLaunched = false;
        }
    }

    void DestroyBall()
    {
        Destroy(gameObject); 
    }
}
