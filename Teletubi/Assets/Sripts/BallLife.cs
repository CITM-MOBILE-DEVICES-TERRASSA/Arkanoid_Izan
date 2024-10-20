using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallLife : MonoBehaviour
{
    public int life = 3; 
    BallController ballController;
    public TextMeshProUGUI lifesText;

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
            lifesText.text = "" + life.ToString();
        }
    }

    void DestroyBall()
    {
        Destroy(gameObject); 
    }
}
