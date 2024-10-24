using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 5f;  
    public float speedIncreasePerBounce = 0.1f;  
    public Transform player; 

    private Rigidbody2D rb;
    public bool isLaunched = false; 
    public bool powerup= false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    void Update()
    {
        if (!isLaunched)
        {
            FollowPlayer();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }
        if (powerup)
        {
            PowerUp();
        }
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 0.5f, 0f);
    }

    void LaunchBall()
    {
        isLaunched = true;
        rb.velocity = new Vector2(0, initialSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + speedIncreasePerBounce);
    }
    public void SaveBall()
    {
        PlayerPrefs.SetFloat("ballPosX", transform.position.x);
        PlayerPrefs.SetFloat("ballPosY", transform.position.y);
        PlayerPrefs.SetFloat("ballVelX", rb.velocity.x);
        PlayerPrefs.SetFloat("ballVelY", rb.velocity.y);
    }
    public void LoadBall()
    {
        float ballPosX = PlayerPrefs.GetFloat("ballPosX", 0);
        float ballPosY = PlayerPrefs.GetFloat("ballPosY", 0);
        float ballVelX = PlayerPrefs.GetFloat("ballVelX", 0);
        float ballVelY = PlayerPrefs.GetFloat("ballVelY", 0);

        transform.position = new Vector3(ballPosX, ballPosY, 0);
        rb.velocity = new Vector2(ballVelX, ballVelY);
        isLaunched = false;
    }

    public void PowerUp()
    {
        transform.localScale = new Vector3(2, 2, 1);
    }
}
