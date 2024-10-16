using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 initialV;
    private Rigidbody2D ball;
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        ball.velocity = initialV;
    }

    void Update()
    {
        
    }
}
